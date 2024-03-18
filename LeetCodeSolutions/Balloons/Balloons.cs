namespace LeetCodeSolutions;
public class BalloonsSolution
{
    private static void SortByColumn<T>(T[][] data, int column)
    {
        Comparer<T> comparer = Comparer<T>.Default;
        Array.Sort<T[]>(data, (x, y) => comparer.Compare(x[column], y[column]));
    }

    private static bool Overlaps(ref int[][] points, int i, int j)
    {
        return points[i][1] >= points[j][0];
    }

    private static int AdvancePastOverlappingBalloons(ref int[][] points, int i)
    {
        int j = i + 1;
        while (j < points.Length && Overlaps(ref points, i, j))
        {
            j++;
        }
        return j;

    }
    public int FindMinArrowShots(int[][] points)
    {
        SortByColumn<int>(points, 1);
        int arrows = 0;
        int i = 0;

        while (i < points.Length)
        {
            int j = i + 1;
            while (j < points.Length && Overlaps(ref points, i, j))
            {
                j++;
            }
            i = j;
            arrows++;
        }

        return arrows;
    }
}
