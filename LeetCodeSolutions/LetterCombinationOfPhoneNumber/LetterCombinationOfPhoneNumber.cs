using System.ComponentModel.Design.Serialization;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace LeetCodeSolutions;
public class LetterCombinationOfPhoneNumberSolution
{
    public IList<string> LetterCombinations(string digits)
    {
        if (digits.Length == 0)
        {
            return [];
        }

        Dictionary<char, char[]> numberKey = new()
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

        Queue<string> perms = new();

        foreach (char ch in numberKey[digits[0]])
        {
            perms.Enqueue(ch.ToString());
        }

        for (int i = 1; i < digits.Length; i++)
        {
            int count = perms.Count;
            for (int j = 0; j < count; j++)
            {
                string cur = perms.Dequeue();
                foreach (char ch in numberKey[digits[i]])
                {
                    perms.Enqueue(cur + ch.ToString());
                }
            }
        }






        return [.. perms];
    }




}
