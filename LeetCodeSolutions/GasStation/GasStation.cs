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
        Stack<Trip> Trips = InitiateTrips(gas.Length);
        while (Trips.Count > 0)
        {
            Trip current = Trips.Pop();
            if (current.MakeTrip(gas, cost))
            {
                if (current.Traversed)
                {
                    return current.Index;
                }
                Trips.Push(current);
            }
        }
        return -1;
    }
}
