namespace LeetCodeSolutions;

public class TribonacciNumber{
    public int Tribonacci(int n){
        int maxN = 37;
        
        int[] fibArr = new int[maxN+1];
        fibArr[0] = 0;
        fibArr[1] = 1;
        fibArr[2] = 1;

        for (int t = 0; t+3 < fibArr.Length; t++){
            fibArr[t+3] = fibArr[t] + fibArr[t+1] + fibArr[t+2];
        }
        return fibArr[n];

    }
}