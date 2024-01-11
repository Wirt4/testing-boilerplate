namespace Tests;
using LeetCodeSolutions;

public class MaxNumberOfKSumPairsTests{
    [Fact]
    public void Example1(){
        KSumPairs pairs = new KSumPairs();
        Assert.Equal(2, pairs.MaxOperations([1,2,3,4], 5));
    }
}