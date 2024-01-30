namespace Tests;
using LeetCodeSolutions;
 public class Dota2SenateTests {
  private Dota2SenateSolution _solution;
  public Dota2SenateTests (){
      _solution = new();
  }
  [Fact]
  public void ArrayOfOneDire(){
    Assert.Equal("Dire", _solution.PredictPartyVictory("D"));
  } 

  [Fact]
  public void ArrayOfOneRadiante(){
    Assert.Equal("Radiant", _solution.PredictPartyVictory("R"));
  }

  [Fact]
  public void Example1(){
     Assert.Equal("Radiant", _solution.PredictPartyVictory("RD"));
  }

  [Fact]
  public void Example2(){
       Assert.Equal("Dire", _solution.PredictPartyVictory("RDD"));
  }
}
