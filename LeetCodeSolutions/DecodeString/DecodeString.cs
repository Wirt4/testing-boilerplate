using System.Text;

namespace LeetCodeSolutions;
public class DecodeStringSolution {
    private static bool EditingRequired(string inputString){
        foreach(char character in inputString){
            if (inputString.Equals('[') || inputString.Equals(']') || Char.IsDigit(character)) return true;
        }
        return false;
    }

    public string DecodeString(string inputString) {
        if (!EditingRequired(inputString)) return inputString;

        StringBuilder returnStringBuilder = new();

        string suffix = "";

        if(inputString[^1] != ']'){
            int endBracketIndex = inputString.Length - 1;
            while (inputString[endBracketIndex-1] != ']') endBracketIndex--;

            suffix = inputString.Substring(endBracketIndex);
            inputString = inputString[..endBracketIndex];
        }

        int leftIndex = 0;

        while (leftIndex < inputString.Length){
            int rightIndex = leftIndex;

            while (!Char.IsDigit(inputString[rightIndex])){
                returnStringBuilder.Append(inputString[rightIndex]);
                rightIndex++;
            }
            
            while(inputString[leftIndex] != '[') leftIndex++;

            int k = int.Parse(inputString[rightIndex..leftIndex]);
            rightIndex = leftIndex;
            int parens = 1;

            do{
                rightIndex++;

                if (inputString[rightIndex] == '[') parens++;

                if(inputString[rightIndex] == ']') parens--;

            }while(parens > 0); 

            leftIndex++;
            string segment = inputString[leftIndex..rightIndex];
            string decoded = DecodeString(segment);

            for (int i=0; i<k; i++) returnStringBuilder.Append(decoded);

            leftIndex = rightIndex + 1;
        }

        returnStringBuilder.Append(suffix);

        return returnStringBuilder.ToString();
    }
}
