namespace LeetCodeSolutions;
public class Stairs{
    private int minFromIndex(int ndx, ref int[] positionalCost){
        if (positionalCost[ndx] < positionalCost[ndx+1]){
            return positionalCost[ndx];
        }
        return positionalCost[ndx +1];
    }
     public int MinCostClimbingStairs(int[] cost) {

        int[] minCostFromPosition = new int[cost.Length];
        cost.CopyTo(minCostFromPosition, 0);

        for (int i = cost.Length - 3; i >= 0; i--){
            minCostFromPosition[i] += minFromIndex(i+1, ref minCostFromPosition);
        }

        return minFromIndex(0, ref minCostFromPosition);
    }
}