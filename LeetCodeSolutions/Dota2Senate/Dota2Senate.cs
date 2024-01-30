namespace LeetCodeSolutions;
public class Dota2SenateSolution
{
    private enum Party
    {
        Dire,
        Radiant
    }

    private enum SenatorAction
    {
        AnnounceVictory,
        BanOpponent
    }


    private class Senator
    {
        private readonly Party party;
        public Senator(char initial)
        {
            switch (initial)
            {
                case 'D':
                    party = Party.Dire;
                    break;
                case 'R':
                    party = Party.Radiant;
                    break;
            }
        }


        public SenatorAction ExerciseRight(Dictionary<Party, int> activeSenateCount)
        {
            if (activeSenateCount[party] > 0 && activeSenateCount[OpposingParty()] == 0)
            {
                return SenatorAction.AnnounceVictory;
            }

            return SenatorAction.BanOpponent;
        }

        public Party OpposingParty()
        {
            switch (party)
            {
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

    private class Senate
    {
        private readonly Dictionary<Party, int> senatorCount;
        private readonly Dictionary<Party, int> partyVetos;
        private Queue<Senator> activeSenators;
        private bool victoryDeclared;
        private Party winningParty;
        public Senate(string senators)
        {
            senatorCount = IntializeDictionary();
            partyVetos = IntializeDictionary();
            activeSenators = new Queue<Senator>();
            victoryDeclared = false;

            foreach (char partyInitial in senators)
            {
                AddSenator(partyInitial);
            }
        }

        private void AddSenator(char initial)
        {
            Senator senator = new(initial);
            activeSenators.Enqueue(senator);
            senatorCount[senator.Party]++;
        }
        private static Dictionary<Party, int> IntializeDictionary()
        {
            Dictionary<Party, int> dictionary = [];
            dictionary.Add(Party.Dire, 0);
            dictionary.Add(Party.Radiant, 0);
            return dictionary;
        }
        public bool IsVoting()
        {
            return !(activeSenators.Count <= 0 || !victoryDeclared);
        }

        private bool IsBanned(Senator senator)
        {
            return partyVetos[senator.Party] > 0;
        }

        private void RemoveSenator(Senator senator)
        {
            partyVetos[senator.Party]--;
            senatorCount[senator.Party]--;
        }

        private void TakeVote(Senator senator)
        {
            switch (senator.ExerciseRight(senatorCount))
            {
                case SenatorAction.BanOpponent:
                    partyVetos[senator.OpposingParty()]++;
                    return;
                case SenatorAction.AnnounceVictory:
                    winningParty = senator.Party;
                    victoryDeclared = true;
                    return;
            }
        }
        public void ConductVotingRound()
        {
            Queue<Senator> nextRoundQueue = new();

            while (activeSenators.Count > 0)
            {
                Senator polledSenator = activeSenators.Dequeue();

                if (IsBanned(polledSenator))
                {
                    RemoveSenator(polledSenator);
                    continue;
                }

                TakeVote(polledSenator);
                nextRoundQueue.Enqueue(polledSenator);
            }

            activeSenators = nextRoundQueue;
        }

        public string PrevailingParty()
        {
            switch (winningParty)
            {
                case Party.Dire:
                    return "Dire";
                case Party.Radiant:
                    return "Radiant";
                default:
                    return "";
            }
        }
    }

    public string PredictPartyVictory(string senators)
    {
        Senate senate = new(senators);
        while (senate.IsVoting())
        {
            senate.ConductVotingRound();
        }

        return senate.PrevailingParty();
    }
}
