namespace LeetCodeSolutions;
public class SearchSuggestionsSystemSolution
{
    private class Node
    {
        public bool StringEnd;
        public Node[] Children;
        public Node()
        {
            StringEnd = false;
            Children = new Node['z' + 1];
            Array.Fill(Children, null);
        }
    }
    public class SearchTrie
    {
        private readonly Node root;
        public SearchTrie(string[] products)
        {
            root = new();
            InsertAll(products);
        }

        public void InsertAll(string[] products)
        {
            foreach (string product in products)
            {
                Insert(product);
            }
        }
        private void Insert(string word)
        {
            Node cur = root;
            foreach (char c in word)
            {
                if (cur.Children[c] == null)
                {
                    cur.Children[c] = new();
                }
                cur = cur.Children[c];
            }
            cur.StringEnd = true;
        }
        public IList<string> Matches(string prefix)
        {
            PriorityQueue<string, string> matches = new();
            Node cur = root;
            foreach (char c in prefix)
            {
                if (cur.Children[c] == null)
                {
                    return [];
                }
                cur = cur.Children[c];
            }
            Stack<string> stringStack = new();
            Stack<Node> nodeStack = new();
            stringStack.Push(prefix);
            nodeStack.Push(cur);
            while (stringStack.Count > 0)
            {
                string curString = stringStack.Pop();
                cur = nodeStack.Pop();
                if (cur.StringEnd)
                {
                    matches.Enqueue(curString, curString);
                }
                for (char c = 'a'; c <= 'z'; c++)
                {
                    if (cur.Children[c] != null)
                    {
                        stringStack.Push(curString + c);
                        nodeStack.Push(cur.Children[c]);
                    }
                }
            }
            IList<string> answer = [];
            int i = 0;
            while (matches.Count > 0 && i < 3)
            {
                answer.Add(matches.Dequeue());
                i++;
            }
            return answer;
        }
    }
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
    {
        SearchTrie searchTrie = new(products);
        IList<IList<string>> answer = [];
        string query = "";
        for (int i = 0; i < searchWord.Length; i++)
        {
            query += searchWord[i];
            answer.Add(searchTrie.Matches(query));
        }
        return answer;
    }
}
