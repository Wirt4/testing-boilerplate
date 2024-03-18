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
        while (i < points.Length)
        {
            if (i == points.Length - 1 || points[i][1] < points[i + 1][0])
            {
                arrows++;
                i++;
                continue;
            }

            int j = i + 1;
            while (j < points.Length && points[i][1] >= points[j][0])
            {
                j++;
            }
            arrows++;
            if (j == points.Length - 1)
            {
                break;
            }
            i = j;

        }
        return arrows;
    }
}
