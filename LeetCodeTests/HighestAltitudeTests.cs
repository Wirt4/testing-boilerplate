namespace Tests;
using LeetCodeSolutions;
public class HighestAltitudeTests{
    private HighestAltitude _solution;

    public HighestAltitudeTests(){
        _solution = new HighestAltitude();
    }

    [Fact]
    public void Example1(){
        Assert.Equal(1, _solution.LargestAltitude([-5,1,5,0,-7]));
    }

}