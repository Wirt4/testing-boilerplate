namespace LeetCodeSolutions;
public class LetterCombinationOfPhoneNumberSolution
{
    private class QueueWrapper
    {
        private readonly Dictionary<char, char[]> characterValuesToNumbers;
        public Queue<string> permutations;
        public QueueWrapper()
        {
            permutations = new();
            characterValuesToNumbers = new()
            {
                ['2'] = ['a', 'b', 'c'],
                ['3'] = ['d', 'e', 'f'],
                ['4'] = ['g', 'h', 'i'],
                ['5'] = ['j', 'k', 'l'],
                ['6'] = ['m', 'n', 'o'],
                ['7'] = ['p', 'q', 'r', 's'],
                ['8'] = ['t', 'u', 'v'],
                ['9'] = ['w', 'x', 'y', 'z']
            };


        }

        public void AddPermutations(char digit)
        {
            char[] characters = characterValuesToNumbers[digit];

            if (permutations.Count == 0)
            {
                foreach (char ch in characters)
                {
                    permutations.Enqueue(ch.ToString());
                }
                return;
            }

            int count = permutations.Count;

            for (int i = 0; i < count; i++)
            {
                string prefix = permutations.Dequeue();
                foreach (char ch in characters)
                {
                    permutations.Enqueue(prefix + ch.ToString());
                }
            }
        }
    }
    public IList<string> LetterCombinations(string digits)
    {
        if (digits.Length == 0)
        {
            return [];
        }

        QueueWrapper queueWrapper = new();

        foreach (char digit in digits)
        {
            queueWrapper.AddPermutations(digit);
        }

        return [.. queueWrapper.permutations];
    }
}
