namespace LeetCodeSolutions;

public class Vowels{

    private readonly HashSet<char> vowells = ['a', 'e', 'i', 'o', 'u'];
    private void swap( ref char[] chArray, int leftNdx, int rightNdx){
        char temp = chArray[leftNdx];
        chArray[leftNdx] = chArray[rightNdx];
        chArray[rightNdx] = temp;
    }
    private bool isVowell(char ch){
        return vowells.Contains(ch);
    }
    public string ReverseVowels(string s){
        char[] chArray = s.ToCharArray();
        int leftNdx = 0;
        int rightNdx = chArray.Length -1;

        while (leftNdx < rightNdx){
            bool leftIsVowell = isVowell(chArray[leftNdx]);
            bool rightIsVowell = isVowell(chArray[rightNdx]);
            if (leftIsVowell && rightIsVowell){
                 swap(ref chArray, leftNdx, rightNdx);
                leftNdx++;
                rightNdx--;
                continue;
            }

            if (!leftIsVowell){
                leftNdx++;
            }

            if (!rightIsVowell){
                rightNdx--;
            }

        }
      
        return new string(chArray);
    }
}