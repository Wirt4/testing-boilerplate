namespace LeetCodeSolutions;
public class Stairs{
     public int MinCostClimbingStairs(int[] cost) {

        int[] minCostFromPosition = new int[cost.Length];
        cost.CopyTo(minCostFromPosition, 0);

        for (int i = cost.Length - 3; i >= 0; i--){
            minCostFromPosition[i] += minCostFromPosition[i+1] > minCostFromPosition[i+2] ? minCostFromPosition[i+2]: minCostFromPosition[i+1];
        }

        return minCostFromPosition[0] < minCostFromPosition[i] ? minCostFromPosition[0]: minCostFromPosition[1];
    }
}