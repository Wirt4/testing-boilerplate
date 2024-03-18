namespace LeetCodeSolutions;
public class BalloonsSolution
{
    private static void SortByColumn<T>(T[][] data, int column)
    {
        Comparer<T> comparer = Comparer<T>.Default;
        Array.Sort<T[]>(data, (x, y) => comparer.Compare(x[column], y[column]));
    }
    public int FindMinArrowShots(int[][] points)
    {
        SortByColumn<int>(points, 1);
        int arrows = 0;
        int i = 0;
        int lastIndex = points.Length - 1;

        while (i < points.Length)
        {
            int j = i + 1;
            if (i == lastIndex || points[i][1] < points[j][0])
            {
                arrows++;
                i++;
                continue;
            }

            while (j < points.Length && points[i][1] >= points[j][0])
            {
                j++;
            }

            arrows++;
            if (j == lastIndex)
            {
                return arrows;
            }
            i = j;

        }
        return arrows;
    }
}
