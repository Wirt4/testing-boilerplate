namespace Tests;
using LeetCodeSolutions;

public class MoveZeroesTests{
    [Fact]
    public void arrayOfOne(){
        Zeroes solution = new Zeroes();
        int[] argument = [2]; 
        solution.MoveZeroesByRef(ref argument);
        Assert.Equal([2], argument);

    }

    [Fact]
    public void arrayOfTwo(){
        Zeroes solution = new Zeroes();
        int[] argument = [0, 2]; 
        solution.MoveZeroesByRef(ref argument);
        Assert.Equal([2, 0], argument);
    }

    [Fact]
    public void arrayOfTwoDifferentValues(){
        Zeroes solution = new Zeroes();
        int[] argument = [0, 3]; 
        solution.MoveZeroesByRef(ref argument);
        Assert.Equal([3, 0], argument);
    }

    [Fact]
    public void arrayOfTwoNoZeroes(){
        Zeroes solution = new Zeroes();
        int[] argument = [2, 3]; 
        solution.MoveZeroesByRef(ref argument);
        Assert.Equal([2,3], argument);
    }

    [Fact]

    public void Example1(){
         Zeroes solution = new Zeroes();
        int[] argument = [0,1,0,3,12]; 
        solution.MoveZeroesByRef(ref argument);
        Assert.Equal([1,3,12,0,0], argument);
    }

    [Fact]
    public void Example2(){
        Zeroes solution = new Zeroes();
        int[] argument = [0]; 
        solution.MoveZeroesByRef(ref argument);
        Assert.Equal([0], argument);
    }

}