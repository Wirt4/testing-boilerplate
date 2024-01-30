using System.Runtime.CompilerServices;

namespace LeetCodeSolutions;
public class Dota2SenateSolution {

    private class SenateTally{
        private int DireSenators;
        private int RadiantSenators;
        public SenateTally(string senate){
            DireSenators = 0;
            RadiantSenators = 0;
            CountSenators(senate);
        }
        public static bool IsDire(char senator){
            return senator == 'D';
        }

        private void CountSenators(string senate){
            foreach(char senator in senate){
                if (IsDire(senator)){
                    DireSenators ++;
                    continue;
                }

                RadiantSenators++;

            }
        }

        public bool HasEqualNumbers => RadiantSenators == DireSenators;

        public bool DireHasMajority => DireSenators > RadiantSenators;
    }
    public string PredictPartyVictory(string senate) {
        SenateTally tally = new SenateTally(senate);

        if (tally.HasEqualNumbers){
            return SenateTally.IsDire(senate[0]) ? "Dire": "Radiant";
        }

        if (tally.DireHasMajority){
            return "Dire";
        }

      return "Radiant";
    }
}
