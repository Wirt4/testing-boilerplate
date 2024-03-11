using System.ComponentModel.Design.Serialization;

namespace LeetCodeSolutions;


public class Trie
{
    private class TrieNode
    {
        public TrieNode?[] children = new TrieNode[26];
        public bool EndOfWord;
        public TrieNode()
        {
            EndOfWord = false;
            for (int i = 0; i < 26; i++)
                children[i] = null;
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
        for (int treeLevel = 0; treeLevel < word.Length; treeLevel++)
        {
            int ndx = word[treeLevel] - 'a';
            if (cursor.children[ndx] == null)
            {
                cursor.children[ndx] = new();
            }
            cursor = cursor.children[ndx];
            if (treeLevel == word.Length - 1)
            {
                cursor.EndOfWord = true;
            }
        }

    }

    public bool Search(string word)
    {
        TrieNode searchNode = trieRoot;
        for (int treeLevel = 0; treeLevel < word.Length; treeLevel++)
        {
            int ndx = word[treeLevel] - 'a';
            if (searchNode.children[ndx] == null)
            {
                return false;
            }
            searchNode = searchNode.children[ndx];
        }
        return searchNode.EndOfWord;
    }

    public bool StartsWith(string prefix)
    {
        return false;
    }
}
