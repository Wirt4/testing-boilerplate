namespace LeetCodeSolutions;
public class Candies{
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies) {
        int highestBeforeExtra = candies[0];
          int candiesLength = candies.Length;

        for(int i =1; i< candiesLength; i++){
            if(candies[i] > highestBeforeExtra){
                highestBeforeExtra = candies[i];
            }
        }


        bool[] highestIfAdded = new bool[candiesLength];

        for (int j=0; j< candiesLength; j++){
            highestIfAdded[j] = candies[j] + extraCandies >= highestBeforeExtra;
        }

        return highestIfAdded;
    }
}