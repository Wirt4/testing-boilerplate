namespace Tests;

using LeetCodeSolutions;
public class DeleteTheMiddleNodeTests
{
  private DeleteTheMiddleNodeSolution _solution;
  public DeleteTheMiddleNodeTests()
  {
    _solution = new();
  }
  [Fact]
  public void LinkedListOfSizeOne()
  {
    ListNode head = new();
    Assert.Null(_solution.DeleteMiddle(head));
  }

  [Fact]
  public void Example3()
  {
    CompareHeadToDesiredOutput([2, 1], [2]);
  }

  [Fact]
  public void Example3_DifferentValues()
  {
    CompareHeadToDesiredOutput([1, 2], [1]);
  }

  [Fact]
  public void ListOfSize3()
  {
    CompareHeadToDesiredOutput([1, 2, 3], [1, 3]);
  }

  [Fact]

  public void ListOfSize3DifferentData()
  {
    CompareHeadToDesiredOutput([3, 2, 1], [3, 1]);
  }

  [Fact]
  public void Example1()
  {
    CompareHeadToDesiredOutput([1, 3, 4, 7, 1, 2, 6], [1, 3, 4, 1, 2, 6]);
  }

  [Fact]
  public void Example2()
  {
    CompareHeadToDesiredOutput([1, 2, 3, 4], [1, 2, 4]);
  }


  private void CompareHeadToDesiredOutput(int[] head, int[] output)
  {
    ListNode input = LinkedListTesting.ListFromArray(head);
    ListNode desiredOutput = LinkedListTesting.ListFromArray(output);
    ListNode actualOutput = _solution.DeleteMiddle(input);
    LinkedListTesting.AssertListsAreEqual(desiredOutput, actualOutput);
  }
}
