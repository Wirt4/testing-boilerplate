using System.Text.RegularExpressions;

namespace LeetCodeSolutions;
public class DecodeStringSolution {
    public string DecodeString(string s) {
        string pattern = "^[a-zA]*$";
        if (Regex.IsMatch(s,pattern)){
            return s;
        }
        return "tttt";
    }
}
