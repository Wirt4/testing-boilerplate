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
        int arrLength = nums1.Length;
        PairOfOperands[] sortedDescendingByMultiplier = new PairOfOperands[arrLength];
        PriorityQueue<PairOfOperands, int> sortingHeap = new();

        for (int i = 0; i < arrLength; i++)
        {
            PairOfOperands p = new()
            {
                adder = nums1[i],
                multiplier = nums2[i]
            };
            sortingHeap.Enqueue(p, p.multiplier);
        }

        for (int j = arrLength - 1; j >= 0; j--)
        {
            sortedDescendingByMultiplier[j] = sortingHeap.Dequeue();
        }

        return sortedDescendingByMultiplier;
    }
    public long MaxScore(int[] nums1, int[] nums2, int k)
    {
        PairOfOperands[] sortedByMultiplier = NumsDescendingByMultiplier(nums1, nums2);
        PriorityQueue<PairOfOperands, int> minAdders = new();
        long maxSum = 0;



        int minMultiplier = 0;

        for (int i = 0; i < k; i++)
        {
            PairOfOperands p = sortedByMultiplier[i];
            minAdders.Enqueue(p, p.adder);
            maxSum += p.adder;
            minMultiplier = p.multiplier;
        }

        long result = maxSum * minMultiplier;

        for (int i = k; i < sortedByMultiplier.Length; i++)
        {
            PairOfOperands currentPair = sortedByMultiplier[i];
            maxSum += currentPair.adder - minAdders.Dequeue().adder;
            minMultiplier = currentPair.multiplier;
            result = Math.Max(result, maxSum * minMultiplier);
            minAdders.Enqueue(currentPair, currentPair.adder);
        }

        return result;
    }
}
