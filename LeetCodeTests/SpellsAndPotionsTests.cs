namespace Tests;
using LeetCodeSolutions;
public class SpellsAndPotionsTests
{
  private SpellsAndPotionsSolution _solution;
  public SpellsAndPotionsTests()
  {
    _solution = new();
  }
  private class Arguments
  {
    public int[] spells;
    public int[] potions;
    public long success;
  };

  private void TestCase(Arguments args, int[] desiredAnswer)
  {
    int[] actualAnswer = _solution.SuccessfulPairs(args.spells, args.potions, args.success);
    Assert.Equal(desiredAnswer, actualAnswer);
  }
  [Fact]
  public void ArrayOfOneCase1()
  {
    Arguments args = new()
    {
      spells = [2],
      potions = [2],
      success = 3
    };
    int[] positionalSuccesses = [1];
    TestCase(args, positionalSuccesses);
  }

  [Fact]
  public void ArrayOfOneCase2()
  {
    Arguments args = new()
    {
      spells = [2],
      potions = [2],
      success = 6
    };
    int[] positionalSuccesses = [0];
    TestCase(args, positionalSuccesses);
  }

  [Fact]
  public void LCExample1()
  {
    Arguments args = new()
    {
      spells = [5, 1, 3],
      potions = [1, 2, 3, 4, 5],
      success = 7
    };
    int[] positionalSuccesses = [4, 0, 3];
    TestCase(args, positionalSuccesses);
  }

  [Fact]
  public void LCExample2()
  {
    Arguments args = new()
    {
      spells = [3, 1, 2],
      potions = [8, 5, 8],
      success = 16
    };
    int[] positionalSuccesses = [2, 0, 2];
    TestCase(args, positionalSuccesses);
  }
}