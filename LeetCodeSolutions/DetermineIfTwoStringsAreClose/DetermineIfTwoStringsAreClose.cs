namespace LeetCodeSolutions;

public class CloseStringsSolution{
    private class WordHandler{
        private readonly Dictionary<char, int> charFrequencyTable;
        private Dictionary<int, int> countFrequencyTable;
        public WordHandler (string word){
            charFrequencyTable = [];

            foreach(char ch in word){

            if (charFrequencyTable.TryGetValue(ch, out int value)){
                charFrequencyTable[ch] = value + 1;
                continue;
            }

                charFrequencyTable.Add(ch, 1);
            }

            countFrequencyTable = [];

            foreach(int count in charFrequencyTable.Values){

                if (countFrequencyTable.TryGetValue(count, out int value)){
                    countFrequencyTable[count] = value + 1;
                    continue;
                }

                countFrequencyTable.Add(count, 1);
            }

        }

        public bool HasSameDistinctChars(WordHandler handler){
            foreach (char k in charFrequencyTable.Keys){
                if (! handler.charFrequencyTable.ContainsKey(k)) return false;
            }

            return true;
        }

        public bool HasSameCharacterFrequencies(WordHandler handler){
            foreach( KeyValuePair<char, int> pair in charFrequencyTable){
                if (handler.charFrequencyTable[pair.Key] != pair.Value) return false;
            }

            return true;
        }

        public int NumberOfDistintChars => charFrequencyTable.Count;

        public int NumberOfDistinctCounts => countFrequencyTable.Count;

        public bool HasSameCountFrequencies(WordHandler handler){
             foreach( KeyValuePair<int, int> pair in countFrequencyTable){
                if (!handler.countFrequencyTable.TryGetValue(pair.Key, out int value) || value != pair.Value) return false;
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