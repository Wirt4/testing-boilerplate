namespace LeetCodeSolutions;
public class DominoAndTrominoTilingSolution
{
    public int NumTilings(int n)
    {
        Dictionary<int, int> memos = new();
        return NumTilingsMemoed(n, ref memos);
    }
    public int NumTilingsMemoed(int n, ref Dictionary<int, int> memos)
    {
        if (memos.TryGetValue(n, out int value))
        {
            return value;
        }
        switch (n)
        {
            case 0:
                memos.Add(0, 0);
                return 0;
            case 1:
                memos.Add(1, 1);
                return 1;
            case 2:
                memos.Add(2, 2);
                return 2;
            case 3:
                memos.Add(3, 5);
                return 5;
            default:
                return (NumTilingsMemoed(n - 1, ref memos) * 2) + NumTilingsMemoed(n - 3, ref memos);
        }
    }
}
