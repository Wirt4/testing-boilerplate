using Microsoft.VisualBasic;

namespace LeetCodeSolutions;

public class CloseStringsSolution{
    private Dictionary<char, int> CreateFrequencyTable(string word){
        Dictionary<char, int> table =[];
        
        foreach(char ch in word){

            if (table.TryGetValue(ch, out int value)){
                table[ch] = value + 1;
                continue;
            }

            table.Add(ch, 1);
        }

        return table;
    }

    Dictionary<int, int> FrequencyOfCounts(Dictionary<char, int> table){
        Dictionary<int, int> newTable =[];

        foreach(int d in table.Values){

            if (newTable.TryGetValue(d, out int value)){
                newTable[d] = value + 1;
                continue;
            }

            newTable.Add(d, 1);
        }

        return newTable;
    }
   
    public bool CloseStrings(string word1, string word2) {
        if (word1 == word2) return true;
        if (word1.Length != word2.Length) return false;

        Dictionary<char, int> table1 = CreateFrequencyTable(word1);
        Dictionary<char, int> table2 = CreateFrequencyTable(word2);

        if (table1.Count != table2.Count) return false;

        bool matchingCounts = true;
        foreach(KeyValuePair<char, int> pair in table1){
            if (!table2.ContainsKey(pair.Key)) return false;
            matchingCounts = matchingCounts && table2[pair.Key] == pair.Value;
        }

        if (matchingCounts) return true;

        Dictionary<int, int> charCounts1 = FrequencyOfCounts(table1);
        Dictionary<int, int> charCounts2 = FrequencyOfCounts(table2);

        if (charCounts1.Count != charCounts2.Count) return false;

        foreach (KeyValuePair<int, int> pair in charCounts1){
            if (!charCounts2.TryGetValue(pair.Key, out int value)) return false;
            if (value != pair.Value) return false;
        }


        return true;
        


        
    }
}