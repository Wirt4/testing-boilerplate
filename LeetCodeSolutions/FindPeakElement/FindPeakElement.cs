namespace LeetCodeSolutions;
public class FindPeakElementSolution
{
    private int BinarySearch(ref int[] nums, int i, int j)
    {
        if (i >= j)
        {
            return -1;
        }
        int m = (i + j) / 2;
        if ((m == 0 && nums[m + 1] < nums[m]) || (m == j - 1 && nums[m - 1] < nums[m]) || (nums[m - 1] < nums[m] && nums[m + 1] < nums[m]))
        {
            return m;
        }
        int left = BinarySearch(ref nums, i, m);
        if (left >= 0)
        {
            return left;
        }

        return BinarySearch(ref nums, m + 1, j);
    }
    public int FindPeakElement(int[] nums)
    {
        if (nums.Length == 1) { return 0; }

        //return BinarySearch(ref nums, 0, nums.Length);
        Stack<(int start, int end)> stack = new();
        stack.Push((0, nums.Length));
        while (stack.Count > 0)
        {
            (int start, int end) current = stack.Pop();
            if (current.start >= current.end) { continue; }
            int mid = (current.start + current.end) / 2;
            if (mid == 0 && nums[mid + 1] < nums[mid])
            {
                return mid;
            }
            if (mid == nums.Length - 1 && nums[mid - 1] < nums[mid])
            {
                return mid;
            }

            if (nums[mid - 1] < nums[mid] && nums[mid + 1] < nums[mid])
            {
                return mid;
            }
            (int start, int end) left = (current.start, mid);
            (int start, int end) right = (mid + 1, current.end);
            stack.Push(left);
            stack.Push(right);


        }
        return -1;

    }
}
