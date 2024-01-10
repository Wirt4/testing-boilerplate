using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Microsoft.VisualBasic;

namespace LeetCodeSolutions;

public class Subsequence{

    private bool InLookupTable(string input, List<int>[] indeces){
        if (input.Length == 0){
            return true;
        }

        int trackingIndex = 0;

        foreach (char ch in input){
            if (indeces[ch]is null){
                return false;
            }

            if (trackingIndex > indeces[ch][indeces[ch].Count -1]){
                return false;
            }

            int  i = 0;
            
            while (trackingIndex >= indeces[ch][i]){
                i++;
                if (i>=indeces[ch].Count){
                    return false;
                }
            }
            trackingIndex = indeces[ch][i];

        }

        return true;
    }
   
    public bool[] IsSubsequence(string[] s, string t){
        // create a Dictionary keyed to chars in t
       List<int> [] indeces =  new List<int>[(int)'z' + 1];
       int i = 0;
       foreach(char ch in t){
        if (indeces[(int)ch] is null){
            indeces[(int)ch] = new List<int>();
        }
        indeces[(int) ch].Add(i);
        i++;
       }

       List<bool> answers = new List<bool>();

       foreach(string input in s){
        answers.Add(InLookupTable(input, indeces));
       }

     return answers.ToArray();
    }
    public bool IsSubsequence(string s, string t) {
        bool[] answer = IsSubsequence([s], t);
        return answer[0];
    }
}