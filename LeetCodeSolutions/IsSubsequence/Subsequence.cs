using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace LeetCodeSolutions;

public class Subsequence{
    public bool IsSubsequence(string s, string t) {
        int j = 0;
        for (int i = 0; i< t.Length; i++){
            if (j>= s.Length){
                return true;
            }

            if (s[j] == t[i]){
                if (j == s.Length-1){
                    return true;
                }
                j++;
            }
        }
        
        return false;
    }
}