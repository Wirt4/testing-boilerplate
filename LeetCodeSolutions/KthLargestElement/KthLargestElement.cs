
namespace LeetCodeSolutions;
public class KthLargestElementSolution
{


    public int FindKthLargest(int[] nums, int k)
    {
        Array.Sort(nums);
        Array.Reverse(nums);// stupid solution
        return nums[k - 1];
    }
}
