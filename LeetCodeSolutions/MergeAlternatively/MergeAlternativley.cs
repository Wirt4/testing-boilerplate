namespace Project;

public class MergeAlternatively
{
 public string MergeAlternately(string word1, string word2) {
        string merged = "";

        int i = 0;

        while (i < word1.Length && i < word2.Length){
            merged += word1[i];
            merged += word2[i];
            i++;
        }

        if (i < word1.Length){
            merged += word1.Substring(i);
        }

        if (i < word2.Length){
            merged += word2.Substring(i);
        }

        return merged;
    }
}
