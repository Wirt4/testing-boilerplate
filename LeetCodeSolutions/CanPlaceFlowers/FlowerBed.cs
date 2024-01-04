namespace LeetCodeSolutions;
public class FlowerBed{
     public bool CanPlaceFlowers(int[] flowerbed, int n) {
        

        if (flowerbed.Length == 1){
            return flowerbed[0] == 0;
        }

        return n == 1;
    }
}