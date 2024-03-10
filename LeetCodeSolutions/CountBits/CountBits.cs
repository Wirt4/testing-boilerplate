namespace LeetCodeSolutions;
public class CountBitsSolution
{
    public int[] CountBits(int n)
    {
        int[] arr = new int[n + 1];
        for (int i = 0; i <= n; i++)
        {
            arr[i] = arr[i / 2] + i % 2;
        }
        return arr;
    }
}
