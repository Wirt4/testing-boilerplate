namespace LeetCodeSolutions;
public class LongestSubarrayAfterDeletion{
    private class Window{
        int[] _nums;
        int _endNdx;
        public Window(int []nums){
            _nums = nums;
            _endNdx = 0;
            
            while (validIndex(_endNdx) && !valueOfOne(_endNdx)){
                _endNdx++;
            }
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

            while(HasNextSpan && (valueOfOne(_endNdx)|| noDeletionsMade)){
                noDeletionsMade = noDeletionsMade && valueOfOne(_endNdx);
                _endNdx ++;
            }
            // case is all ones
            if (_endNdx == _nums.Length && startNdx==0 && noDeletionsMade){
                return _nums.Length -1;
            }

            if (!noDeletionsMade){
                 return _endNdx - startNdx - 1;
            }

            return _endNdx - startNdx;
        }

        public bool HasNextSpan =>validIndex(_endNdx);
    }
     public int LongestSubarray(int[] nums) {
        Window window = new Window(nums);
        int longestSpan = 0;

        while (window.HasNextSpan){
            int currentSpan = window.getNextSpan();
            if (currentSpan > longestSpan){
                longestSpan = currentSpan;
            }
        }

        return longestSpan;
    }
}