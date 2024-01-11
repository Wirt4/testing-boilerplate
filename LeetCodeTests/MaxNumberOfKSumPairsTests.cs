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

     [Fact]
    public void breakingCase1(){
        KSumPairs pairs = new KSumPairs();
        Assert.Equal(4, pairs.MaxOperations([2,5,4,4,1,3,4,4,1,4,4,1,2,1,2,2,3,2,4,2], 3));
    }
}