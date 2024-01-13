using System.Collections.Concurrent;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;

namespace LeetCodeSolutions;
public class Temperatures{
    private class TemperatureOnDate{
        private int _daysUntillGreater;
        private int _temperature;
        public TemperatureOnDate(int daysUntillGreater, int temperature){
            this._daysUntillGreater = daysUntillGreater;
            _temperature = temperature;
        }

        public int Temperature => _temperature;
        public int DaysToHigherValue => _daysUntillGreater;
    }
    public int [] DailyTemperatures(int[] temperatures){
        int arrLen = temperatures.Length;

        if (arrLen == 1){
            return [0];
        }

        int[] counts = new int[arrLen];

        Stack<TemperatureOnDate> ascendingTemperatures = new Stack<TemperatureOnDate>();
        int lastIndex = arrLen -1;
        ascendingTemperatures.Push( new TemperatureOnDate (0, temperatures[lastIndex]));
        
        for(int i= lastIndex-1; i>=0; i--){
            int currentTemp = temperatures[i];
            int daysToHigherTemperature = 1;
            
            while (ascendingTemperatures.Count  > 0 && ascendingTemperatures.Peek().Temperature <= currentTemp){
                TemperatureOnDate temp = ascendingTemperatures.Pop();
                daysToHigherTemperature += temp.DaysToHigherValue;
            }

            if (ascendingTemperatures.Count == 0){
                daysToHigherTemperature = 0;
            }

            ascendingTemperatures.Push(new TemperatureOnDate(daysToHigherTemperature, currentTemp));

            counts[i] = daysToHigherTemperature;

        }
        return counts;
    }
}