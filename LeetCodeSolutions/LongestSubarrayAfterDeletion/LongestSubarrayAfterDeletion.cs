namespace LeetCodeSolutions;
public class LongestSubarrayAfterDeletion{
    private class Window{
        int[] _nums;
        int _endNdx;
        
        public Window(int []nums){
            _nums = nums;
           _endNdx = 0;
            
            while (ValidIndex(_endNdx) && !ValueOfOne(_endNdx)){
                _endNdx++;
            }
        }


        public bool AllZeroes(){

            for (int i=0; i < _nums.Length; i++){
                if (ValueOfOne(i)){
                    return false;
                }
            }

            return true;
        }

        private bool ValueOfOne(int ndx){
            return _nums[ndx] == 1;
        }

        private bool ValidIndex(int ndx){
            return ndx < _nums.Length;
        }

        private bool AllOnes(int ndx, bool noDeletionsMade){
            return _endNdx == _nums.Length && ndx ==0 && noDeletionsMade;
        }

        public int GetNextSpan(){
            int startNdx = _endNdx;

            while(ValidIndex(startNdx) && !ValueOfOne(startNdx)){
                startNdx ++;
            }

            bool noDeletionsMade = true;
            _endNdx = startNdx + 1;
            int temp =-1;

            while(HasNextSpan && (ValueOfOne(_endNdx)|| noDeletionsMade)){
                if (!ValueOfOne(_endNdx)){
                    temp = _endNdx;
                    noDeletionsMade = false;
                } 
              
                _endNdx ++;
            }

            int span =  _endNdx - startNdx;

            if (AllOnes(startNdx, noDeletionsMade)){
                return span -1;
            }

            if (!noDeletionsMade){
                _endNdx = temp;
                return span - 1;
            }

            return span;
        }

        public bool HasNextSpan =>ValidIndex(_endNdx);

    }

     public int LongestSubarray(int[] nums) {
        Window window = new Window(nums);
        int longestSpan = 0;

        if (window.AllZeroes()){
            return 0;
        }

        while (window.HasNextSpan){
            int currentSpan = window.GetNextSpan();
            longestSpan =  currentSpan > longestSpan ? currentSpan : longestSpan;
        }

        return longestSpan;
    }
}