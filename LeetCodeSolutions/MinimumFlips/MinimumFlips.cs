namespace LeetCodeSolutions;
public class MinimumFlipsSolution
{

    private class BitwiseInt(int n)
    {
        int _n = n;
        public bool IsNull()
        {
            return _n == 0;
        }

        public void ShiftLeft()
        {
            _n /= 2;
        }

        public int LSB => _n % 2;
    }

    private class Parameters(int a, int b, int c)
    {
        public BitwiseInt A = new(a);
        public BitwiseInt B = new(b);
        public BitwiseInt C = new BitwiseInt(c);

        public void ShiftAll()
        {
            A.ShiftLeft();
            B.ShiftLeft();
            C.ShiftLeft();
        }

        public int SumOfLSBsOfAandB()
        {
            return A.LSB + B.LSB;
        }

    }
    public int MinFlips(int a, int b, int c)
    {
        int bits = 0;
        Parameters nums = new(a, b, c);

        while (!nums.A.IsNull() && !nums.B.IsNull() && !nums.C.IsNull())
        {

            if (nums.C.LSB == 0)
            {

                bits += nums.SumOfLSBsOfAandB();

            }
            else if (nums.SumOfLSBsOfAandB() == 0)
            {
                bits++;
            }

            nums.ShiftAll();
        }

        return bits;
    }
}
