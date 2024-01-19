using System.Runtime.InteropServices;

namespace LeetCodeSolutions;

public class MaxConsecutiveOnes{
    private class Window{
        private int _startNdx;
        private int _endNdx;
        private int[] _binaryArr;
        
        public Window(int[] binaryArr){
            _binaryArr = binaryArr;
            _startNdx = 0;
            _endNdx = 0;
        }

        private void moveToFirstNonValue (ref int ndx, int value){
            while(ndx < _binaryArr.Length && _binaryArr[ndx] == value){
                ndx++;
            }
        }

        public int GetAdjustedSpan(int fippableZeroes){
            int extendedNdx = _endNdx;

            while (fippableZeroes > 0 && extendedNdx < _binaryArr.Length ){
                if (_binaryArr[extendedNdx] == 0){
                    fippableZeroes--;
                }
                extendedNdx++;
            }

            moveToFirstNonValue(ref extendedNdx, 1);

            return extendedNdx - _startNdx;
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
        Window window = new Window(nums);
        int longestOnes = window.GetAdjustedSpan(k);
        int cur;

        while (window.HasRemainingOnes){
            window.Shift();
            cur = window.GetAdjustedSpan(k);

            if (cur > longestOnes){
                longestOnes = cur;
            }

        }

        window.Reverse();

        do{
            cur = window.GetAdjustedSpan(k);

            if (cur > longestOnes){
                longestOnes = cur;
            }

            window.Shift();
        }while(window.HasRemainingOnes);

        return longestOnes;
    }
}