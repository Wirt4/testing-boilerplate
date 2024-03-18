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
        int lastIndex = points.Length - 1;

        while (i < points.Length)
        {
            if (i == lastIndex || !Overlaps(ref points, i, i + 1))
            {
                arrows++;
                i++;
                continue;
            }

            i = AdvancePastOverlappingBalloons(ref points, i);
            arrows++;


        }
        return arrows;
    }
}
