namespace Tests;
using LeetCodeSolutions;
public class OddEvenLinkedListTests
{
  private OddEvenLinkedListSolution _solution;
  public OddEvenLinkedListTests()
  {
    _solution = new();
  }
  [Fact]
  public void Example1()
  {
    CompareFunctionFromArrays([1, 2, 3, 4, 5], [1, 3, 5, 2, 4]);
  }

  [Fact]
  public void Example2()
  {
    CompareFunctionFromArrays([2, 1, 3, 5, 6, 4, 7], [2, 3, 6, 7, 1, 5, 4]);
  }

  private void CompareFunctionFromArrays(int[] input, int[] output)
  {
    ListNode inputList = LinkedListTesting.ListFromArray(input);
    ListNode expectedOutput = LinkedListTesting.ListFromArray(output);
    ListNode actualOutput = _solution.OddEvenList(inputList);
    LinkedListTesting.AssertListsAreEqual(expectedOutput, actualOutput);
  }
}
