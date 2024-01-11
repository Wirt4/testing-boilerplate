using System.Globalization;

namespace LeetCodeSolutions;

public class KSumPairs{
    public int MaxOperations(int[] nums, int k){
        Dictionary <int, int> valueFrequency = new Dictionary<int, int>();

        foreach(int num in nums ){
            if (valueFrequency.ContainsKey(num)){
                valueFrequency[num] += 1;
                continue;
            }
            valueFrequency.Add(num, 1);
        }

        int pairs = 0;

        foreach(int x in nums){
            int diff = k-x;
            if (!valueFrequency.ContainsKey(diff)){
                continue;
            }

            int min = valueFrequency[x];

            if (valueFrequency[diff]< valueFrequency[x]){
                min = valueFrequency[diff];
            }

            if (diff == x){
                pairs += min/2;
            }else{
                  pairs += min;
            }

            if (valueFrequency[x] - min == 0){
                valueFrequency.Remove(x);
            }else{
                valueFrequency[x] -= min;
            }
          
          if (valueFrequency.ContainsKey(diff)){
             if (valueFrequency[diff] - min == 0){
                valueFrequency.Remove(diff);
                }else{
                valueFrequency[diff] -= min;
                }
            }
        }
        return pairs;
    }
}