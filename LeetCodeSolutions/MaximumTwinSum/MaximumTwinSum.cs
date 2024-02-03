namespace LeetCodeSolutions;
public class MaximumTwinSumSolution
{
    public int PairSum(ListNode head)
    {
        int sum = head.val;
        head = head.next;
        sum += head.val;
        return sum;
    }
}
