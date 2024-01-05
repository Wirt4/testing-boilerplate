namespace LeetCodeSolutions;
public class FlowerBed{
    
    private void markAndDeprecate(ref int[] flowerbed, long ndx, ref int n){
        flowerbed[ndx] = 1;
        n--;
    }

    private bool isFree(ref int[] flowerbed, long ndx){
        return flowerbed[ndx] == 0;
    }
     public bool CanPlaceFlowers(int[] flowerbed, int n) {

        bool oneFlowerAndFirstFree = n == 1 && isFree(ref flowerbed, 0);

        long len = flowerbed.LongLength;

        if (len== 1){
            return oneFlowerAndFirstFree;
        }
        
        if(len == 2){
            return oneFlowerAndFirstFree && isFree(ref flowerbed, 1);
        }

        for(long i = 0; i<len; i++){

            if (!isFree (ref flowerbed, i)){
                continue;
            }

            if (i == 0){
                if (isFree(ref flowerbed, i+1)){
                    markAndDeprecate(ref flowerbed, i, ref n);
                }
                continue;
            }

            if (i == len - 1){
                if (isFree(ref flowerbed, i-1)){
                    markAndDeprecate(ref flowerbed, i, ref n);
                }
                continue;
            }

            if (isFree(ref flowerbed, i-1) && isFree(ref flowerbed, i+1)){
                markAndDeprecate(ref flowerbed, i, ref n);
            }

        }

        return n <= 0;
    }
}