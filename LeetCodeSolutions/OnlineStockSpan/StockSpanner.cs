namespace LeetCodeSolutions;

public class StockSpanner {
    private Stack<int> allPrices;
    private int smallest;

    public StockSpanner() {
        allPrices = new Stack<int>();
        smallest = int.MaxValue;
    }
    
    public int Next(int price) {
       
       int count = 0;

       Stack<int> temp = new Stack<int>();
       
       allPrices.Push(price);

        while(allPrices.Count > 0 && allPrices.Peek() <= price){
            count ++;
            temp.Push(allPrices.Pop());
        }

        while(temp.Count > 0){
            allPrices.Push(temp.Pop());
        }

        return count;
    }
}