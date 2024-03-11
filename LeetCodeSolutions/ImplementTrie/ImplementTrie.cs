namespace LeetCodeSolutions;


public class Trie
{
    private class TrieNode
    {

        public Dictionary<char, TrieNode> children;
        public bool EndOfWord;
        public TrieNode()
        {
            EndOfWord = false;
            children = [];
        }
    }

    private TrieNode trieRoot;

    public Trie()
    {
        trieRoot = new();
    }
    public void Insert(string word)
    {
        TrieNode cursor = trieRoot;
        foreach (char ch in word)
        {
            if (!cursor.children.ContainsKey(ch))
            {
                cursor.children.Add(ch, new());
            }
            cursor = cursor.children[ch];
        }
        cursor.EndOfWord = true;
    }

    public bool Search(string word)
    {
        TrieNode searchNode = trieRoot;
        foreach (char ch in word)
        {
            if (!searchNode.children.ContainsKey(ch))
            {
                return false;
            }
            searchNode = searchNode.children[ch];
        }

        return searchNode.EndOfWord;
    }

    public bool StartsWith(string prefix)
    {
        TrieNode cursor = trieRoot;
        foreach (char ch in prefix)
        {
            if (!cursor.children.ContainsKey(ch))
            {
                return false;
            }
            cursor = cursor.children[ch];
        }
        return true;
    }
}
