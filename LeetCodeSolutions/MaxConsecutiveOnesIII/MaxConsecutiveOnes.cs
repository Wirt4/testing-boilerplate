using System.Runtime.InteropServices;

namespace LeetCodeSolutions;

public class MaxConsecutiveOnes{
    private class Window{
        private int _startNdx;
        private int _endNdx;
        private int[] _binaryArr;
        public Window(int[] binaryArr){
            _binaryArr = binaryArr;
            int startNdx = 0;
            moveToFirstNonValue(ref startNdx, 0);
            _Shift(startNdx);
        }

        private void moveToFirstNonValue (ref int ndx, int value){
            while(ndx < _binaryArr.Length && _binaryArr[ndx] == value){
                ndx++;
            }
        }
        /// <summary>
        /// measures the longest span of ones, provided up to a set amount of Zeroes may be flipped
        /// </summary>
        /// <param name="fippableZeroes"></param>
        /// <returns></returns>
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
/// <summary>
/// indicates if another window shift is possible
/// </summary>
        public bool HasRemainingOnes => _endNdx < _binaryArr.Length;

        private void _Shift(int startNdx){
            _startNdx = startNdx;
            _endNdx = _startNdx;
            moveToFirstNonValue(ref _endNdx, 1);
        }

        /// <summary>
        ///  shifts the window state to the right
        /// </summary>
        public void Shift(){
            _Shift(_endNdx +1);
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