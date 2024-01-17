using System.ComponentModel.DataAnnotations;

namespace LeetCodeSolutions;
public class LongestSubarrayAfterDeletion{
    private class Window{
        int[] _nums;
        int _endNdx;
        public Window(int []nums){
            _nums = nums;
           initiateEndNdx();
        }

        private void initiateEndNdx(){
            _endNdx = 0;
            
            while (validIndex(_endNdx) && !valueOfOne(_endNdx)){
                _endNdx++;
            }
        }

        public bool AllZeroes(){

            for (int i=0; i < _nums.Length; i++){
                if (valueOfOne(i)){
                    return false;
                }
            }

            return true;
        }

        private bool valueOfOne(int ndx){
            return _nums[ndx] == 1;
        }

        private bool validIndex(int ndx){
            return ndx < _nums.Length;
        }

        public int getNextSpan(){
            int startNdx = _endNdx;

            while(validIndex(startNdx) && !valueOfOne(startNdx)){
                startNdx ++;
            }

            bool noDeletionsMade = true;
            _endNdx = startNdx + 1;
            int temp =-1;

            while(HasNextSpan && (valueOfOne(_endNdx)|| noDeletionsMade)){
                if (!valueOfOne(_endNdx)){
                    temp = _endNdx;
                    noDeletionsMade = false;
                } 
              
                _endNdx ++;
            }

            int span =  _endNdx - startNdx;

            // case is all ones
            if (_endNdx == _nums.Length && startNdx==0 && noDeletionsMade){
                return span -1;
            }

            if (!noDeletionsMade){
                _endNdx = temp;
                 return span - 1;
            }

            return span;
        }

        public bool HasNextSpan =>validIndex(_endNdx);

    }
     public int LongestSubarray(int[] nums) {
        Window window = new Window(nums);
        int longestSpan = 0;

        if (window.AllZeroes()){
            return 0;
        }

        while (window.HasNextSpan){
            int currentSpan = window.getNextSpan();
            if (currentSpan > longestSpan){
                longestSpan = currentSpan;
            }
        }

        return longestSpan;
    }
}