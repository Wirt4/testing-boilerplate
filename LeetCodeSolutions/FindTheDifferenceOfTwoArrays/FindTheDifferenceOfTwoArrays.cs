using System.Collections;

namespace LeetCodeSolutions;
public class FindTheDifferenceOfTwoArraysSolution {
    private ArrayList ANotPresentInB(HashSet<int> setA, HashSet<int> setB){
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
        HashSet<int> setOne = new HashSet<int>(nums1);
        HashSet<int> setTwo = new HashSet<int>(nums2);

        ArrayList answer1 = ANotPresentInB(setOne, setTwo);
        ArrayList answer2 = ANotPresentInB(setTwo, setOne);
    
        IList<IList<int>> foo = [Coerce(answer1), Coerce(answer2)];
        return foo;
    }
}