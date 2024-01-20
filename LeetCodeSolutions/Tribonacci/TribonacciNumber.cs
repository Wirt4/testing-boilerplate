namespace LeetCodeSolutions;

public class TribonacciNumber{

    private class TribonacciTracker{
        private readonly int[] _tribArr;

        public TribonacciTracker(int maxValue){
            _tribArr = new int[maxValue + 1];

            for (int i =1; i<= 2 && i<= maxValue; i++){
                Set(i, 1);
            }
        }

        public void Set(int nthNumber, int tribonacciValue){
            _tribArr[nthNumber] = tribonacciValue;
        }

        public int Get(int nthNumber){
            return _tribArr[nthNumber];
        }

        public int SumOfLastThree(int nthNumber){
            int sum =0;

            for (int i = 1; i<=3; i++){
                sum += Get(nthNumber -i);
            }

            return sum;
        }
    }
  
    public int Tribonacci(int n){
        TribonacciTracker Tribs = new TribonacciTracker(n);

        for (int t = 3; t <= n; t++){
            Tribs.Set(t,  Tribs.SumOfLastThree(t));
        }

        return Tribs.Get(n);
    }
}