using System.Data;

namespace LeetCodeSolutions;

public class HouseRobber{
     public int Rob(int[] nums) {
        if (nums.Length == 1){
            return nums[0];
        }
        int[] dp = new int[nums.Length];
        nums.CopyTo(dp, 0);
        for (int i = nums.Length - 3; i>= 0; i--){

            dp[i] += dp[i+2];
        }
        
        if (dp[0] > dp[1]){
            return dp[0];
        }
        
        return dp[1];
    }
}