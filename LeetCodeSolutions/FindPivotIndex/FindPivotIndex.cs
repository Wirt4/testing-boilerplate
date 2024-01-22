using System.Drawing;

namespace LeetCodeSolutions;
public class PivotSolution{
    private class NumSums{
        private readonly int size;
        private int leftSum;
        private int rightSum;
        private readonly int[] leftSums;
        private readonly int[] rightSums;
        private int [] InitializeArray(){
            return new int[size];
        }
        public NumSums(ref int[] nums){
            size = nums.Length;
            leftSum = nums[0];
            rightSum = nums[LastIndex];
            leftSums = InitializeArray();
            rightSums = InitializeArray();
        }

        public int Size => size;
        public int LastIndex => size - 1;

        public void SetLeft(int index, int numValue){
            leftSums[index] = leftSum;
            leftSum += numValue;
        }

        public void SetRight(int index, int numValue){
            rightSums[index] = rightSum;
            rightSum += numValue;
        }

        public bool LeftSumEqualsRightSum(int index){
            return leftSums[index] == rightSums[index];
        }
    }
     public int PivotIndex(int[] nums) {
        NumSums numSum = new NumSums(ref nums);
        for (int i = 1; i< numSum.Size; i++){
            int j = numSum.LastIndex - i;
            numSum.SetLeft(i, nums[i]);
            numSum.SetRight(j, nums[j]);
        }

        for (int k = 0; k< numSum.Size; k++){
            if (numSum.LeftSumEqualsRightSum(k))return k;
        }

        return -1;
    }
}