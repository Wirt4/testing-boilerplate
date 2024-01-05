namespace Tests;

using LeetCodeSolutions;

public class KidsWithCandiesTests{
    [Fact]
    public void Example1(){
        Candies solution = new Candies();
        IList<bool> answer = solution.KidsWithCandies([2,3,5,1,3],3);
         Assert.Equal([true,true,true,false,true] , answer);
    }

    [Fact]
    public void smallestSeriesOfCandies(){
        Candies solution = new Candies();
        IList<bool> answer = solution.KidsWithCandies([1,1],1);
        Assert.Equal([true, true] , answer);
    }

    [Fact]

    public void Example2(){
        Candies solution = new Candies();
        IList<bool> answer = solution.KidsWithCandies([4,2,1,1,2],1);
        Assert.Equal([true,false,false,false,false], answer);
    }

    [Fact]
    public void Example3(){
        Candies solution = new Candies();
        IList<bool> answer = solution.KidsWithCandies([12, 1, 2],10);
        Assert.Equal([true,false,true], answer);
    }
}