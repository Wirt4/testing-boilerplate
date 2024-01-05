namespace LeetCodeSolutions;

public class Vowels{
    private void swap( ref char[] chArray, int leftNdx, int rightNdx){
        char temp = chArray[leftNdx];
        chArray[leftNdx] = chArray[rightNdx];
        chArray[rightNdx] = temp;
    }
    private bool isVowell(char ch){
        return ch == 'a' || ch =='i'|| ch =='o' || ch == 'u' || ch =='e';
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