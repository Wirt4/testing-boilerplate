

namespace LeetCodeSolutions;
public class SmallestInfiniteSet
{
    SortedSet<int> set;

    public SmallestInfiniteSet()
    {
        int[] n = Enumerable.Range(1, 1000).ToArray();
        set = new SortedSet<int>(n);
    }

    public int PopSmallest()
    {
        int num = set.First();
        set.Remove(num);
        return num;
    }

    public void AddBack(int num)
    {
        set.Add(num);
    }
}

