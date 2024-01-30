namespace LeetCodeSolutions;
public class RecentCounter {
    private readonly Queue <int> requests;
    private readonly int pastMilisecondLimit = 3000;
    public RecentCounter(){
        requests = new();
    }

    private bool IsOustideRange(int timestamp){
        return requests.Peek() < timestamp - pastMilisecondLimit;
    }

    private void RemoveEntriesOutsideOfRange(int currentTimestamp){
        while (requests.Count > 0 && IsOustideRange(currentTimestamp)){
            requests.Dequeue();
        }


    }
     public int Ping(int timestamp) {
        requests.Enqueue(timestamp);
        RemoveEntriesOutsideOfRange(timestamp);
        return requests.Count;
    }
}
