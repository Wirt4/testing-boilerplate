namespace LeetCodeSolutions;
public class LongestCommonSubsequenceSolution
{
    public int LongestCommonSubsequence(string text1, string text2)
    {
        if (text1.Length == 0 || text2.Length == 0)
        {
            return 0;
        }
        if (text1[0] == text2[0])
        {
            return 1 + LongestCommonSubsequence(text1.Substring(1), text2.Substring(1));
        }
        return Math.Max(LongestCommonSubsequence(text1, text2.Substring(1)), LongestCommonSubsequence(text1.Substring(1), text2));
    }
}
