using System.Diagnostics.CodeAnalysis;

namespace LeetCodeSolutions;

public class MaximumAverageSubarrayI{
   
    private class RangeFinder{
        private int sum;
        private int[] nums;
        private int segmentLength;
        public double Average => 1.0 * sum / segmentLength;
        public RangeFinder(int []nums, int k){
            segmentLength = k;
            this.nums = nums;
            for (int i = 0; i< k; i++){
                sum += nums[i];
            }
        }

        public double windowAverage(int lastNdx){
            sum -= nums[lastNdx - segmentLength];
            sum += nums[lastNdx];
            return Average;
        }
    }


    
     public double FindMaxAverage(int[] nums, int k) {
        RangeFinder rangeFinder = new RangeFinder(nums, k);

        double highestAverage = rangeFinder.Average;
        for(int i = k; i< nums.Length; i++){
            double windowAverage = rangeFinder.windowAverage(i);
            if (windowAverage > highestAverage){
                highestAverage = windowAverage;
            } 
        }
        return highestAverage;
    }
}