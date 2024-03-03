namespace LeetCodeSolutions;
public class CombinationSumIIISolution
{
    public IList<IList<int>> CombinationSum3(int k, int n)
    {
        Queue<List<int>> queue = new();
        IList<IList<int>> answer = [];
        for (int digit = 1; digit <= 9; digit++)
        {
            queue.Enqueue([digit]);
            int count = queue.Count;
            for (int i = 0; i < count; i++)
            {
                List<int> permutation = queue.Dequeue();
                int sum = permutation.Sum();
                if (sum == n && permutation.Count == k)
                {
                    answer.Add(permutation);
                    continue;
                }
                if (sum < n && permutation.Count < k)
                {
                    for (int j = permutation[permutation.Count - 1] + 1; j <= 9; j++)
                    {
                        List<int> permutationCopy = new(permutation);
                        permutationCopy.Add(j);
                        queue.Enqueue(permutationCopy);
                    }
                }
            }
        }
        return answer;
    }
}
