using System.Collections.Concurrent;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;

namespace LeetCodeSolutions;
public class Temperatures{
    private class TemperatureOnDate{
        private int day;
        private int temperature;
        public TemperatureOnDate(int day, int temperature){
            this.day = day;
            this.temperature = temperature;
        }

        public int Temperature => temperature;
        public int Day => day;
    }
    public int [] DailyTemperatures(int[] temperatures){
        int arrLen = temperatures.Length;
        if (arrLen == 1){
            return [0];
        }

        int[] counts = new int[arrLen];

        Stack<TemperatureOnDate> trackStack = new Stack<TemperatureOnDate>();
        int lastIndex = arrLen -1;
        trackStack.Push( new TemperatureOnDate (lastIndex, temperatures[lastIndex]));
        for(int i= lastIndex-1; i>=0; i--){
            int currentCount =1;
            while (trackStack.Count  > 0 && trackStack.Peek().Temperature <= temperatures[i]){
                TemperatureOnDate temp = trackStack.Pop();
                currentCount += temp.Day;
            }

            if (trackStack.Count ==0){
                currentCount =0;
            }
            trackStack.Push(new TemperatureOnDate(currentCount, temperatures[i]));

            counts[i] = currentCount;

        }
        return counts;
    }
}