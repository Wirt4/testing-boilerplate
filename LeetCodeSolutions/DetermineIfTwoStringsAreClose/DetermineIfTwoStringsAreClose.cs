using System.Reflection;

namespace LeetCodeSolutions;

public class CloseStringsSolution{
    private class WordHandler{
        
        private readonly Dictionary<char, int> charFrequency;
        private readonly Dictionary<int, int> countFrequency;
        
        private static Dictionary<char, int> InitiateCharFrequency(string word){
            Dictionary <char, int> frequency = [];
            
            foreach(char ch in word){
                if (frequency.TryGetValue(ch, out int value)){
                    frequency[ch] = value + 1;
                    continue;
                }
                
                frequency.Add(ch, 1);
            }

            return frequency;

        }

        private static Dictionary<int, int> InitiateCountFrequency(Dictionary<char, int>.ValueCollection  charCounts){
                Dictionary <int, int> frequency = [];

                foreach(int count in charCounts){
                
                    if (frequency.TryGetValue(count, out int value)){
                        frequency[count] = value + 1;
                        continue;
                    }

                    frequency.Add(count, 1);
            }

            return frequency;
        }
        public WordHandler (string word){
            charFrequency = InitiateCharFrequency(word);
            countFrequency = InitiateCountFrequency(charFrequency.Values);
        }

        public bool HasSameDistinctChars(WordHandler handler){
            
            foreach (char k in charFrequency.Keys){
                
                if (! handler.charFrequency.ContainsKey(k)){
                    return false;
                }
            }

            return true;
        }

        public bool HasSameCharacterFrequencies(WordHandler handler){
            
            foreach( KeyValuePair<char, int> pair in charFrequency){
                
                if (handler.charFrequency[pair.Key] != pair.Value){
                    return false;
                }
            }

            return true;
        }

       public bool MatchesFrequency(KeyValuePair<int, int> pair){
        if (countFrequency.TryGetValue(pair.Key, out int value)){
            return value == pair.Value;
        }
        
        return false;
       }

        public bool HasSameCountFrequencies(WordHandler handler){
             
             foreach( KeyValuePair<int, int> pair in countFrequency){
               
                if (!handler.MatchesFrequency(pair)){
                    return false;
                }
            }

            return true;
        }

        public int NumberOfDistintChars => charFrequency.Count;

        public int NumberOfDistinctCounts => countFrequency.Count;
    }
   
    public bool CloseStrings(string word1, string word2) {
        
        if (word1 == word2) {
            return true;
        }

        if (word1.Length != word2.Length) {
            return false;
        }

        WordHandler collection1 = new(word1);
        WordHandler collection2 = new(word2);


        if (collection1.NumberOfDistintChars != collection2.NumberOfDistintChars){
            return false;
        }

        if (!collection1.HasSameDistinctChars(collection2)){
            return false;
        }

        if (collection1.HasSameCharacterFrequencies(collection2)){
            return true;
        }

        if (collection1.NumberOfDistinctCounts != collection2.NumberOfDistinctCounts){
            return false;
        }

        return collection1.HasSameCountFrequencies(collection2); 
    }
}