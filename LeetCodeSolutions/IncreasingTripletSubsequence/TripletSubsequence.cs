using System.Globalization;

namespace LeetCodeSolutions;
public class TripletSubsequence{

    /**
    The antithesis of finding out if a sequence is stricly descending, it returns the breaking case
    */
    private int increasingPair(int startNdx, ref int[] nums, int numLength){
        int last = nums[startNdx];
        for (int i = startNdx +1; i< numLength; i++){
            if (nums[i] > last){
                return i;
            }
            last = nums[i];
        }
        return -1;
    }
   public bool IncreasingTriplet(int[] nums){
        int numLength = nums.Length;
        if (numLength < 3){
            return false;
        }

        int pairIndex =  increasingPair(0, ref nums, numLength);
        if (pairIndex <0){
            return false;
        }

        int tripletIndex = increasingPair(pairIndex, ref nums, numLength);
       
       return tripletIndex > 0;

   }
}