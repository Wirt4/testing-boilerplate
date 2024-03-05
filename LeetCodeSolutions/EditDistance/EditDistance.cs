namespace LeetCodeSolutions;
public class EditDistanceSolution
{
    public int MinDistance(string word1, string word2)
    {
        return word1 == word2 ? 0 : 1;
    }
}
