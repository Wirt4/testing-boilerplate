namespace LeetCodeSolutions;
public class NonOverlappingIntervalsSolution
{
    private void Sort(ref int[][] intervals, int low, int high)
    {
        if (low >= high || low < 0)
        {
            return;
        }

        int pivot = Partition(ref intervals, low, high);

        Sort(ref intervals, low, pivot - 1);
        Sort(ref intervals, pivot + 1, high);
    }

    private int GetMedian(ref int[][] intervals, int low, int high)
    {
        Random rand = new();
        int ndx1 = rand.Next(low, high + 1);
        int ndx2 = rand.Next(low, high + 1);
        int ndx3 = rand.Next(low, high + 1);
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
        int pivotIndex = GetMedian(ref intervals, low, high);
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
    public int EraseOverlapIntervals(int[][] intervals)
    {
        Sort(ref intervals, 0, intervals.Length - 1);
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
