namespace LeetCodeSolutions;

public class RemovingStarsFromAStringSolution{

   
        private string _s;
        public StringWrapper(string s){
            _s = s;
        }

        public bool IsValidIndex(int index){
            return index < _s.Length;
        }

        public bool StarAtLocation(int index){
            if (IsValidIndex(index)){
                return _s[index] == '*';
            }

            return false;
        }
    }
     public string RemoveStars(string s) {
        // set up a stack of chars
        Stack<char> nonStars = new();

        foreach (char ch in s){
            if (ch == '*'){
                nonStars.Pop();
                continue;
            }
            nonStars.Push(ch);
        }

        char [] chars = nonStars.ToArray();
        Array.Reverse(chars);
        string starsRemoved = new(chars);
        return starsRemoved;
    }
}