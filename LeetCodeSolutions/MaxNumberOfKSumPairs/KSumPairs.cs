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

        foreach(int num in nums){
            int diff = k-num;
            if (!valueFrequency.ContainsKey(diff) || valueFrequency[diff] <=0){
                continue;
            }

            int min = valueFrequency[num];

            if (valueFrequency[diff]< valueFrequency[num]){
                min = valueFrequency[diff];
            }

            if (valueFrequency[diff] ==valueFrequency[min]){
                pairs += min/2;
            }else{
                  pairs += min;
            }

            valueFrequency[num] -= min;
            valueFrequency[diff] -= min;


        }
        return pairs;
    }
}