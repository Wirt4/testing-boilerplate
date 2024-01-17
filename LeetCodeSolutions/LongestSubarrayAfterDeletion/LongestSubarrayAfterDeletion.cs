namespace LeetCodeSolutions;
public class LongestSubarrayAfterDeletion{
    private class Window{
        int[] _nums;
        int _endNdx;
        public Window(int []nums){
            _nums = nums;
            _endNdx = 0;
        }

        private bool valueOfOne(int ndx){
            return _nums[ndx] == 1;
        }

        public int getNextSpan(){
            int startNdx = _endNdx;

            while(startNdx < _nums.Length && !valueOfOne(startNdx)){
                startNdx ++;
            }

            bool noDeletionsMade = true;
            _endNdx = startNdx + 1;

            while(HasNextSpan && (valueOfOne(_endNdx)|| noDeletionsMade)){

                if (!valueOfOne(_endNdx)){
                    noDeletionsMade = false;
                }

                _endNdx ++;
            }

            return _endNdx - startNdx - 1;
        }

        public bool HasNextSpan => _endNdx < _nums.Length;
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