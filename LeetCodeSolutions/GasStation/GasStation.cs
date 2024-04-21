namespace LeetCodeSolutions;
public class GasStationSolution
{
    private class Trip
    {
        public Trip(int startingIndex)
        {
            currentIndex = startingIndex;
            this.startingIndex = startingIndex;
            tank = 0;
        }
        private int currentIndex;
        private int tank;
        private int startingIndex;
        public int Index
        {
            get => currentIndex;
        }
        public bool Traversed
        {
            get => currentIndex == startingIndex;
        }
        public void MakeTrip(int[] gas, int[] cost)
        {
            int nextIndex = (currentIndex + 1) % gas.Length;
            tank += gas[currentIndex];
            if (tank < cost[nextIndex])
            {
                throw new Exception("trip not possible");
            }
            tank -= cost[currentIndex];
            currentIndex = nextIndex;
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
            try
            {
                current.MakeTrip(gas, cost);
            }
            catch
            {
                continue;
            }
            if (current.Traversed)
            {
                return current.Index;
            }
            Trips.Push(current);
        }
        return -1;
    }
}
