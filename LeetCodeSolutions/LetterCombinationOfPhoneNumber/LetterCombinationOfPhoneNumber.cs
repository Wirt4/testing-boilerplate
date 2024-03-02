namespace LeetCodeSolutions;
public class LetterCombinationOfPhoneNumberSolution
{

    private readonly Dictionary<char, char[]> characterValuesToNumbers = new()
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

    private void AddPermutations(char number, ref Queue<string> permutations)
    {
        foreach (char ch in characterValuesToNumbers[number])
        {
            permutations.Enqueue(ch.ToString());
        }
    }

    private void AddConcactedPermutations(string exisingPermutation, char number, ref Queue<string> permutations)
    {
        foreach (char ch in characterValuesToNumbers[number])
        {
            permutations.Enqueue(exisingPermutation + ch.ToString());
        }
    }
    public IList<string> LetterCombinations(string digits)
    {
        if (digits.Length == 0)
        {
            return [];
        }

        Queue<string> permutations = new();
        AddPermutations(digits[0], ref permutations);

        for (int i = 1; i < digits.Length; i++)
        {
            int count = permutations.Count;
            for (int j = 0; j < count; j++)
            {
                string currentPermutation = permutations.Dequeue();
                AddConcactedPermutations(currentPermutation, digits[i], ref permutations);
            }
        }

        return [.. permutations];
    }
}
