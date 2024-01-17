using System.Runtime.InteropServices;

namespace LeetCodeSolutions;

public class MaxConsecutiveOnes{
    private class Window{
        private int _startNdx;
        private int _endNdx;
        private int[] _binaryArr;
        public Window(int[] binaryArr){
            _startNdx = 0;
            _endNdx = _startNdx;
            while (_endNdx < binaryArr.Length && binaryArr[_endNdx]==1){
                _endNdx++;
            }

            _binaryArr = binaryArr;
        }
        public int GetAdjustedSpan(int fippableZeroes){
            int extendedNdx = _endNdx;
            while (fippableZeroes > 0 && extendedNdx < _binaryArr.Length ){
                if (_binaryArr[extendedNdx] == 0){
                    fippableZeroes--;
                }
                extendedNdx++;
            }
            return extendedNdx - _startNdx;
        }

        public bool HasRemainingOnes => _endNdx < _binaryArr.Length;

        /// <summary>
        ///  shifts the window state to the right
        /// </summary>
        public void Shift(){

            _startNdx = _endNdx + 1;
            _endNdx = _startNdx;

             while (_endNdx < _binaryArr.Length && _binaryArr[_endNdx]==1){
                _endNdx++;
            }


        }


    }
     public int LongestOnes(int[] nums, int k) {
        Window window = new Window(nums);

        int longestOnes = window.GetAdjustedSpan(k);

        while (window.HasRemainingOnes){
            window.Shift();
            int cur = window.GetAdjustedSpan(k);

            if (cur > longestOnes){
                longestOnes = cur;
            }

        }

        return longestOnes;
    }
}