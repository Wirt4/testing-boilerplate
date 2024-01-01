namespace LeetCodeSolutions;
public class BinaryTreeRightSideViewSolution
{
    private class LeveledQueue
    {
        private Queue<TreeNode> currentLevel;
        private Queue<TreeNode> nextLevel;
        private TreeNode currentNode;
        public LeveledQueue(TreeNode? root)
        {
            nextLevel = new();
            currentLevel = new();
            if (root != null)
            {
                currentLevel.Enqueue(root);
            }
            currentNode = new(-1);
        }

        private TreeNode Dequeue()
        {
            return currentLevel.Dequeue();
        }

        private void EnqueueToNextLevel(TreeNode? node)
        {
            if (node != null)
            {
                nextLevel.Enqueue(node);
            }
        }

        private void EnqueChildrenToNextLevel(TreeNode node)
        {
            EnqueueToNextLevel(node.left);
            EnqueueToNextLevel(node.right);
        }

        public bool HasTravesersedCurrentLevel()
        {
            return Count == 0;
        }

        public void ShiftToNextLevel()
        {
            currentLevel = nextLevel;
            nextLevel = new();
        }

        public void GetNext()
        {
            currentNode = Dequeue();
            EnqueChildrenToNextLevel(currentNode);
        }

        public int Count => currentLevel.Count;
        public int CurrentNodeValue => currentNode.val;
    }

    private class ValueHistory
    {
        readonly Stack<int> allHistory;
        readonly List<int> rightSideOnly;
        public ValueHistory()
        {
            allHistory = new();
            rightSideOnly = new();
        }

        public void Add(int value)
        {
            allHistory.Push(value);
        }

        public void Shift()
        {
            rightSideOnly.Add(allHistory.Pop());
        }

        public int[] ToArray()
        {
            return [.. rightSideOnly];
        }
    }
    public IList<int> RightSideView(TreeNode? root)
    {
        LeveledQueue enhancedQueue = new(root);
        ValueHistory valueHistory = new();

        while (enhancedQueue.Count > 0)
        {
            enhancedQueue.GetNext();
            valueHistory.Add(enhancedQueue.CurrentNodeValue);

            if (enhancedQueue.HasTravesersedCurrentLevel())
            {
                enhancedQueue.ShiftToNextLevel();
                valueHistory.Shift();
            }
        }

        return valueHistory.ToArray();
    }
}
