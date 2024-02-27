
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

    private class Heap
    {
        private PriorityQueue<int, int> _pq;
        public Heap()
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
        private Heap _left;
        private Heap _right;
        private int[] _costs;
        private LRIndeces _indeces;

        public DualQueues(int[] costs, int n)
        {
            _costs = costs;
            _indeces = new(costs.Length);
            _left = CreateLeftHeap(n);
            _right = CreateRightHeap(n);
        }

        public bool LeftContainsItems => _left.ContainsItems;
        public bool RightContainsItems => _right.ContainsItems;

        public int LeftPeek()
        {
            return _left.Peek();
        }

        public int RightPeek()
        {
            return _right.Peek();
        }

        private Heap CreateLeftHeap(int n)
        {
            Heap leftSet = new();

            while (_indeces.i < n)
            {
                leftSet.Add(_costs[_indeces.i]);
                _indeces.i++;
            }

            return leftSet;
        }

        private Heap CreateRightHeap(int n)
        {
            Heap rightSet = new();

            while (_indeces.IsValid() && _indeces.j > _costs.Length - 1 - n)
            {
                rightSet.Add(_costs[_indeces.j]);
                _indeces.j--;
            }

            return rightSet;
        }


        public int GetFromLeft()
        {
            int ans = _left.Remove();

            if (_indeces.IsValid())
            {
                _left.Add(_costs[_indeces.i]);
                _indeces.i++;
            }
            return ans;
        }

        public int GetFromRight()
        {
            int ans = _right.Remove();

            if (_indeces.IsValid())
            {
                _right.Add(_costs[_indeces.j]);
                _indeces.j--;
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
            if (queues.LeftContainsItems)
            {
                if (queues.RightContainsItems)
                {
                    if (queues.LeftPeek() <= queues.RightPeek())
                    {
                        total += queues.GetFromLeft();
                        continue;
                    }

                    total += queues.GetFromRight();
                    continue;
                }

                total += queues.GetFromLeft();
                continue;

            }
            if (queues.RightContainsItems)
            {
                total += queues.GetFromRight();
            }
        }

        return total;
    }
}
