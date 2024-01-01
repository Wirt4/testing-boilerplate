namespace LeetCodeSolutions;
public class Candies{
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies) {
        int highestBeforeExtra = candies[0];
        int candiesLength = candies.Length;
        int indx;

        for(indx = 1; indx< candiesLength; indx++){
            if(candies[indx] > highestBeforeExtra){
                highestBeforeExtra = candies[indx];
            }
        }


        bool[] highestIfAdded = new bool[candiesLength];

        for (indx = 0; indx< candiesLength; indx++){
            highestIfAdded[indx] = candies[indx] + extraCandies >= highestBeforeExtra;
        }

        return highestIfAdded;
    }
}