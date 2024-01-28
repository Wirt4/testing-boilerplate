namespace LeetCodeSolutions;

public class CloseStringsSolution{
    private class WordHandler{
        
        private readonly Dictionary<char, int> charFrequency;
        private readonly Dictionary<int, int> countFrequency;
        
        public WordHandler (string word){
            charFrequency = [];
            
            foreach(char ch in word){
                if (charFrequency.TryGetValue(ch, out int value)){
                    charFrequency[ch] = value + 1;
                    continue;
                }
                
                charFrequency.Add(ch, 1);
            }

            countFrequency = [];
            
            foreach(int count in charFrequency.Values){
                
                if (countFrequency.TryGetValue(count, out int value)){
                    countFrequency[count] = value + 1;
                    continue;
                
                }
                countFrequency.Add(count, 1);
            }
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

        public int NumberOfDistintChars => charFrequency.Count;

        public int NumberOfDistinctCounts => countFrequency.Count;

        public bool HasSameCountFrequencies(WordHandler handler){
             
             foreach( KeyValuePair<int, int> pair in countFrequency){
               
                if (!(handler.countFrequency.TryGetValue(pair.Key, out int value) && value == pair.Value)){
                    return false;
                }
            }

            return true;
        }
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