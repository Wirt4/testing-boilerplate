using System.IO.Pipes;
using System.Security.Cryptography;

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
            foreach(KeyValuePair<Party, int> pair in activeSenateCount){
                if (pair.Key != party && pair.Value == 0){
                    return SenatorAction.AnnounceVictory;
                }   
            }

            return SenatorAction.BanOpponent;
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
            if (activeSenators.Count >0){
                return !victoryDeclared;

            }
            return false;
        }

        public void ConductVotingRound(){
            Queue<Senator> nextRoundQueue = new();

            while (activeSenators.Count > 0){
                Senator polledSenator = activeSenators.Dequeue();
                if (polledSenator.Party == Party.Radiant){
                    if (partyVetos[Party.Radiant] > 0){
                        partyVetos[Party.Radiant] --;
                        senatorCount[Party.Radiant] --;
                        continue;
                    }

                    SenatorAction action = polledSenator.ExerciseRight(senatorCount);
                    if (action == SenatorAction.AnnounceVictory){
                        winningPary = polledSenator.Party;
                        victoryDeclared = true;
                        return;
                    }

                    if (action == SenatorAction.BanOpponent){
                        partyVetos[Party.Dire]++;
                        nextRoundQueue.Enqueue(polledSenator);
                        continue;
                    }
                }

                if (polledSenator.Party == Party.Dire){
                    if (partyVetos[Party.Dire] > 0){
                        partyVetos[Party.Dire] --;
                        senatorCount[Party.Dire] --;
                        continue;
                    }

                    SenatorAction action = polledSenator.ExerciseRight(senatorCount);
                    if (action == SenatorAction.AnnounceVictory){
                        winningPary = polledSenator.Party;
                        victoryDeclared = true;
                        return;
                    }

                    if (action == SenatorAction.BanOpponent){
                        partyVetos[Party.Radiant]++;
                        nextRoundQueue.Enqueue(polledSenator);
                        continue;
                    }
                }

            }

            activeSenators = nextRoundQueue;
        }

        public string PrevailingParty(){
            if (winningPary == Party.Radiant){
                return "Radiant";
            }

            return "Dire";
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
