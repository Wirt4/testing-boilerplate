using System.Runtime.InteropServices;

namespace LeetCodeSolutions;
public class ArrayProduct
{

   private class ArrayProcessor{
    private int indexOfZero;
    private bool allZeroes;
    private int productOfAll;

    public ArrayProcessor(int [] nums, int numsLength){
        indexOfZero = -1;
        allZeroes = false;
        productOfAll = 0;

        for (int i=0; i< numsLength; i++){

            if(nums[i] == 0){
                if (indexOfZero>=0){
                    allZeroes = true;
                    break;
                }
                indexOfZero = i;
                continue;
            }

            if (productOfAll == 0){
                productOfAll = nums[i];
                continue;
            }

            productOfAll *= nums[i];


        }

    }
    public bool ContainsOneZero{
        get{ return !allZeroes && indexOfZero>=0;}
    }

    public bool AllZeroes{
        get{ return allZeroes;}
    }

    public int IndexOfZero{
        get {return indexOfZero;}
    }

    public int ProductOfAll{
        get {return productOfAll;}
    }

    public int DivideBy(int num){
         return (int) (productOfAll * Math.Pow(num, -1));
    }


   }
    public int [] ProductExceptSelf(int [] nums){
        int arrLength = nums.Length;
        int ndx;

        ArrayProcessor arrPross = new ArrayProcessor(nums, arrLength);

        if (arrPross.AllZeroes){
            return new int[arrLength];
        }

        if (arrPross.ContainsOneZero){
            nums = new int[arrLength];
            nums[arrPross.IndexOfZero] = arrPross.ProductOfAll;
            return nums;

        }


        for (ndx=0; ndx< arrLength; ndx++){
            nums[ndx] = arrPross.DivideBy(nums[ndx]);
        }

        return nums;
    }
}