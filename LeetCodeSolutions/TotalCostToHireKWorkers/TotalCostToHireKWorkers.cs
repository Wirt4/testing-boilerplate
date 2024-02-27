
namespace LeetCodeSolutions;
public class TotalCostToHireKWorkersSolution
{

    private class LRIndeces(int length)
    {
        public int i = 0;
        public int j = length - 1;

        public bool IsValid()
        {
            return i <= j;
        }
    }

    private class DualQueues
    {
        private PriorityQueue<int, int> _left;
        private PriorityQueue<int, int> _right;
        private int[] _costs;
        private LRIndeces _indeces;

        public DualQueues(int[] costs, int n)
        {
            _costs = costs;
            _indeces = new(costs.Length);
            _left = CreateLeftSet(costs, n, ref _indeces);
            _right = CreateRightSet(costs, n, ref _indeces);
        }

        public int LeftCount => _left.Count;
        public int RightCount => _right.Count;

        public int LeftPeek()
        {
            return _left.Peek();
        }

        public int RightPeek()
        {
            return _right.Peek();
        }

        private PriorityQueue<int, int> CreateLeftSet(int[] costs, int n, ref LRIndeces indeces)
        {
            PriorityQueue<int, int> leftSet = new();

            while (indeces.i < n)
            {
                leftSet.Enqueue(costs[indeces.i], costs[indeces.i]);
                indeces.i++;
            }

            return leftSet;
        }

        private PriorityQueue<int, int> CreateRightSet(int[] costs, int n, ref LRIndeces indeces)
        {
            PriorityQueue<int, int> q = new();
            while (indeces.IsValid() && indeces.j > costs.Length - 1 - n)
            {
                q.Enqueue(costs[indeces.j], costs[indeces.j]);
                indeces.j--;
            }
            return q;
        }

        public int GetFromLeft()
        {
            return DequeueEnqueueLeftSet(_costs, ref _indeces.i, _indeces.j, ref _left);
        }
        private int DequeueEnqueueLeftSet(int[] costs, ref int i, int j, ref PriorityQueue<int, int> set)
        {
            int ans = set.Dequeue();

            if (i <= j)
            {
                set.Enqueue(costs[i], costs[i]);
                i++;
            }
            return ans;
        }

        public int GetFromRight()
        {
            return DequeueEnqueueRightSet(_costs, _indeces.i, ref _indeces.j, ref _right);
        }
        private int DequeueEnqueueRightSet(int[] costs, int i, ref int j, ref PriorityQueue<int, int> set)
        {
            int ans = set.Dequeue();

            if (i <= j)
            {
                set.Enqueue(costs[j], costs[j]);
                j--;
            }
            return ans;
        }

    }
    public long TotalCost(int[] costs, int k, int n)
    {
        DualQueues queues = new(costs, n);

        long total = 0;
        for (int m = 0; m < k; m++)
        {
            if (queues.LeftCount == 0 && queues.RightCount == 0)
            {
                break;
            }

            if (queues.LeftCount == 0 && queues.RightCount > 0)
            {
                total += queues.GetFromRight();
                continue;
            }
            if (queues.LeftCount > 0 && queues.RightCount == 0)
            {
                total += queues.GetFromLeft();
                continue;
            }
            if (queues.LeftCount > 0 && queues.RightCount > 0)
            {
                if (queues.LeftPeek() <= queues.RightPeek())
                {
                    total += queues.GetFromLeft();
                    continue;
                }
                total += queues.GetFromRight();
            }
        }

        return total;
    }
}
