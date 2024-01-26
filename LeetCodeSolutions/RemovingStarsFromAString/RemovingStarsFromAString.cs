namespace LeetCodeSolutions;

public class RemovingStarsFromAStringSolution{
     public string RemoveStars(string s) {
        // set up a stack of chars
        Stack<char> nonStars = new();
        int ndx = 0;
        while (ndx < s.Length){
            while (ndx < s.Length && s[ndx] == '*'){
                nonStars.Pop();
                ndx ++;
            }
            if (ndx < s.Length) nonStars.Push(s[ndx]);
            ndx++;
        }
        char [] chars = nonStars.ToArray();
        Array.Reverse(chars);
        string starsRemoved = new(chars);
        return starsRemoved;
    }
}