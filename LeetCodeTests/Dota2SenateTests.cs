namespace Tests;
using LeetCodeSolutions;
 public class Dota2SenateTests {
  private Dota2SenateSolution _solution;
  public Dota2SenateTests (){
      _solution = new();
  }
  [Fact]
  public void ArrayOfOneDire(){
    Assert.Equal("Dire",_solution.PredictPartyVictory("D"));
  }
}
