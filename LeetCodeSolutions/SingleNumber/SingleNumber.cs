namespace LeetCodeSolutions;
public class SingleNumberSolution
{
    public int SingleNumber(int[] nums)
    {
        int outlier = 0b0;
        foreach (int num in nums)
        {
            outlier = num ^ outlier;
        }
        return outlier;
    }
}
