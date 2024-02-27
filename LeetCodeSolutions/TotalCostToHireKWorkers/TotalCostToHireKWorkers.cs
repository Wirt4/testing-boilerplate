
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

    private class MinHeap
    {
        private PriorityQueue<int, int> _pq;
        public MinHeap()
        {
            _pq = new();
        }

        public void Add(int value)
        {
            _pq.Enqueue(value, value);
        }

        public bool ContainsItems => _pq.Count > 0;

        public int Peek()
        {
            return _pq.Peek();
        }

        public int Remove()
        {
            return _pq.Dequeue();
        }
    }

    private class DualQueues
    {
        private readonly MinHeap _left;
        private readonly MinHeap _right;
        private readonly int[] _costs;
        private readonly LRIndeces _indeces;

        public DualQueues(int[] costs, int n)
        {
            _costs = costs;
            _indeces = new(costs.Length);
            _left = CreateLeftHeap(n);
            _right = CreateRightHeap(n);
        }

        private MinHeap CreateLeftHeap(int n)
        {
            MinHeap leftSet = new();

            while (_indeces.i < n)
            {
                leftSet.Add(_costs[_indeces.i]);
                _indeces.i++;
            }

            return leftSet;
        }

        private MinHeap CreateRightHeap(int n)
        {
            MinHeap rightSet = new();

            while (_indeces.IsValid() && _indeces.j > _costs.Length - 1 - n)
            {
                rightSet.Add(_costs[_indeces.j]);
                _indeces.j--;
            }

            return rightSet;
        }


        private int GetFromLeft()
        {
            int ans = _left.Remove();

            if (_indeces.IsValid())
            {
                _left.Add(_costs[_indeces.i]);
                _indeces.i++;
            }
            return ans;
        }

        private int GetFromRight()
        {
            int ans = _right.Remove();

            if (_indeces.IsValid())
            {
                _right.Add(_costs[_indeces.j]);
                _indeces.j--;
            }

            return ans;
        }

        public int GetNextSmallest()
        {
            if (_left.ContainsItems)
            {
                if (_right.ContainsItems)
                {
                    if (_left.Peek() <= _right.Peek())
                    {
                        return GetFromLeft();
                    }
                    return GetFromRight();
                }
                return GetFromLeft();
            }
            if (_right.ContainsItems)
            {
                return GetFromRight();
            }
            return 0;
        }

    }
    public long TotalCost(int[] costs, int k, int n)
    {
        DualQueues queues = new(costs, n);
        long total = 0;

        for (int m = 0; m < k; m++)
        {
            total += queues.GetNextSmallest();
        }

        return total;
    }
}
