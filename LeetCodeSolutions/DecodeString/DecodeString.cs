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
        
        
        if(s[s.Length -1] != ']'){
            int p = s.Length - 1;
            while (s[p-1] != ']') p--;
            string seg = s[..p];
            string sub = s.Substring(p);
            string decoded = DecodeString(seg);
            sb.Append(decoded);
            sb.Append(sub);
            return sb.ToString();

        }

        int l = 0;

        while (l < s.Length){
            int r = l;
            
            while(s[l] != '[') l++;

            int k = int.Parse(s[r..l]);
            r = l;
            int parens = 1;

            do{
                r++;

                if (s[r] == '[') parens++;

                if(s[r] == ']') parens--;

            }while(parens >0); 

            l++;
            string segment = s[l..r];
            string decoded = DecodeString(segment);

            for (int i=0; i<k; i++) sb.Append(decoded);

            l = r + 1;
        }

        return sb.ToString();
    }
}
