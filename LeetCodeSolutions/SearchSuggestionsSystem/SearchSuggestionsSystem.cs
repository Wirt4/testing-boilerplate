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

        private Node? GetEndOfPrefix(string prefix)
        {
            Node cur = root;
            foreach (char c in prefix)
            {
                if (cur.Children[c] == null)
                {
                    return null;
                }
                cur = cur.Children[c];
            }
            return cur;
        }

        private IList<string> FirstThree(ref PriorityQueue<string, string> pq)
        {
            IList<string> ans = [];
            int i = 0;
            while (pq.Count > 0 && i < 3)
            {
                ans.Add(pq.Dequeue());
                i++;
            }
            return ans;
        }

        private PriorityQueue<string, string> MatchesFromQueues(Stack<string> stringStack, Stack<Node> nodeStack)
        {
            PriorityQueue<string, string> matches = new();
            while (stringStack.Count > 0)
            {
                string curString = stringStack.Pop();
                Node cur = nodeStack.Pop();
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
            return matches;
        }
        public IList<string> Matches(string prefix)
        {
            Node? cur = GetEndOfPrefix(prefix);
            if (cur == null)
            {
                return [];
            }

            Stack<string> stringStack = new();
            Stack<Node> nodeStack = new();
            stringStack.Push(prefix);
            nodeStack.Push(cur);
            PriorityQueue<string, string> matches = MatchesFromQueues(stringStack, nodeStack);
            return FirstThree(ref matches);
        }
    }
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
    {
        SearchTrie searchTrie = new(products);
        IList<IList<string>> answer = [];
        string query = "";
        foreach (char c in searchWord)
        {
            query += c;
            answer.Add(searchTrie.Matches(query));
        }
        return answer;
    }
}
