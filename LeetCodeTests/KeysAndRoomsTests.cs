namespace Tests;
using LeetCodeSolutions;
public class KeysAndRoomsTests
{
  private KeysAndRoomsSolution _solution;
  public KeysAndRoomsTests()
  {
    _solution = new();
  }
  [Fact]
  public void Example1()
  {
    Assert.True(_solution.CanVisitAllRooms([[1], [2], [3], []]));
  }
}
