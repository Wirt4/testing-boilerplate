namespace LeetCodeSolutions;
public class GasStationSolution
{
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        int tank = 0;
        int totalGas = 0;
        int startingIndex = 0;
        int diff;

        for (int i = 0; i < gas.Length; i++)
        {
            diff = gas[i] - cost[i];
            totalGas += diff;
            tank += diff;

            if (tank < 0)
            {
                startingIndex = i + 1;
                tank = 0;
            }
        }

        return totalGas < 0 ? -1 : startingIndex;
    }
}
