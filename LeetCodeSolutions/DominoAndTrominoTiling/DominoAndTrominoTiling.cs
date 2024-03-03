namespace LeetCodeSolutions;
public class DominoAndTrominoTilingSolution
{
    public int NumTilings(int n)
    {
        switch (n)
        {
            case 0:
                return 0;
            case 1:
                return 1;
            case 2:
                return 2;
            case 3:
                return 5;
            default:
                return (NumTilings(n - 1) * 2) + NumTilings(n - 3);
        }

    }
}
