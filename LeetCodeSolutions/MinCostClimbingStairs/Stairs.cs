namespace LeetCodeSolutions;
public class Stairs{
     public int MinCostClimbingStairs(int[] cost) {
        int[] minCostFromPosition = new int[cost.Length];
        for (int i = cost.Length -1; i >=0; i--){
            if (i >= cost.Length -2){
                minCostFromPosition[i] = cost[i];
                continue;
            }
            
            if (minCostFromPosition[i+1] < minCostFromPosition[i+2]){
                minCostFromPosition[i] = cost[i] + minCostFromPosition[i+1];
                continue;
            }

             minCostFromPosition[i] = cost[i] + minCostFromPosition[i+2];

        }

        if (minCostFromPosition[0] < minCostFromPosition[1]){
            return minCostFromPosition[0];
        }

        return minCostFromPosition[1];
    }
}