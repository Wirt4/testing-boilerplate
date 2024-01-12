namespace LeetCodeSolutions;

public class StockSpanner {
    private int smallest;

    public StockSpanner() {
        smallest = int.MaxValue;
    }
    
    public int Next(int price) {
        if ( price < smallest){
            smallest = price;
            return 1;
        }
        return 2;
    }
}