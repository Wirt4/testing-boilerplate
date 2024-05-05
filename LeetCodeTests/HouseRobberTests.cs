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

    [Fact]
    public void Example1(){
         Assert.Equal(4, _solution.Rob([1,2,3,1]));
         Assert.Equal(5, _solution.Rob([1,2,4,1]));
    }

    [Fact]
    public void Example2(){
        Assert.Equal(12, _solution.Rob([2,7,9,3,1]));
    }

    [Fact]
    public void BuckTheRythym(){
        Assert.Equal(200, _solution.Rob([100,0,0,100]));
    }
}