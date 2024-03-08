namespace LeetCodeSolutions;
public class DominoAndTrominoTilingSolution
{
    private class TileTracker
    {
        private int[] dynamicArray;
        private readonly int originalLength;
        private readonly double mod;

        public TileTracker()
        {
            dynamicArray = [1, 1, 2];
            originalLength = dynamicArray.Length;
            mod = Math.Pow(10, 9) + 7;
        }

        private void ExpandDynamicArray(int n)
        {
            int[] temp = new int[n + 1];
            for (int i = 0; i < dynamicArray.Length; i++)
            {
                temp[i] = dynamicArray[i];
            }
            dynamicArray = temp;
        }

        private void FillDynamicArray()
        {
            for (int i = originalLength; i < dynamicArray.Length; i++)
            {
                dynamicArray[i] = (int)((2.0 * dynamicArray[i - 1] + dynamicArray[i - 3]) % mod);
            }
        }

        public int NumberOfTilings(int n)
        {
            if (n >= originalLength)
            {
                ExpandDynamicArray(n);
                FillDynamicArray();
            }
            return dynamicArray[n];
        }
    }

    public int NumTilings(int n)
    {
        TileTracker tracker = new();
        return tracker.NumberOfTilings(n);
    }
}
