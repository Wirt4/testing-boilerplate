namespace LeetCodeSolutions;
public class LongestCommonSubsequenceSolution
{
    public int LongestCommonSubsequence(string text1, string text2)
    {
        //create an array 
        int[][] lengthTable = new int[text1.Length + 1][];
        for (int i = 0; i < lengthTable.Length; i++)
        {
            //allocate the slots
            lengthTable[i] = new int[text2.Length + 1];
        }
        // start at the back
        for (int ndx1 = text1.Length; ndx1 >= 0; ndx1--)
        {
            for (int ndx2 = text2.Length; ndx2 >= 0; ndx2--)
            {
                if (ndx1 >= text1.Length || ndx2 >= text2.Length)
                {
                    lengthTable[ndx1][ndx2] = 0;
                    continue;
                }
                if (text1[ndx1] == text2[ndx2])
                {
                    lengthTable[ndx1][ndx2] = 1 + lengthTable[ndx1 + 1][ndx2 + 1];
                    continue;
                }
                lengthTable[ndx1][ndx2] = Math.Max(lengthTable[ndx1 + 1][ndx2], lengthTable[ndx1][ndx2 + 1]);
            }
        }
        return lengthTable[0][0];
    }

    private int RecursiveSubproblem(ref string text1, ref string text2, int ndx1, int ndx2)
    {
        if (ndx1 >= text1.Length || ndx2 >= text2.Length)
        {
            return 0;
        }
        if (text1[ndx1] == text2[ndx2])
        {
            return 1 + RecursiveSubproblem(ref text1, ref text2, ndx1 + 1, ndx2 + 1);
        }
        return Math.Max(RecursiveSubproblem(ref text1, ref text2, ndx1, ndx2 + 1), RecursiveSubproblem(ref text1, ref text2, ndx1 + 1, ndx2));
    }
}
