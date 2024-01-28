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
  [Fact]
  public void Example2(){
    Assert.Equal([], _solution.AsteroidCollision([8, -8]));
  }

  [Fact]
  public void Example3(){
     Assert.Equal([10], _solution.AsteroidCollision([10, 2, -5]));
  }
  [Fact]
  public void OppositeDirections(){
     Assert.Equal([-8, 8], _solution.AsteroidCollision([-8, 8]));
  }

  [Fact]
  public void BreakingCase1(){
     Assert.Equal([-2, -2, -2], _solution.AsteroidCollision([-2,-2,1,-2]));
  }
}
