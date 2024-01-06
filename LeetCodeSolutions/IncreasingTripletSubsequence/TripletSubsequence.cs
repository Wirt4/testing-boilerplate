using System.Globalization;

namespace LeetCodeSolutions;
public class TripletSubsequence{
   public bool IncreasingTriplet(int[] nums){
        if (nums.Length < 3){
            return false;
        }
        int i=0;
        int j=1;
        int k=2;

        while (k< nums.Length){
            if(nums[i]< nums[j] && nums[j] < nums[k]){
                return true;
            }
            i++;
            j++;
            k++;
        }

        return false;
   }
}