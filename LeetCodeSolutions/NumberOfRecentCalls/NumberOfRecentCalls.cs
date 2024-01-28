namespace LeetCodeSolutions;
public class RecentCounter {
    private Queue <int> requests;
    public RecentCounter(){
        requests = new();
    }
     public int Ping(int t) {
        requests.Enqueue(t);
        return requests.Count;
    }
}
