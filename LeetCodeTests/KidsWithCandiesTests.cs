namespace Tests;

using LeetCodeSolutions;

public class KidsWithCandiesTests{
    [Fact]
    public void Example1(){
        Candies solution = new Candies();
        IList<bool> answer = solution.KidsWithCandies([2,3,5,1,3],3);
         Assert.Equal([true,true,true,false,true] , answer);
    }
}