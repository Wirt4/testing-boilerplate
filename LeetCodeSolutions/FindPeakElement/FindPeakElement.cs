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
        if (ndx == 0)
        {
            return true;
        }

        return arr[ndx] > arr[ndx - 1];
    }

    private bool GreaterThanRight(int ndx, ref int[] arr)
    {
        if (ndx == arr.Length - 1)
        {
            return true;
        }

        return arr[ndx] > arr[ndx + 1];
    }
    public int FindPeakElement(int[] nums)
    {
        Stack<IndexPair> stack = new();
        IndexPair cursor = new(0, nums.Length);
        stack.Push(cursor);
        int mid;
        while (stack.Count > 0)
        {
            cursor = stack.Pop();
            if (cursor.start >= cursor.range) { continue; }
            mid = (cursor.start + cursor.range) / 2;

            if (GreaterThanLeft(mid, ref nums) && GreaterThanRight(mid, ref nums))
            {
                return mid;
            }

            stack.Push(new(cursor.start, mid));
            stack.Push(new(cursor.start, mid));
        }

        return -1;
    }
}
