using System.Globalization;

namespace LeetCodeSolutions;
public class CombinationSumIIISolution
{
    public IList<IList<int>> CombinationSum3(int k, int n)
    {

        //create the first array
        Queue<List<int>> queue = new();
        IList<IList<int>> answer = [];
        for (int digit = 1; digit <= 9; digit++)
        {
            queue.Enqueue(new(digit));
            int count = queue.Count;
            for (int i = 0; i < count; i++)
            {
                List<int> permutation = queue.Dequeue();
                permutation.Add(digit);
                int sum = permutation.Sum();
                if (permutation.Count > k || sum > n)
                {
                    continue;
                }
                else if (permutation.Count == k && sum == n)
                {
                    answer.Add(permutation);
                }
                else
                {
                    queue.Enqueue(permutation);
                }

            }
        }



        return answer;
    }
}
