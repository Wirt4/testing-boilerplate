using System.Collections;

namespace LeetCodeSolutions;

public class UniqueNumberOfOccurencesSolution{
    private Dictionary<int, int> frequencyTable (int [] arr){
        Dictionary<int, int> table = new Dictionary<int, int>();

        foreach (int v in arr){
            if (table.ContainsKey(v)){
                int count = (int)table[v];
                count ++;
                table[v] = count;
                continue;
            }

            table.Add(v, 1);
        }

        return table;
    }
    public bool UniqueOccurrences(int[] arr) {
        // create a frequency hashtable
        Dictionary<int, int> freqquencyTable = frequencyTable(arr);
        HashSet<int> frequencies = new HashSet<int>();
        foreach (KeyValuePair<int, int> entry in freqquencyTable){
            if (frequencies.Contains(entry.Value)) return false;
            frequencies.Add(entry.Value);
        }
        
        // if that set contains the frquency, return false

        return true;
    }
}