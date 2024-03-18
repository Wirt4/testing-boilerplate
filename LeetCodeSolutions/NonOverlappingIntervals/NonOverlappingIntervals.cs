namespace LeetCodeSolutions;
public class NonOverlappingIntervalsSolution
{
    private void Sort(ref int[][] intervals, int lowIndex, int highIndex)
    {
        if (lowIndex >= highIndex || lowIndex < 0)
        {
            return;
        }

        int pivotIndex = Partition(ref intervals, lowIndex, highIndex);

        Sort(ref intervals, lowIndex, pivotIndex - 1);
        Sort(ref intervals, pivotIndex + 1, highIndex);
    }

    private int GetMedianIndex(ref int[][] intervals, int lowIndex, int highIndex)
    {
        Random rand = new();
        int ndx1 = rand.Next(lowIndex, highIndex + 1);
        int ndx2 = rand.Next(lowIndex, highIndex + 1);
        int ndx3 = rand.Next(lowIndex, highIndex + 1);
        int a = intervals[ndx1][1];
        int b = intervals[ndx2][1];
        int c = intervals[ndx3][1];
        int median = Math.Max(Math.Min(a, b), Math.Min(Math.Max(a, b), c));
        if (median == a)
        {
            return ndx1;
        }
        if (median == b)
        {
            return ndx2;
        }
        return ndx3;
    }

    private int Partition(ref int[][] intervals, int low, int high)
    {
        int pivotIndex = GetMedianIndex(ref intervals, low, high);
        int pivot = intervals[pivotIndex][1];
        Swap(ref intervals, pivotIndex, high);

        int i = low - 1;
        for (int j = low; j < high; j++)
        {
            if (intervals[j][1] < pivot)
            {
                i++;
                Swap(ref intervals, i, j);
            }
        }
        i++;
        Swap(ref intervals, i, high);
        return i;
    }

    private static void Swap(ref int[][] intervals, int i, int j)
    {
        (intervals[j], intervals[i]) = (intervals[i], intervals[j]);
    }

    private static void AltSort<T>(T[][] data, int col)
    {
        Comparer<T> comparer = Comparer<T>.Default;
        Array.Sort<T[]>(data, (x, y) => comparer.Compare(x[col], y[col]));
    }
    public int EraseOverlapIntervals(int[][] intervals)
    {
        AltSort<int>(intervals, 1);
        int count = 0;
        int i = 0;
        for (int j = 1; j < intervals.Length; j++)
        {
            if (intervals[i][1] > intervals[j][0])
            {
                count++;
                continue;
            }
            i = j;
        }
        return count;
    }
}
