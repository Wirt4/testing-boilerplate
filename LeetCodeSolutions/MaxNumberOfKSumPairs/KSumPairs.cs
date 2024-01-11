using System.Globalization;
using Microsoft.VisualBasic;

namespace LeetCodeSolutions;

public class KSumPairs{

    private Dictionary<int, int> createFrequencyTable(ref int[] nums){
        Dictionary <int, int> valueFrequency = new Dictionary<int, int>();
        foreach(int num in nums ){
            if (valueFrequency.ContainsKey(num)){
                valueFrequency[num] += 1;
                continue;
            }
            valueFrequency.Add(num, 1);
        }
        return valueFrequency;
    }
    public int MaxOperations(int[] nums, int k){
        Dictionary <int, int> valueFrequency = createFrequencyTable(ref nums);

        int pairs = 0;

        foreach(int x in valueFrequency.Keys){
            if (valueFrequency[x] <=0){
                continue;
            }

            int diff = k-x;

            if (!valueFrequency.ContainsKey(diff) || valueFrequency[diff] <=0){
                continue;
            }

            int min = valueFrequency[x];

            if (valueFrequency[diff] < valueFrequency[x]){
                min = valueFrequency[diff];
            }

            pairs += diff == x ? min / 2 : min;

            valueFrequency[x] -= min;
            valueFrequency[diff] -= min;
        }
        
        return pairs;
    }
}