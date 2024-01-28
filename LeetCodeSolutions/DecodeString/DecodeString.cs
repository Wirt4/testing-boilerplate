using System.Text;
using System.Text.RegularExpressions;

namespace LeetCodeSolutions;
public class DecodeStringSolution {
    public string DecodeString(string s) {
        string pattern = "^[a-zA]*$";

        if (Regex.IsMatch(s,pattern)) return s;
        
        int l = 0;

        while(s[l] != '[') l++;

        int k = int.Parse(s[..l]);
        int r = l;

        while (s[r] != ']') r++;

        StringBuilder sb = new();
        l++;
        string segment = s[l..r];

        for (int i=0; i<k; i++) sb.Append(segment);
        
        return sb.ToString();
    }
}
