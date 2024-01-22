namespace LeetCodeSolutions;
public class PivotSolution{
     public int PivotIndex(int[] nums) {

        if (nums.Length==1){
            return 0;
        }

        int[] leftHandSums = new int[nums.Length];
        int leftHandSum = nums[0];

        for (int i=1; i<nums.Length; i++){
            leftHandSums[i] = leftHandSum;
            leftHandSum += nums[i];
        }

        int[] rightHandSums = new int[nums.Length];
        int rightHandSum = nums[nums.Length -1];

        for (int j = nums.Length - 2; j >=0; j--){
            rightHandSums[j] = rightHandSum;
            rightHandSum += nums[j];


        }

        for (int k =0; k < nums.Length; k++){

            if (leftHandSums[k] == rightHandSums[k]){
                return k;
            }
            
        }

        return -1;
    }
}