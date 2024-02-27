namespace LeetCodeSolutions;
public class MaximumSubsequenceScoreSolution
{
    private class PairOfOperands
    {
        public int adder;
        public int multiplier;
    }
    private PairOfOperands[] NumsDescendingByMultiplier(int[] nums1, int[] nums2)
    {
        int size = nums1.Length;
        List<PairOfOperands> PairList = new(size);

        for (int i = 0; i < size; i++)
        {
            PairList.Add(new()
            {
                adder = nums1[i],
                multiplier = nums2[i]
            });
        }

        return PairList.OrderByDescending(x => x.multiplier).ToArray();
    }
    public long MaxScore(int[] nums1, int[] nums2, int k)
    {
        PairOfOperands[] sortedByMultiplier = NumsDescendingByMultiplier(nums1, nums2);
        PriorityQueue<PairOfOperands, int> minAdders = new();
        long maxSum = 0;

        PairOfOperands current = new();

        for (int i = 0; i < k; i++)
        {
            current = sortedByMultiplier[i];
            maxSum += current.adder;
            minAdders.Enqueue(current, current.adder);
        }

        long result = maxSum * current.multiplier;

        for (int i = k; i < sortedByMultiplier.Length; i++)
        {
            current = sortedByMultiplier[i];
            maxSum += current.adder - minAdders.Dequeue().adder;
            result = Math.Max(result, maxSum * current.multiplier);
            minAdders.Enqueue(current, current.adder);
        }

        return result;
    }
}
