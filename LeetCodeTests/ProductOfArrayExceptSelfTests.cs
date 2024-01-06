namespace Tests;
using LeetCodeSolutions;

public class ProductOfArrayExceptSelfTests{
    [Fact]
    public void ArrOfLength2(){
        ArrayProduct solution = new ArrayProduct();
        Assert.Equal([2, 1], solution.ProductExceptSelf([1,2]));
    }

    [Fact]
    public void Example1(){
        ArrayProduct solution = new ArrayProduct();
        int[] answer = solution.ProductExceptSelf([1, 2, 3, 4]);
        Assert.Equal([24, 12, 8, 6], answer);
    }

    [Fact]
    public void Example2(){
        ArrayProduct solution = new ArrayProduct();
        int[] answer = solution.ProductExceptSelf([-1, 1,0,-3,3]);
        Assert.Equal([0, 0, 9, 0, 0], answer);
    }

    [Fact]
    public void HiddenTestCase1(){
        ArrayProduct solution = new ArrayProduct();
        int[] answer = solution.ProductExceptSelf([0,0]);
        Assert.Equal([0, 0], answer);
    }

    [Fact]
    public void HiddenTestCase2(){
        ArrayProduct solution = new ArrayProduct();
        int[] answer = solution.ProductExceptSelf([0,4,0]);
        Assert.Equal([0, 0, 0], answer);
    }
}