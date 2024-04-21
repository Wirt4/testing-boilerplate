namespace LeetCodeSolutions;
public class GasStationSolution
{
    private class Trip(int startingIndex)
    {
        private int currentIndex = startingIndex;
        private int tank = 0;
        private readonly int startingIndex = startingIndex;
        public int Index
        {
            get => currentIndex;
        }
        public bool Traversed
        {
            get => currentIndex == startingIndex;
        }
        public bool MakeTrip(int[] gas, int[] cost)
        {
            int nextIndex = (currentIndex + 1) % gas.Length;
            tank += gas[currentIndex];
            if (tank < cost[nextIndex])
            {
                return false;
            }
            tank -= cost[currentIndex];
            currentIndex = nextIndex;
            return true;
        }
    }

    private Stack<Trip> InitiateTrips(int arrLen)
    {
        Stack<Trip> Trips = new Stack<Trip>();
        for (int i = 0; i < arrLen; i++)
        {
            Trips.Push(new Trip(i));
        }
        return Trips;
    }
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        int current = 0;
        int total = 0;
        int diff;
        int start = 0;
        for (int i = 0; i < gas.Length; i++)
        {
            diff = gas[i] - cost[i];
            total += diff;
            current += diff;
            if (current < 0)
            {
                start = i + 1;
                current = 0;
            }
        }
        if (total < 0)
        {
            return -1;
        }

        return start;
    }
}
