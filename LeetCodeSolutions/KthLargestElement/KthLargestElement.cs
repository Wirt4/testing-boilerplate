
namespace LeetCodeSolutions;
public class KthLargestElementSolution
{
    public int FindKthLargest(int[] nums, int k)
    {
        PriorityQueue<int, int> heap = new(nums.Length);

        foreach (int num in nums)
        {
            heap.Enqueue(num, num);

            if (heap.Count > k)
            {
                heap.Dequeue();
            }
        }
        return heap.Peek();
    }
}
