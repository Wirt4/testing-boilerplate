namespace LeetCodeSolutions;
public class MaximumSubsequenceScoreSolution
{

    private class PriorityQueueWrapper
    {
        private PriorityQueue<int[], int> _priorityQueue;
        public PriorityQueueWrapper()
        {
            _priorityQueue = new();
        }

        public void Enqueue(int[] pair)
        {
            _priorityQueue.Enqueue(pair, pair[0]);
        }

        public int[] Dequeue()
        {
            return _priorityQueue.Dequeue();
        }

        public int Count => _priorityQueue.Count;

        public int[] Peek()
        {
            return _priorityQueue.Peek();
        }
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
        int sum = 0;

        for (int m = 0; m < k; m++)
        {
            sum += allPairs[m][1];
            pQueue.Enqueue(allPairs[m]);
        }

        int max = sum * pQueue.Peek()[0];

        for (int p = k; p < nums1.Length; p++)
        {
            sum -= pQueue.Dequeue()[1];
            sum += allPairs[p][1];
            pQueue.Enqueue(allPairs[p]);
            int currentMax = sum * pQueue.Peek()[0];
            max = currentMax > max ? currentMax : max;
        }
        return max;
    }
}
