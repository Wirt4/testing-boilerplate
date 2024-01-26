using LeetCodeSolutions;
using Newtonsoft.Json.Bson;

namespace Tests;

public class EqualRowAndColumnPairsTests{
    private EqualRowAndColumnPairsSolution solution;
    public EqualRowAndColumnPairsTests(){
        solution = new();
    }
    [Fact]
    public void Example1 (){
        Assert.Equal(1, solution.EqualPairs([[3,2,1],[1,7,6],[2,7,7]]));

    }

    [Fact]
    public void Example2(){
        Assert.Equal(3, solution.EqualPairs([[3,1,2,2],[1,4,4,5],[2,4,2,2],[2,4,2,2]]));
    }

    [Fact]
    public void Example2andAHalf(){
        //should be the intersection of columns and rows, not just duplicated rows:
        // the column "
         Assert.Equal(0, solution.EqualPairs([[3,1,0,2],[1,4,4,5],[2,4,2,2],[2,4,2,2]]));
    }

    [Fact]
    public void BreakingCase1(){
        Assert.Equal(2, solution.EqualPairs([[11,1],[1,11]]));
    }
}