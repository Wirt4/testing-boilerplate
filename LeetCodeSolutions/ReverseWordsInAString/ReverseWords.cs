using System.Text;

namespace LeetCodeSolutions;

public class ReverseWordsSolution{
     public string ReverseWords(string s) {
        char space = ' ';
        string [] words = s.Trim().Split(space);


        int wordsLength = words.Length;
        if (wordsLength == 1){
            return words[0];
        }

        StringBuilder builder = new StringBuilder(s.Length);
        
        for(int i = wordsLength - 1; i >= 0; i--){
            if (!String.IsNullOrEmpty(words[i])){
                builder.Append(words[i]);
                if (i > 0){
                       builder.Append(space);
                }
            }
        }


        return builder.ToString();
    }
}