namespace Tests;

using LeetCodeSolutions;
using static LeetCodeSolutions.FlowerBed;
public class CanPlaceFlowersTests
{
    [Fact]
    public void example1()
    {
        FlowerBed bed = new FlowerBed();

        bool result = bed.CanPlaceFlowers([1,0,0,0,1], 1);

        Assert.True(result);

    }

     [Fact]
    public void example2()
    {
        FlowerBed bed = new FlowerBed();

        bool result = bed.CanPlaceFlowers([1,0,0,0,1], 2);

        Assert.False(result);

    }

    [Fact]
    public void smallestPossibleFlowerBedCantPland(){
        FlowerBed bed = new FlowerBed();

        bool result = bed.CanPlaceFlowers([1], 1);

        Assert.False(result);
    }

[Fact]
     public void example2Modified()
    {
        FlowerBed bed = new FlowerBed();

        bool result = bed.CanPlaceFlowers([1,0,0,0,0,0,1], 2);
        //flowerbed would look like [1,0,1,0,1,0,1]

        Assert.True(result);

    }
}