namespace Tests;
using LeetCodeSolutions;
 public class AsteroidCollisionTests {
  private AsteroidCollisionSolution _solution;
  public AsteroidCollisionTests (){
      _solution = new();
  }
  [Fact]
  public void Example1(){
    Assert.Equal([5, 10], _solution.AsteroidCollision([5, 10, -5]));
  }
}
