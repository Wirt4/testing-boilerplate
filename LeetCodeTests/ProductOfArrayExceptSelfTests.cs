namespace Tests;
using LeetCodeSolutions;

public class ProductOfArrayExceptSelfTests{
    [Fact]
    public void arrOfLength2(){
        ArrayProduct solution = new ArrayProduct();
        Assert.Equal([2, 1], solution.ProductExceptSelf([1,2]));
    }
}