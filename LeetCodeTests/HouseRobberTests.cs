using LeetCodeSolutions;

namespace Tests;
public class HouseRobberTests{
    private HouseRobber _solution;
    public HouseRobberTests(){
        _solution = new HouseRobber();
    }

    [Fact]
    public void MinimumLength(){
        Assert.Equal(4, _solution.Rob([4]));
        Assert.Equal(1, _solution.Rob([1]));
    }
}