

namespace LeetCodeSolutions;
public class SmallestInfiniteSet
{
    readonly SortedSet<int> addedBack;
    readonly SortedSet<int> popped;

    public SmallestInfiniteSet()
    {
        addedBack = new();
        popped = new();
    }

    public int PopSmallest()
    {
        if (addedBack.Count > 0)
        {
            int min = addedBack.Min();
            addedBack.Remove(min);
            popped.Add(min);
            return min;
        }

        if (popped.Count == 0)
        {
            int first = 1;
            popped.Add(first);
            return first;
        }

        int next = popped.Max() + 1;
        popped.Add(next);
        return next;
    }

    public void AddBack(int num)
    {
        if (popped.Contains(num))
        {
            popped.Remove(num);
            addedBack.Add(num);
        }
    }
}

