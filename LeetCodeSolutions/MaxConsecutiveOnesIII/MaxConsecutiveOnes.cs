namespace LeetCodeSolutions;

public class MaxConsecutiveOnes{
    private class Window{
        private int _startNdx;
        private int _endNdx;
        private int[] _binaryArr;
        private int _flippableZeroes;
        private int _longestOnes;
        
        public Window(int[] binaryArr, int fippableZeroes){
            _binaryArr = binaryArr;
            _startNdx = 0;
            _endNdx = 0;
            _longestOnes = 0;
            _flippableZeroes = fippableZeroes;
        }

        private void moveToFirstNonValue (ref int ndx, int value){
            while(ndx < _binaryArr.Length && _binaryArr[ndx] == value){
                ndx++;
            }
        }

        public int GetHighestSpan(){
            int k = _flippableZeroes;
            int extendedNdx = _endNdx;

            while (k > 0 && extendedNdx < _binaryArr.Length ){

                if (_binaryArr[extendedNdx] == 0){
                    k--;
                }

                extendedNdx++;
            }

            moveToFirstNonValue(ref extendedNdx, 1);

            int span = extendedNdx - _startNdx;

            if (span > _longestOnes){
                _longestOnes =  span;
            }

            return _longestOnes;
        }

        public bool HasRemainingOnes => _endNdx < _binaryArr.Length;

        private void _Shift(int startNdx){
            _startNdx = startNdx;
            _endNdx = _startNdx;
            moveToFirstNonValue(ref _endNdx, 1);
        }
        
        public void Shift(){
            _Shift(_endNdx +1);
        }

        public void Reverse(){
            Array.Reverse(_binaryArr);
            int startNdx = 0;
            moveToFirstNonValue(ref startNdx, 0);
            _Shift(startNdx);
        }


    }

     public int LongestOnes(int[] nums, int k) {
        Window window = new Window(nums, k);
        int longestOnes = window.GetHighestSpan();

        while (window.HasRemainingOnes){
            window.Shift();
            longestOnes = window.GetHighestSpan();
         
        }

        window.Reverse();

        do{
            longestOnes = window.GetHighestSpan();
            window.Shift();
        }while(window.HasRemainingOnes);

        return longestOnes;
    }
}