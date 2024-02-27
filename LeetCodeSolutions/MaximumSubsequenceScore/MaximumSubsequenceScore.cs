namespace LeetCodeSolutions;
public class MaximumSubsequenceScoreSolution
{

    private static (long, int)[] NumsDescendingByMultiplier(int[] nums1, int[] nums2)
    {
        int size = nums1.Length;
        List<(long, int)> PairList = new(size);

        for (int i = 0; i < size; i++)
        {
            PairList.Add((nums1[i], nums2[i]));
        }

        return [.. PairList.OrderByDescending(x => x.Item2)];
    }

    private class PriorityQueueWrapper((long, int)[] sorted, int capacity)
    {
        private PriorityQueue<long, long> _minAdders = new();
        private long _sum = 0;
        private long _maxValue = 0;
        private int _capacity = capacity;
        private (long, int)[] _sortedByMultiplier = sorted;

        public long MaxProduct => _maxValue;

        public void Traverse()
        {
            for (int i = 0; i < _sortedByMultiplier.Length; i++)
            {
                (long, int) current = _sortedByMultiplier[i];
                _sum += current.Item1;

                if (i >= _capacity - 1)
                {
                    _sum -= i >= _capacity ? _minAdders.Dequeue() : 0;
                    _maxValue = Math.Max(_maxValue, _sum * current.Item2);
                }

                _minAdders.Enqueue(current.Item1, current.Item1);
            }
        }
    }

    public long MaxScore(int[] nums1, int[] nums2, int k)
    {
        (long, int)[] sortedByMultiplier = NumsDescendingByMultiplier(nums1, nums2);
        PriorityQueueWrapper wrapper = new(sortedByMultiplier, k);
        wrapper.Traverse();
        return wrapper.MaxProduct;
    }
}
