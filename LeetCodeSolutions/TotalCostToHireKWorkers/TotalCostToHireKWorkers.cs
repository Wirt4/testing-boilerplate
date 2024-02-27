
namespace LeetCodeSolutions;
public class TotalCostToHireKWorkersSolution
{
    public long TotalCost(int[] costs, int k, int n)
    {
        long total = 0;
        int i = 0;
        int j = costs.Length - 1;
        PriorityQueue<int, int> leftSet = new();

        while (i < n)
        {
            leftSet.Enqueue(costs[i], costs[i]);
            i++;
        }

        PriorityQueue<int, int> rightSet = new();

        while (j >= i && j > costs.Length - 1 - n)
        {
            rightSet.Enqueue(costs[j], costs[j]);
            j--;
        }

        for (int m = 0; m < k; m++)
        {
            if (leftSet.Count == 0 && rightSet.Count == 0)
            {
                break;
            }

            if (leftSet.Count == 0 && rightSet.Count > 0)
            {
                total += rightSet.Dequeue();

                if (i <= j)
                {
                    rightSet.Enqueue(costs[j], costs[j]);
                    j--;
                }
                continue;
            }
            if (leftSet.Count > 0 && rightSet.Count == 0)
            {
                total += leftSet.Dequeue();

                if (i <= j)
                {
                    leftSet.Enqueue(costs[i], costs[i]);
                    i++;
                }
                continue;
            }
            if (leftSet.Count > 0 && rightSet.Count > 0)
            {
                if (leftSet.Peek() <= rightSet.Peek())
                {
                    total += leftSet.Dequeue();

                    if (i <= j)
                    {
                        leftSet.Enqueue(costs[i], costs[i]);
                        i++;
                    }
                    continue;
                }

                total += rightSet.Dequeue();
                if (i <= j)
                {
                    rightSet.Enqueue(costs[j], costs[j]);
                    j--;
                }

            }
        }

        return total;
    }
}
