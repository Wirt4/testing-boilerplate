using System.Runtime.InteropServices;

namespace LeetCodeSolutions;
public class ArrayProduct
{

   
    public int [] ProductExceptSelf(int [] nums){
        int productOfAll = 0;
        bool containsZeros = false;
        int arrLength = nums.Length;
        int ndx;

        for (ndx = 0; ndx< arrLength; ndx++){
            if (nums[ndx] == 0){
                containsZeros = true;
                continue;
            }
            productOfAll = productOfAll == 0 ? nums[ndx] : productOfAll * nums[ndx];
    
        }

        if (productOfAll == 0){
            for (ndx=0; ndx<arrLength; ndx++){
                nums[ndx] =0;
            }
            return nums;
        }

        if (containsZeros){
            for (ndx = 0; ndx< arrLength; ndx++){

                if (nums[ndx] == 0){
                    nums[ndx] = productOfAll;
                    continue;
                }

                nums[ndx] = 0;
            }

            return nums;
        }


        for (ndx=0; ndx< arrLength; ndx++){
            nums[ndx] = (int) (productOfAll * Math.Pow(nums[ndx], -1));
        }

        return nums;
    }
}