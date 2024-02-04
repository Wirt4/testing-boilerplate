using System.Collections;

namespace LeetCodeSolutions;
public class MaximumTwinSumSolution
{


    private class ListWrapper
    {
        private readonly int[] array;
        public int Size => array.Length;
        public ListWrapper(ListNode head)
        {
            array = ListToArray(head);
        }

        public int SumFromTwin(int ndex)
        {
            if (ndex < 0 || ndex > (array.Length / 2) - 1)
            {
                return -1;
            }

            return array[ndex] + array[array.Length - 1 - ndex];
        }

        private static int[] ListToArray(ListNode head)
        {
            List<int> arrList = new();

            while (head != null)
            {
                arrList.Add(head.val);
                head = head.next;
            }

            return [.. arrList];
        }
    }

    public int PairSum(ListNode head)
    {
        ListWrapper wrapper = new(head);
        int sum = 0;
        for (int i = 0; i < wrapper.Size / 2; i++)
        {
            int currentSum = wrapper.SumFromTwin(i);
            if (currentSum > sum)
            {
                sum = currentSum;
            }

        }
        return sum;
    }
}
