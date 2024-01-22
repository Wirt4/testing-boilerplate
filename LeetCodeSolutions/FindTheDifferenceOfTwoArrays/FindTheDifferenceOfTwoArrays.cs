using System.Collections;

namespace LeetCodeSolutions;
public class FindTheDifferenceOfTwoArraysSolution {
    private ArrayList ANotInB(HashSet<int> setA, HashSet<int> setB){
        ArrayList answer = new ArrayList();

        foreach(int num in setA){
            if (setB.Contains(num)) continue;
            answer.Add(num);
        }
        
        return answer;
    }

    private int[] Coerce(ArrayList list){
        return (int [])list.ToArray(typeof(int));
    }
    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2) {
        HashSet<int> set1 = new (nums1);
        HashSet<int> set2 = new(nums2);

        ArrayList answer1 = ANotInB(set1, set2);
        ArrayList answer2 = ANotInB(set2, set1);
    
        return [Coerce(answer1), Coerce(answer2)];
    }
}