using System.Collections;
using System.Globalization;
using System.Runtime.InteropServices;

namespace LeetCodeSolutions;
public class TripletSubsequence{
        
   public bool IncreasingTriplet(int[] nums){
    int smallestVal= int.MaxValue;
    int secondSmallestVal = int.MaxValue;
    foreach(int num in nums){
        if (num <= smallestVal){
            smallestVal = num;
            continue;
        }

        if (num<=secondSmallestVal){
            secondSmallestVal = num;
            continue;
        }

        if (num> secondSmallestVal){
            return true;
        }
    }

    return false;
   }
}