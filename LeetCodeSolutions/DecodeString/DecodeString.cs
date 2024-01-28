using System.Text;

namespace LeetCodeSolutions;
public class DecodeStringSolution {
    private static bool EditingRequired(string s){
        foreach(char ch in s){
            if (s.Equals('[') || s.Equals(']') || Char.IsDigit(ch)) return true;
        }
        return false;
    }
    public string DecodeString(string s) {
        if (!EditingRequired(s)) return s;

        StringBuilder sb = new();

        string suffix = "";

        if(s[^1] != ']'){
            int p = s.Length - 1;
            while (s[p-1] != ']') p--;

            suffix = s.Substring(p);
            s = s[..p];
        }

        int l = 0;

        while (l < s.Length){
            int r = l;

            while (!Char.IsDigit(s[r])){
                sb.Append(s[r]);
                r++;
            }
            
            while(s[l] != '[') l++;

            int k = int.Parse(s[r..l]);
            r = l;
            int parens = 1;

            do{
                r++;

                if (s[r] == '[') parens++;

                if(s[r] == ']') parens--;

            }while(parens > 0); 

            l++;
            string segment = s[l..r];
            string decoded = DecodeString(segment);

            for (int i=0; i<k; i++) sb.Append(decoded);

            l = r + 1;
        }

        sb.Append(suffix);

        return sb.ToString();
    }
}
