namespace LeetCodeSolutions;
public class BalloonsSolution
{
    public int FindMinArrowShots(int[][] points)
    {
        int arrows = points.Length;
        for (int i = 1; i < points.Length; i++)
        {
            if (points[i][0] < points[i - 1][1])
            {
                arrows--;
            }
        }
        return arrows;
    }
}
