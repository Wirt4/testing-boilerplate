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

  [Fact]
  public void BreakingCase1()
  {
    Arguments args = new()
    {
      spells = [40, 11, 24, 28, 40, 22, 26, 38, 28, 10, 31, 16, 10, 37, 13, 21, 9, 22, 21, 18, 34, 2, 40, 40, 6, 16, 9, 14, 14, 15, 37, 15, 32, 4, 27, 20, 24, 12, 26, 39, 32, 39, 20, 19, 22, 33, 2, 22, 9, 18, 12, 5],
      potions = [31, 40, 29, 19, 27, 16, 25, 8, 33, 25, 36, 21, 7, 27, 40, 24, 18, 26, 32, 25, 22, 21, 38, 22, 37, 34, 15, 36, 21, 22, 37, 14, 31, 20, 36, 27, 28, 32, 21, 26, 33, 37, 27, 39, 19, 36, 20, 23, 25, 39, 40],
      success = 600
    };
    int[] positionalSuccesses = [48, 0, 32, 37, 48, 22, 33, 47, 37, 0, 43, 6, 0, 46, 0, 21, 0, 22, 21, 14, 46, 0, 48, 48, 0, 6, 0, 0, 0, 3, 46, 3, 45, 0, 34, 20, 32, 0, 33, 47, 45, 47, 20, 18, 22, 45, 0, 22, 0, 14, 0, 0];
    TestCase(args, positionalSuccesses);
  }
}
