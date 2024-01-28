using System.Text;
using System.Text.RegularExpressions;

namespace LeetCodeSolutions;
public class DecodeStringSolution {
    public string DecodeString(string s) {
        string pattern = "^[a-zA]*$";

        if (Regex.IsMatch(s,pattern)) return s;

          StringBuilder sb = new();

        if (!Char.IsDigit(s[0])){
            int p = 0;

            while (!Char.IsDigit(s[p])) p++;

            string seg = s[..p];
            sb.Append(seg);
            string sub = s.Substring(p);
            string decoded = DecodeString(sub);
            sb.Append(decoded);
            return sb.ToString();
        }
        
        int l = 0;

        while (l < s.Length){
            int r = l;
            
            while(s[l] != '[') l++;

            int k = int.Parse(s[r..l]);

            while (s[r] != ']') r++;

            l++;
            string segment = s[l..r];

            for (int i=0; i<k; i++) sb.Append(segment);

            l = r + 1;
        }

        return sb.ToString();
    }
}
