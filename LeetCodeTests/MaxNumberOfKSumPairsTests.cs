namespace Tests;
using LeetCodeSolutions;

public class MaxNumberOfKSumPairsTests{
    [Fact]
    public void Example1(){
        KSumPairs pairs = new KSumPairs();
        Assert.Equal(2, pairs.MaxOperations([1,2,3,4], 5));
    }

    [Fact]
    public void Example2(){
        KSumPairs pairs = new KSumPairs();
        Assert.Equal(1, pairs.MaxOperations([3,1,3,4,3], 6));
    }
}