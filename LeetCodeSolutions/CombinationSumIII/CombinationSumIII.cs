namespace LeetCodeSolutions;
public class CombinationSumIIISolution
{
    private class CombinationParser
    {
        private Queue<List<int>> queue;
        private IList<IList<int>> answer;
        private int endRange;
        private int startRange;
        private int k;
        private int n;
        public CombinationParser(int k, int n)
        {
            this.k = k;
            this.n = n;
            queue = new();
            answer = [];
            endRange = 9;
            startRange = 1;
        }

        public void AddToQueue(int digit)
        {
            queue.Enqueue([digit]);
        }

        public int CurrentQueueCount => queue.Count;
        public int StartIndex => startRange;
        public int EndIndex => endRange;
        public IList<IList<int>> Answer => answer;

        public void ProccessPermutation()
        {
            List<int> permutation = queue.Dequeue();
            int sum = permutation.Sum();
            if (sum == n && permutation.Count == k)
            {
                answer.Add(permutation);
                return;
            }

            if (sum < n && permutation.Count < k)
            {
                EnqueueAdjacents(permutation);
            }
        }

        private void EnqueueAdjacents(List<int> permutation)
        {
            for (int j = permutation[^1] + 1; j <= endRange; j++)
            {
                List<int> permutationCopy = new(permutation);
                permutationCopy.Add(j);
                queue.Enqueue(permutationCopy);
            }
        }

    }
    public IList<IList<int>> CombinationSum3(int k, int n)
    {
        CombinationParser parser = new(k, n);

        for (int digit = parser.StartIndex; digit <= parser.EndIndex; digit++)
        {
            parser.AddToQueue(digit);
            int count = parser.CurrentQueueCount;
            for (int i = 0; i < count; i++)
            {
                parser.ProccessPermutation();
            }
        }

        return parser.Answer;
    }
}
