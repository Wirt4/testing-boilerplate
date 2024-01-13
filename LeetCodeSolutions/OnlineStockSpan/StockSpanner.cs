namespace LeetCodeSolutions;

public class StockSpanner {
    private Stack<int> priceRecord;
    private Stack<int> secondStack;

    public StockSpanner() {
        priceRecord = new Stack<int>();
        secondStack = new Stack<int>();
    }
    
    public int Next(int price) {
       priceRecord.Push(price);

       if (priceRecord.Count == 1){
        return 1;
       } 
        int count = 0;

        while(priceRecord.Count > 0 && priceRecord.Peek() <= price){
            count ++;
            secondStack.Push(priceRecord.Pop());
        }

        while(secondStack.Count > 0){
            priceRecord.Push(secondStack.Pop());
        }

        return count;
    }
}