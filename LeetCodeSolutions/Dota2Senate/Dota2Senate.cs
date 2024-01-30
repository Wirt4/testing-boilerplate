namespace LeetCodeSolutions;
public class Dota2SenateSolution {
    private enum Party{
        Dire,
        Radiant
    }

    private enum SenatorAction{
        AnnounceVictory,
        BanOpponent
    }


    private class Senator{
        private readonly Party party;
        public Senator(char initial){
            switch(initial){
                case 'D':
                    party = Party.Dire;
                    break;
                case 'R':
                    party = Party.Radiant;
                    break;
            }
        }

        
        public SenatorAction ExerciseRight(Dictionary<Party, int> activeSenateCount){
            if(activeSenateCount[party] > 0 && activeSenateCount[OpposingParty()] == 0){
                return SenatorAction.AnnounceVictory;
            }else{
                return SenatorAction.BanOpponent;
            }
        }

        public Party OpposingParty(){
            switch(party){
                case Party.Dire:
                    return Party.Radiant;
                case Party.Radiant:
                    return Party.Dire;
                default:
                    return Party.Dire;
            }
        }

        public Party Party => party;
    }

    private class Senate{
        private readonly Dictionary<Party, int> senatorCount;
        private readonly Dictionary<Party, int> partyVetos;
        private Queue<Senator> activeSenators;
        private bool victoryDeclared;
        private Party winningParty;
        public Senate(string senators){
            senatorCount = IntializeDictionary();
            partyVetos = IntializeDictionary();
            activeSenators = [];
            victoryDeclared = false;


            foreach(char partyInitial in senators){
                Senator currentSenator = new(partyInitial);
                activeSenators.Enqueue(currentSenator);
                senatorCount[currentSenator.Party]++;
            }
        }
        private static Dictionary<Party, int> IntializeDictionary(){
            Dictionary<Party, int >dictionary = [];
            dictionary.Add(Party.Dire, 0);
            dictionary.Add(Party.Radiant, 0);
            return dictionary;
        }
        public bool IsVoting(){
            return activeSenators.Count > 0 && !victoryDeclared;
        }

        private bool IsBanned(Senator senator){
            return partyVetos[senator.Party] > 0;
        }

        private void RemoveSenator(Senator senator){
            partyVetos[senator.Party] --;
            senatorCount[senator.Party] --;
        }
        public void ConductVotingRound(){
            Queue<Senator> nextRoundQueue = new();

            while (activeSenators.Count > 0){
                Senator polledSenator = activeSenators.Dequeue();
                if (IsBanned(polledSenator)){
                       RemoveSenator(polledSenator);
                       continue;
                }

                nextRoundQueue.Enqueue(polledSenator);
                
                switch(polledSenator.ExerciseRight(senatorCount)){
                    case SenatorAction.BanOpponent:
                        partyVetos[polledSenator.OpposingParty()]++;
                        break;
                    case SenatorAction.AnnounceVictory:
                        winningParty = polledSenator.Party;
                        victoryDeclared = true;
                        return;
                    }

                    
                }

            activeSenators = nextRoundQueue;
        }

        public string PrevailingParty(){
            switch(winningParty){
                case Party.Dire:
                    return "Dire";
                case Party.Radiant:
                    return "Radiant";
                default:
                    return "";
            }
        }
    }

    public string PredictPartyVictory(string senators) {
        Senate senate = new(senators);
        while (senate.IsVoting()){
            senate.ConductVotingRound();
        }

        return senate.PrevailingParty();
    }
}
