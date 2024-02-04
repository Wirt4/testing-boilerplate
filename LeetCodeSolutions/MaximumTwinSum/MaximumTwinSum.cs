namespace LeetCodeSolutions;
public class MaximumTwinSumSolution
{
    private int getCount(ListNode head)
    {
        int count = 0;
        while (head != null)
        {
            count++;
            head = head.next;
        }

        return count;
    }
    private int[] ListToArray(ListNode head)
    {
        if (head == null)
        {
            return [];
        }
        int length = getCount(head);
        int[] returnArr = new int[length];
        int ndx = 0;
        while (head != null)
        {
            returnArr[ndx] = head.val;
            ndx++;
            head = head.next;
        }
        return returnArr;
    }

    private int sumFromTwin(int ndex, int[] arr)
    {
        if (ndex >= 0 && ndex <= (arr.Length / 2) - 1)
        {
            int twindex = arr.Length - 1 - ndex;
            return arr[ndex] + arr[twindex];
        }
        return -1;
    }

    public int PairSum(ListNode head)
    {
        int[] arr = ListToArray(head);
        int sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            int currentSum = sumFromTwin(i, arr);
            if (currentSum > sum)
            {
                sum = currentSum;
            }

        }
        return sum;
    }
}
