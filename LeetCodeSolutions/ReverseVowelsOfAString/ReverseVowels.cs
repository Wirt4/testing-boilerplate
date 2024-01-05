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
        int rightNdx =chArray.Length -1;
        while (leftNdx < rightNdx){
            bool leftIsVowell = isVowell(chArray[leftNdx]);
            bool rightIsVowell = isVowell(chArray[rightNdx]);

            if (!leftIsVowell && !rightIsVowell){
                leftNdx++;
                rightNdx--;
            }else if (!leftIsVowell && rightIsVowell){
                leftNdx++;
            }else if (leftIsVowell && !rightIsVowell){
                rightNdx --;
            }else if (leftIsVowell && rightIsVowell){
                swap(ref chArray, leftNdx, rightNdx);
                leftNdx++;
                rightNdx--;
            }
        }
      
        return new string(chArray);
    }
}