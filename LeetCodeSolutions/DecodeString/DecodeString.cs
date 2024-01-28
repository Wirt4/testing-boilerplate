using System.Text;

namespace LeetCodeSolutions;
public class DecodeStringSolution {
    private static bool EditingRequired(string inputString){
        foreach(char character in inputString){
            if (inputString.Equals('[') || inputString.Equals(']') || Char.IsDigit(character)) {
                return true;
                }
        }

        return false;
    }

    private class StringIndexer(string inputString)
    {
        public int leftIndex = 0;
        public int rightIndex = 0;
        private string encodedString = inputString;

        public void FindEncasingBrackets(){
            int levelsOfParenthesis = 1;

             do{
                rightIndex++;

                if (encodedString[rightIndex] == '['){
                    levelsOfParenthesis++;
                }

                if(encodedString[rightIndex] == ']'){
                    levelsOfParenthesis--;
                }

            }while(levelsOfParenthesis > 0); 
        }

        public void AdvanceRightIndexToLeftIndexPosition(){
            rightIndex =  leftIndex;
        }

        public void AdvanceLeftIndexToOpeningBracket(){
            while(encodedString[leftIndex] != '['){
                IncrementLeftIndex();
            };
        }

        public void IncrementLeftIndex(){
            leftIndex++;
        }

        public bool RightIndexPointsToDigit(){
           return  Char.IsDigit(encodedString[rightIndex]);
        }

        public string RetrieveSegment(){
            AdvanceRightIndexToLeftIndexPosition();
            FindEncasingBrackets();
            IncrementLeftIndex();
            return encodedString[leftIndex..rightIndex];
        }

        public int ParseMultiplier(){
            AdvanceLeftIndexToOpeningBracket();
            return int.Parse(encodedString[rightIndex..leftIndex]);
        }

        public void SetIndecesForNextIteration(){
            leftIndex = rightIndex;
            IncrementLeftIndex();
        }

        public bool HasRemainingChars(){
            return leftIndex < encodedString.Length;
        }
    }

    private class StringDecoder{
        private StringBuilder builder;
        private string suffix;
        private bool hasSuffix;
        public StringDecoder(){
            builder = new();
            hasSuffix = false;
            suffix = "";
        }

        public string TrimSuffix(string inputString){
            if (inputString[^1] == ']'){
                return inputString;
            }

            int closingBracketIndex = FindClosingBracketIndex(inputString);
            hasSuffix = true;
            suffix = inputString[closingBracketIndex..];
            return inputString[..closingBracketIndex];
        }

        private void AppendCharacer(ref string inputString, ref StringIndexer indeces){
            builder.Append(inputString[indeces.rightIndex]);
            indeces.rightIndex++;
        }

        public void AppendLeadingChars(ref string inputString, ref StringIndexer indeces){
            while (!indeces.RightIndexPointsToDigit()){
                AppendCharacer(ref inputString, ref indeces);
            }
        }

        public void AppendMultipleStrings(string segment, int numberOfTimes){
            for (int i=0; i<numberOfTimes; i++) {
                builder.Append(segment);
            }
        }
        public string OutputString(){
            if (hasSuffix){
                 builder.Append(suffix);
            }

            return builder.ToString();
        }

        private int FindClosingBracketIndex(string inputString){
            int closingBracketIndex = inputString.Length - 1;

            while (inputString[closingBracketIndex-1] != ']'){
                    closingBracketIndex--;
            }

        return closingBracketIndex;
        }
    }


    public string DecodeString(string inputString) {
        if (!EditingRequired(inputString)){
            return inputString;
        }
    
        StringDecoder decoder = new();
        inputString = decoder.TrimSuffix(inputString);
        StringIndexer parser = new(inputString);

        while (parser.HasRemainingChars()){
            parser.AdvanceRightIndexToLeftIndexPosition();
            decoder.AppendLeadingChars(ref inputString, ref parser);
            int k = parser.ParseMultiplier();
            string segment = parser.RetrieveSegment();
            string decoded = DecodeString(segment);
            decoder.AppendMultipleStrings(decoded, k);
            parser.SetIndecesForNextIteration();
        }

        return decoder.OutputString();
    }
}
