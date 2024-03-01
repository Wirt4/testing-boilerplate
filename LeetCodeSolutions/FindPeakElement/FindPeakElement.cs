namespace LeetCodeSolutions;
public class FindPeakElementSolution
{
    public int FindPeakElement(int[] nums)
    {
        if (nums.Length == 1) { return 0; }
        return nums[0] > nums[1] ? 0 : 1;
    }
}
