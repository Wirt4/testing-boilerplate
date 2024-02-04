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

            int twindex = array.Length - 1 - ndex;
            return array[ndex] + array[twindex];
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
