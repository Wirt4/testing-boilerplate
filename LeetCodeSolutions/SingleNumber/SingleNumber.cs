namespace LeetCodeSolutions;
public class SingleNumberSolution
{
    public int SingleNumber(int[] nums)
    {
        uint outlier = 0b0;
        foreach (uint num in nums)
        {
            outlier = num ^ outlier;
        }
        return (int)outlier;
    }
}
