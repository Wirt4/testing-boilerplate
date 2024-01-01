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

        public uint LSB => (uint)_n % 2;
    }

    private class Parameters(int a, int b, int c)
    {
        public BitwiseInt A = new(a);
        public BitwiseInt B = new(b);
        public BitwiseInt C = new(c);

        public void ShiftAll()
        {
            A.ShiftLeft();
            B.ShiftLeft();
            C.ShiftLeft();
        }

    }
    public int MinFlips(int a, int b, int c)
    {
        int bits = 0;
        while (a > 0 || b > 0 || c > 0)
        {
            int aBit = a % 2;
            int bBit = b % 2;
            int cBit = c % 2;
            int diff = aBit | bBit;

            if (diff != cBit)
            {
                if (cBit == 0)
                {
                    bits += aBit + bBit;
                }
                else if (cBit == 1)
                {
                    bits++;
                }

            }

            a /= 2;
            b /= 2;
            c /= 2;
        }
        return bits;
    }
}
