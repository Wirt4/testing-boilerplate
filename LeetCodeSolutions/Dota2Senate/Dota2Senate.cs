namespace LeetCodeSolutions;
public class Dota2SenateSolution {

    private class SenateTally{
        private int _direSenators;
        private int _radiantSenators;
        private bool _firstCharIsDire;
        public SenateTally(string senate){
            _direSenators = 0;
            _radiantSenators = 0;
            CountSenators(senate);
        }
        public static bool IsDire(char senator){
            return senator == 'D';
        }

        private void CountSenators(string senate){
            for(int i =0; i< senate.Length; i++){
                if (IsDire(senate[i])){
                    _firstCharIsDire = i == 0 || _firstCharIsDire;
                    _direSenators ++;
                    continue;
                }

                _radiantSenators++;

            }
        }

        public bool FirstCharIsDire => _firstCharIsDire;

        public bool HasEqualNumbers => _radiantSenators == _direSenators;

        public bool DireHasMajority => _direSenators > _radiantSenators;
    }
    public string PredictPartyVictory(string senate) {
        SenateTally tally = new(senate);

        if ((tally.HasEqualNumbers && tally.FirstCharIsDire) || tally.DireHasMajority){
            return "Dire";
        }
        
        return "Radiant";
    }
}
