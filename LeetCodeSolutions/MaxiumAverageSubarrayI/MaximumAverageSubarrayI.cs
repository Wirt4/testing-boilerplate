namespace LeetCodeSolutions;

public class MaximumAverageSubarrayI{

    private double getAverageFromRange(int []nums, int startNdx, int EndNdx){
        int sum = 0;
        for (int i = startNdx; i < EndNdx; i++){
            sum += nums[i];
        }
        return 1.0 * sum / (EndNdx - startNdx);
    }
     public double FindMaxAverage(int[] nums, int k) {
        double highestAverage = getAverageFromRange(nums, 0, k);
        for (int i = 1; i + k < nums.Length; i++){
            double currentAverage = getAverageFromRange(nums, i, i+k);
            if (currentAverage > highestAverage){
                highestAverage = currentAverage;
            }
        }
        return highestAverage;
    }
}