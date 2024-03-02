namespace LeetCodeSolutions;
public class LetterCombinationOfPhoneNumberSolution
{
    public IList<string> LetterCombinations(string digits)
    {
        if (digits.Length == 0)
        {
            return [];
        }
        Dictionary<string, string[]> numberKey = new()
        {
            ["2"] = ["a", "b", "c"],
            ["3"] = ["d", "e", "f"],
            ["4"] = ["g", "h", "i"],
            ["5"] = ["j", "k", "l"],
            ["6"] = ["m", "n", "o"],
            ["7"] = ["p", "q", "r", "s"],
            ["8"] = ["t", "u", "v"],
            ["9"] = ["w", "x", "y", "z"]
        };
        return numberKey[digits];
    }
}
