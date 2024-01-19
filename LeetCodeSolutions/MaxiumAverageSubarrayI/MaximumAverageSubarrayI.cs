using System.Diagnostics.CodeAnalysis;

namespace LeetCodeSolutions;

public class MaximumAverageSubarrayI{
   
    private class SpanWindow{
        private int sum;
        private int[] nums;
        private int segmentLength;
        
        public SpanWindow(int []nums, int k){
            segmentLength = k;
            this.nums = nums;
            for (int i = 0; i< k; i++){
                sum += nums[i];
            }
        }

        public double Average => 1.0 * sum / segmentLength;

        public double windowAverage(int endNdx){
            sum -= nums[endNdx - segmentLength];
            sum += nums[endNdx];
            return Average;
        }
    }


    
     public double FindMaxAverage(int[] nums, int k) {
        SpanWindow window = new SpanWindow(nums, k);

        double highestAverage = window.Average;

        for(int i = k; i< nums.Length; i++){
            double windowAverage = window.windowAverage(i);
            if (windowAverage > highestAverage){
                highestAverage = windowAverage;
            } 
        }

        return highestAverage;
    }
}