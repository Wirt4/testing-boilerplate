namespace LeetCodeSolutions;
public class FlowerBed{
    
    private void markAndDeprecate(ref int[] flowerbed, int ndx, ref int n){
        flowerbed[ndx] = 1;
        n--;
    }

    private bool isFree(ref int[] flowerbed, int ndx){
        return flowerbed[ndx] == 0;
    }
     public bool CanPlaceFlowers(int[] flowerbed, int n) {

        bool oneFlowerAndFirstFree = n == 1 && isFree(ref flowerbed, 0);
        
        if (flowerbed.Length == 1){
            return oneFlowerAndFirstFree;
        }
        
        if(flowerbed.Length == 2){
            return oneFlowerAndFirstFree && isFree(ref flowerbed, 1);
        }

        for(int i = 0; i<flowerbed.Length; i++){

            if (!isFree (ref flowerbed, i)){
                continue;
            }

            if (i == 0){
                if (isFree(ref flowerbed, i+1)){
                    markAndDeprecate(ref flowerbed, i, ref n);
                }
                continue;
            }

            if (i == flowerbed.Length - 1){
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