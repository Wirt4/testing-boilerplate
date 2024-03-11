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
    public int MinFlips(int a, int b, int c)
    {
        int bits = 0;
        BitwiseInt bA = new(a);
        BitwiseInt bB = new(b);
        BitwiseInt bC = new(c);
        while (!bA.IsNull() && !bB.IsNull() && !bC.IsNull())
        {

            switch (bC.LSB)
            {
                case 0:
                    bits += bA.LSB;
                    bits += bB.LSB;
                    break;
                case 1:
                    //only case where need to set a bit here, an OR between to nulls
                    if (bA.LSB == 0 && bB.LSB == 0)
                    {
                        bits++;
                    }
                    break;
            }
            //shift the least significant bits
            bA.ShiftLeft();
            bB.ShiftLeft();
            bC.ShiftLeft();
        }

        return bits;
    }
}
