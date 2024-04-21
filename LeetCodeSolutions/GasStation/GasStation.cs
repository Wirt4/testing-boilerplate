namespace LeetCodeSolutions;
public class GasStationSolution
{
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        return gas[0] == cost[0] ? 0 : -1;
    }
}
