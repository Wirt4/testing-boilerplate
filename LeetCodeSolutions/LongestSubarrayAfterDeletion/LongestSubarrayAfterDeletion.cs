namespace LeetCodeSolutions;
public class LongestSubarrayAfterDeletion{
    private class Window{
        int[] _nums;
        int _endNdx;
        public Window(int []nums){
            _nums = nums;
            _endNdx = 0;
        }


        public int getNextSpan(){
            int startNdx = _endNdx;

            while(startNdx < _nums.Length && _nums[startNdx] == 0){
                startNdx ++;
            }

            bool noDeletionsMade = true;
            _endNdx = startNdx + 1;

            while(HasNextSpan && (_nums[_endNdx] == 1 || noDeletionsMade)){

                if (_nums[_endNdx] == 0){
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