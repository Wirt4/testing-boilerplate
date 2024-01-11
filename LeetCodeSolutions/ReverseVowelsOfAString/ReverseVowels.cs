namespace LeetCodeSolutions;


public class Vowels{

    private readonly HashSet<char> vowells = ['a', 'e', 'i', 'o', 'u', 'A','E', 'I','O','U'];

    private bool isVowell(char ch){
        return vowells.Contains(ch);
    }
    
     private void swap( ref char[] chArray, int leftNdx, int rightNdx){
        char temp = chArray[leftNdx];
        chArray[leftNdx] = chArray[rightNdx];
        chArray[rightNdx] = temp;
    }

    private bool hasVowells(ref string s){

        foreach(char ch in s){
            if (isVowell(ch)){
                return true;
            }
        }

        return false;
    }

    public string ReverseVowels(string s){
        int arrLength = s.Length;

        if (arrLength <= 1 || !hasVowells(ref s)){
            return s;
        }

        char[] chArray = s.ToCharArray();
        int leftNdx = 0;
        int rightNdx = arrLength -1;

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