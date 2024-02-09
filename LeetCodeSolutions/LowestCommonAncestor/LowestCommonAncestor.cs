namespace LeetCodeSolutions;
public class LowestCommonAncestorSolution
{
    private class IndexedTree
    {
        private readonly int[] f_occur;
        private readonly TreeNode[] euler;
        private readonly int[] level;
        private int writeIndex;
        private readonly int arrSize;

        public IndexedTree(TreeNode root, int HighestNodeValue)
        {
            arrSize = 2 * HighestNodeValue - 1;
            f_occur = new int[arrSize];
            euler = new TreeNode[arrSize]; // for euler tour sequence
            level = new int[arrSize]; // level of nodes in tour sequence

            for (int i = 0; i < arrSize; i++)
            {
                f_occur[i] = -1; // TODO: set a better "null" value here
            }

            writeIndex = 0;

            EulerianTour(root, 0);

        }

        private void EulerianTour(TreeNode node, int levelIndex)
        {
            euler[writeIndex] = node;
            level[writeIndex] = levelIndex;
            writeIndex++;

            //if unvisited
            if (f_occur[node.val] == -1)
            {
                f_occur[node.val] = writeIndex - 1;
            }

            if (node.left != null)
            {
                EulerianTour(node.left, levelIndex + 1);
                if (writeIndex < arrSize)
                {
                    euler[writeIndex] = node;
                    level[writeIndex] = levelIndex;
                    writeIndex++;
                }

            }

            if (node.right != null)
            {
                EulerianTour(node.right, levelIndex + 1);
                if (writeIndex < arrSize)
                {
                    euler[writeIndex] = node;
                    level[writeIndex] = levelIndex;
                    writeIndex++;
                }
            }
        }

        public TreeNode NodeAtIndex(int RMQNdx)
        {
            return euler[RMQNdx];
        }

        public IndexRange GetIndexRange(int nodeValue1, int nodeValue2)
        {
            if (f_occur[nodeValue1] > f_occur[nodeValue2])
            {
                (nodeValue2, nodeValue1) = (nodeValue1, nodeValue2);
            }

            return new IndexRange(f_occur[nodeValue1], f_occur[nodeValue2]);
        }
        public int[] Level => level; //TODO
    }
    private class SegmentTree
    {
        private int[] _segementTreeArr;
        private readonly int treeSize;
        private readonly int[] _level;
        public SegmentTree(IndexedTree tree, int highestNodeValue)
        {
            _level = tree.Level;
            _segementTreeArr = new int[10000];//??
            treeSize = 2 * highestNodeValue - 1;
            InitializeSegmentTree(_level, treeSize);
        }
        public int GetIndex(IndexRange searchIndeces)
        {
            return RangeMinimumQuery(0, new(0, treeSize), searchIndeces);
        }

        private int RangeMinimumQuery(int currentNodeIndex, IndexRange currentNodeRange, IndexRange queryRange)
        {
            if (queryRange.ContainsRange(currentNodeRange))
            {
                return _segementTreeArr[currentNodeIndex];
            }
            if (currentNodeRange.IsOutsideRange(queryRange))
            {
                return -1; //Alternate: throw error
            }

            int midpiont = currentNodeRange.GetMiddleOfRange();
            int query1 = RangeMinimumQuery(2 * currentNodeIndex + 1, new(currentNodeRange.StartIndex, midpiont), queryRange);
            int query2 = RangeMinimumQuery(2 * currentNodeIndex + 2, new(midpiont + 1, currentNodeRange.EndIndex), queryRange);
            if (query1 == -1)
            {
                return query2;
            }
            if (query2 == -1)
            {
                return query1;
            }

            if (_level[query1] < _level[query2])
            {
                return query1;
            }

            return query2;
        }

        private void RecursiveTreeConstruct(int currentNodeIndex, IndexRange indexRange, int[] level)
        {
            if (indexRange.OnlyOneElement())
            {
                _segementTreeArr[currentNodeIndex] = indexRange.StartIndex;
                return;
            }

            int midIndex = indexRange.GetMiddleOfRange();

            int nodeDoubled = currentNodeIndex * 2;
            int lowerHalfIndex = nodeDoubled + 1;
            int upperHalfIndex = nodeDoubled + 2;

            RecursiveTreeConstruct(lowerHalfIndex, new IndexRange(indexRange.StartIndex, midIndex), level);
            RecursiveTreeConstruct(upperHalfIndex, new IndexRange(midIndex + 1, indexRange.EndIndex), level);

            if (level[_segementTreeArr[lowerHalfIndex]] < level[_segementTreeArr[upperHalfIndex]])
            {
                _segementTreeArr[currentNodeIndex] = _segementTreeArr[lowerHalfIndex];
                return;
            }

            _segementTreeArr[currentNodeIndex] = _segementTreeArr[upperHalfIndex];

        }

        private void InitializeSegmentTree(int[] level, int n)
        {
            _segementTreeArr = GenerateArrToMaxSize(n);
            IndexRange indexRange = new(0, n - 1);
            RecursiveTreeConstruct(0, indexRange, level);
        }
        private static int BitWiseLog2(int x)
        {
            int ans = 0;
            int y = x >>= 1;
            while (y-- != 0)
            {
                ans++;
            }

            return ans;
        }
        private static int[] GenerateArrToMaxSize(int n)
        {
            int x = BitWiseLog2(n) + 1;

            // Maximum size of segment tree
            int max_size = 2 * Bitwise2Pow(x) - 1;
            return new int[max_size];
        }

        private static int Bitwise2Pow(int x)
        {
            return 1 << x;
        }
    }

    private class IndexRange
    {
        readonly int _start;
        readonly int _end;
        public IndexRange(int start, int end)
        {
            _start = start;
            _end = end;
        }

        public bool OnlyOneElement()
        {
            return _start == _end;
        }
        public int StartIndex => _start;
        public int EndIndex => _end;

        public int GetMiddleOfRange()
        {
            return (_start + _end) / 2;
        }

        public bool ContainsRange(IndexRange range)
        {
            return _start <= range.StartIndex && _end >= range.EndIndex;
        }

        public bool IsOutsideRange(IndexRange range)
        {
            return _end < range.StartIndex || _start > range.EndIndex;
        }
    }
    private static int GetHighestNodeValue(TreeNode root)
    {
        if (root.left == null && root.right == null)
        {
            return root.val;
        }
        if (root.left != null && root.right == null)
        {
            return Math.Max(root.val, GetHighestNodeValue(root.left));
        }
        if (root.left == null && root.right != null)
        {
            return Math.Max(root.val, GetHighestNodeValue(root.right));
        }

        return Math.Max(root.val, Math.Max(GetHighestNodeValue(root.left), GetHighestNodeValue(root.right)));
    }
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        int HighestNodeValue = GetHighestNodeValue(root);

        IndexedTree indexedTree = new(root, HighestNodeValue);

        IndexRange searchIndeces = indexedTree.GetIndexRange(p.val, q.val);

        SegmentTree rangeFinder = new(indexedTree, HighestNodeValue);
        int rangeMinimumIndex = rangeFinder.GetIndex(searchIndeces);
        return indexedTree.NodeAtIndex(rangeMinimumIndex);
    }
}
