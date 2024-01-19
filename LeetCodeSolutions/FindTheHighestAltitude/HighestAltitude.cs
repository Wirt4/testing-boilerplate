using System.Data;

namespace LeetCodeSolutions;
public class HighestAltitude{
     public int LargestAltitude(int[] gain) {
        int currentAltitude = 0;
        int highestAltitude = currentAltitude;

        foreach(int slope in gain ){
            currentAltitude += slope;
            if (currentAltitude > highestAltitude){
                highestAltitude = currentAltitude;
            }
        }

        return highestAltitude;
    }
}