namespace LeetCodeSolutions;

public class CloseStringsSolution{
    private Dictionary<char, int> CreateFrequencyTable(string word){
        Dictionary<char, int> table =[];

        foreach(char ch in word){

            if (table.TryGetValue(ch, out int value)){
                table[ch] = value + 1;
                continue;
            }

            table.Add(ch, 1);
        }

        return table;
    }

    private Dictionary<int, int> FrequencyOfCounts(Dictionary<char, int> table){
        Dictionary<int, int> newTable =[];

        foreach(int d in table.Values){

            if (newTable.TryGetValue(d, out int value)){
                newTable[d] = value + 1;
                continue;
            }

            newTable.Add(d, 1);
        }

        return newTable;
    }

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


        }

        public Dictionary<char, int> CharFrequency => charFrequencyTable;
        public bool HasSameDistinctChars(WordHandler handler){
            foreach (char k in charFrequencyTable.Keys){
                if (! handler.CharFrequency.ContainsKey(k)) return false;
            }

            return true;
        }

        public bool HasSameCharacterFrequencies(WordHandler handler){
            foreach( KeyValuePair<char, int> pair in charFrequencyTable){
                if (handler.CharFrequency[pair.Key] != pair.Value) return false;
            }

            return true;
        }

        public int NumberOfDistintChars => charFrequencyTable.Count;

        public void InitiateCountFrequency(){
            countFrequencyTable = [];

            foreach(int d in charFrequencyTable.Values){

            if (countFrequencyTable.TryGetValue(d, out int value)){
                countFrequencyTable[d] = value + 1;
                continue;
            }

            countFrequencyTable.Add(d, 1);
        }
        }

        public int NumberOfDistinctCounts => countFrequencyTable.Count;

        public bool HasSameCountFrequencies(WordHandler handler){
             foreach( KeyValuePair<int, int> pair in countFrequencyTable){
                if (handler.countFrequencyTable[pair.Key] != pair.Value) return false;
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

        collection1.InitiateCountFrequency();
        collection2.InitiateCountFrequency();

        if (collection1.NumberOfDistinctCounts != collection2.NumberOfDistinctCounts){
            return false;
        }

        return collection1.HasSameCountFrequencies(collection2); 
    }
}