using System.Collections;

namespace LeetCodeSolutions;
public class FindTheDifferenceOfTwoArraysSolution {
    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2) {
        HashSet<int> setOne = new HashSet<int>(nums1);
        HashSet<int> setTwo = new HashSet<int>(nums2);

        ArrayList answer1 = new ArrayList();
        foreach(int num in setOne){
            if (setTwo.Contains(num)) continue;
            answer1.Add(num);
        }

        ArrayList answer2 = new ArrayList();

        foreach(int num in setTwo){
            if (setOne.Contains(num)) continue;
            answer2.Add(num);
        }

        IList<IList<int>> foo = [(int [])answer1.ToArray(typeof(int)),(int [])answer2.ToArray(typeof(int))];
        return foo;
    }
}