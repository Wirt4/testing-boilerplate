namespace LeetCodeSolutions;

public class UniqueNumberOfOccurencesSolution{
    private Dictionary<int, int> createTable (int [] arr){
        Dictionary<int, int> table = [];

        foreach (int v in arr){
            if (table.TryGetValue(v, out int value)){
                table[v] = value + 1;
                continue;
            }

            table.Add(v, 1);
        }

        return table;
    }
    public bool UniqueOccurrences(int[] arr) {
        HashSet<int> set = [];

        foreach (KeyValuePair<int, int> entry in createTable(arr)){
            int frequency = entry.Value;
            if (set.Contains(frequency)) return false;
            set.Add(frequency);
        }
        
        return true;
    }
}