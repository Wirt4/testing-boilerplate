namespace LeetCodeSolutions;

public class TribonacciNumber{
    private int[] TribonacciArray(int maxValue = 37){
        int[] tribArr = new int[maxValue + 1];
        for (int i =1; i<= 2 && i<= maxValue; i++){
            tribArr[i] = 1;
        }
        return tribArr;
    }
  
    public int Tribonacci(int n){
        
        int[] fibArr = TribonacciArray(n);

        for (int t = 0; t+3 < fibArr.Length; t++){
            fibArr[t+3] = fibArr[t] + fibArr[t+1] + fibArr[t+2];
        }

        return fibArr[n];

    }
}