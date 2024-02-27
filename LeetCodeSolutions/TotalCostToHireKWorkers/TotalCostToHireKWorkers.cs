
namespace LeetCodeSolutions;
public class TotalCostToHireKWorkersSolution
{
    public long TotalCost(int[] costs, int hiringQuota, int selectionRange)
    {
        long total = 0;
        int frontIndex = 0;
        int backIndex = costs.Length - 1;
        PriorityQueue<int, int> leftPool = new();
        PriorityQueue<int, int> rightPool = new();

        for (int i = 0; i < selectionRange; i++)
        {
            leftPool.Enqueue(costs[frontIndex], costs[frontIndex]);
            rightPool.Enqueue(costs[backIndex], costs[backIndex]);
            frontIndex++;
            backIndex--;
        }

        for (int i = 0; i < hiringQuota; i++)
        {
            if (leftPool.Peek() <= rightPool.Peek())
            {
                total += leftPool.Dequeue();
                leftPool.Enqueue(costs[frontIndex], costs[frontIndex]);
                frontIndex++;
            }
            else
            {
                total += rightPool.Dequeue();
                rightPool.Enqueue(costs[backIndex], costs[backIndex]);
                backIndex--;
            }
        }

        return total;
    }
}
