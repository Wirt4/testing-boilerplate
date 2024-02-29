namespace Tests;
using LeetCodeSolutions;
public class SpellsAndPotionsTests
{
  private SpellsAndPotionsSolution _solution;
  public SpellsAndPotionsTests()
  {
    _solution = new();
  }
  [Fact]
  public void ArrayOfOneCase1()
  {
    int[] spells = [2];
    int[] potions = [2];
    long success = 3;
    Assert.Equal([1], _solution.SuccessfulPairs(spells, potions, success));
  }
}
