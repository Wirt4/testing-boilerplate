using System.Security.AccessControl;

namespace LeetCodeSolutions;
public class FindPeakElementSolution
{
    private class IndexPair(int start, int range)
    {
        public int start = start;
        public int range = range;
    }

    private bool GreaterThanLeft(int ndx, ref int[] arr)
    {
        return arr[ndx] > arr[ndx - 1];
    }

    private bool GreaterThanRight(int ndx, ref int[] arr)
    {
        return arr[ndx] > arr[ndx + 1];
    }
    public int FindPeakElement(int[] nums)
    {
        if (nums.Length == 1) { return 0; }

        Stack<IndexPair> stack = new();
        IndexPair cursor = new(0, nums.Length);
        stack.Push(cursor);
        int mid = -1;
        while (stack.Count > 0)
        {
            cursor = stack.Pop();
            if (cursor.start >= cursor.range) { continue; }
            mid = (cursor.start + cursor.range) / 2;


            if (mid == 0 && GreaterThanRight(mid, ref nums)) { break; }

            if (mid == nums.Length - 1 && GreaterThanLeft(mid, ref nums)) { break; }

            if (GreaterThanLeft(mid, ref nums) && GreaterThanRight(mid, ref nums)) { break; }

            stack.Push(new(cursor.start, mid));
            stack.Push(new(cursor.start, mid));
        }
        return mid;

    }
}
