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
    ListNode input = LinkedListTesting.ListFromArray([1, 2, 3, 4, 5]);
    ListNode expectedOutput = LinkedListTesting.ListFromArray([1, 3, 5, 2, 4]);
    ListNode actualOutput = _solution.OddEvenList(input);
    LinkedListTesting.AssertListsAreEqual(expectedOutput, actualOutput);
  }
}
