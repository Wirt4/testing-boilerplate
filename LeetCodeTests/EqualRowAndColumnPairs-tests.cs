using LeetCodeSolutions;

namespace Tests;

public class EqualRowAndColumnPairsTests{
    [Fact]
    public void Example1 (){
        EqualRowAndColumnPairsSolution solution = new();
        Assert.Equal(1, solution.EqualPairs([[3,2,1],[1,7,6],[2,7,7]]));

    }
}