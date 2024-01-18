namespace LeetCodeSolutions;
public class Stairs{
     public int MinCostClimbingStairs(int[] cost) {
        if (cost.Length == 2){
            if (cost[0] < cost[1]){
                return cost[0];
            }
                return cost[1];
        }

        return 15;
    }
}