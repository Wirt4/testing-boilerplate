namespace LeetCodeSolutions;
public class MaximumSubsequenceScoreSolution
{

    private class PriorityQueueWrapper
    {
        private PriorityQueue<int[], int> _priorityQueue;
        private int _sum;
        private int _currentMax;
        public PriorityQueueWrapper()
        {
            _priorityQueue = new();
            _sum = 0;
            _currentMax = -1;
        }

        public void Enqueue(int[] pair)
        {
            _sum += pair[1];
            _priorityQueue.Enqueue(pair, pair[0]);
            if (_priorityQueue.Count > 0)
            {
                _currentMax = MultiplyForCurrentMax();
            }
        }

        public void EnqueueRange(int[][] pairs, int startIndx, int endIndx)
        {
            for (int i = startIndx; i < endIndx; i++)
            {

                Enqueue(pairs[i]);
            }
        }

        public int[] Dequeue()
        {
            int[] pair = _priorityQueue.Dequeue();
            _sum -= pair[1];
            if (_priorityQueue.Count > 0)
            {
                _currentMax = MultiplyForCurrentMax();
            }

            return pair;
        }

        public int Count => _priorityQueue.Count;

        private int MultiplyForCurrentMax()
        {
            return _priorityQueue.Peek()[0] * _sum;
        }

        public int CurrentMax => _currentMax;
    }
    private int[][] GetSortedPairs(int[] nums1, int[] nums2)
    {
        PriorityQueueWrapper pQueue = new();
        for (int i = 0; i < nums1.Length; i++)
        {
            pQueue.Enqueue([nums2[i], nums1[i]]);
        }

        int[][] allPairs = new int[nums1.Length][];
        int j = 0;

        while (pQueue.Count > 0)
        {
            allPairs[j] = pQueue.Dequeue();
            j++;
        }

        return allPairs;
    }
    public long MaxScore(int[] nums1, int[] nums2, int k)
    {
        int[][] allPairs = GetSortedPairs(nums1, nums2);
        PriorityQueueWrapper pQueue = new();
        pQueue.EnqueueRange(allPairs, 0, k);
        int max = pQueue.CurrentMax;

        for (int p = k; p < nums1.Length; p++)
        {
            pQueue.Dequeue();
            pQueue.Enqueue(allPairs[p]);

            if (pQueue.CurrentMax > max)
            {
                max = pQueue.CurrentMax;
            }
        }

        return max;
    }
}
