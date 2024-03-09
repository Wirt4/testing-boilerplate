using Microsoft.VisualBasic;

namespace LeetCodeSolutions;
public class CountBitsSolution
{
    public int[] CountBits(int n)
    {
        int[] arr = new int[n + 1];
        for (int i = 0; i <= n; i++)
        {
            int j = i;
            int count = 0;
            while (j > 0)
            {
                if (j % 2 == 1) { count++; }
                j /= 2;
            }
            arr[i] = count;
        }
        return arr;
    }
}
