namespace LeetCodeSolutions;

public class RemovingStarsFromAStringSolution{
    private class StackWrapper{
        private Stack<char> stack;
        public StackWrapper(){
            stack = new();
        }
        public void Pop(){
            if (stack.Count > 0) stack.Pop();
        }

        public void Push(char ch){
            stack.Push(ch);
        }

        public string AsString(){
            char[] chars = [.. stack];
            Array.Reverse(chars);
            return new string(chars);
        }
    }
 public string RemoveStars(string s) {
    StackWrapper noStars = new StackWrapper();
    foreach(char ch in s){
        if (ch == '*'){
            noStars.Pop();
            continue;
        }

        noStars.Push(ch);
    }

    return noStars.AsString();  
    }
       

}