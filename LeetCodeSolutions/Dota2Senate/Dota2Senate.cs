namespace LeetCodeSolutions;
public class Dota2SenateSolution {
    private bool EqualNumbers(string senate){
        int DireCount = 0;
        int RadiantCount = 0;
        foreach(char senator in senate){
            if (senator == 'D'){
                DireCount++;
                continue;
            }

            RadiantCount ++;
        }
        return DireCount ==  RadiantCount;
    }

    private bool DireMajority(string senate){
        int DireCount = 0;
        int RadiantCount = 0;
        foreach(char senator in senate){
            if (senator == 'D'){
                DireCount++;
                continue;
            }

            RadiantCount ++;
        }
        return DireCount >  RadiantCount;
    }
    public string PredictPartyVictory(string senate) {
        if (EqualNumbers(senate)){
            return senate[0] == 'D' ? "Dire" : "Radiant";
        }
        if (DireMajority(senate)){
            return "Dire";
        }
      return "Radiant";
    }
}
