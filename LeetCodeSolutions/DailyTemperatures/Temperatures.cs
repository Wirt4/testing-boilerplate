namespace LeetCodeSolutions;
public class Temperatures{
    public int [] DailyTemperatures(int[] temperatures){
    int [] counts = new int[temperatures.Length];

    for (int i=0; i< temperatures.Length; i++){
        int numDays=0;
        for (int j = i+1; j < temperatures.Length; j++){
            if (temperatures[j] > temperatures[i]){
                numDays = j-i;
                break;
            }
        }
        counts[i] = numDays;
        }

        return counts;
    }
}