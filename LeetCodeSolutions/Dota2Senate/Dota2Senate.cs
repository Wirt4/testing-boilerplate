namespace LeetCodeSolutions;
public class Dota2SenateSolution {
    private enum Party{
        Radiant,
        Dire
    }

    private enum SenatorAction{
        AnnounceVictory,
        BanOpponent
    }


    private class Senator{
        private readonly Party party;
        public Senator(char initial){
            if (initial == 'D'){
                party = Party.Dire;
                return;
            }

            party = Party.Radiant;
        }

        
        public SenatorAction ExerciseRight(Dictionary<Party, int> activeSenateCount){
            if(activeSenateCount[party] > 0 && activeSenateCount[OpposingParty()] == 0){
                return SenatorAction.AnnounceVictory;
            }

            return SenatorAction.BanOpponent;
        }

        public Party OpposingParty(){
            return party == Party.Radiant ? Party.Dire: Party.Radiant;
        }

        public Party Party => party;
    }

    private class Senate{
        private Dictionary<Party, int> senatorCount;
        private Dictionary<Party, int> partyVetos;
        private Queue<Senator> activeSenators;
        private bool victoryDeclared;
        private Party winningPary;
        public Senate(string senators){
            senatorCount =[];
            senatorCount.Add(Party.Radiant, 0);
            senatorCount.Add(Party.Dire, 0);

            activeSenators = [];

            victoryDeclared = false;

            partyVetos = [];
            partyVetos.Add(Party.Radiant, 0);
            partyVetos.Add(Party.Dire, 0);

            foreach(char partyInitial in senators){
                Senator currentSenator = new Senator(partyInitial);
                activeSenators.Enqueue(currentSenator);
                senatorCount[currentSenator.Party]++;
            }
        }
        public bool IsVoting(){
            return activeSenators.Count > 0 && !victoryDeclared;
        }

        public void ConductVotingRound(){
            Queue<Senator> nextRoundQueue = new();

            while (activeSenators.Count > 0){
                Senator polledSenator = activeSenators.Dequeue();
                if (partyVetos[polledSenator.Party] > 0){
                        partyVetos[polledSenator.Party] --;
                        senatorCount[polledSenator.Party] --;
                        continue;
                    }

                    SenatorAction action = polledSenator.ExerciseRight(senatorCount);
                    if (action == SenatorAction.AnnounceVictory){
                        winningPary = polledSenator.Party;
                        victoryDeclared = true;
                        return;
                    }

                    if (action == SenatorAction.BanOpponent){
                        partyVetos[polledSenator.OpposingParty()]++;
                        nextRoundQueue.Enqueue(polledSenator);
                        continue;
                    }
                }

               

            activeSenators = nextRoundQueue;
        }

        public string PrevailingParty(){
            return winningPary == Party.Radiant ? "Radiant" : "Dire";
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
