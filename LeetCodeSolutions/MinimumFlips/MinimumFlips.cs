namespace LeetCodeSolutions;
public class MinimumFlipsSolution
{

    public int MinFlips(int a, int b, int c)
    {
        int bits = 0;
        while (a != 0 && b != 0 && c != 0)
        {
            //get the least significant bits of all three
            int aBit = a % 2;
            int bBit = b % 2;
            int cBit = c % 2;

            switch (cBit)
            {
                case 0:
                    //no change needed
                    if (aBit == 0 && bBit == 0)
                    {
                        continue;
                    }
                    //one bit is zero, set the other one to zero to make result of OR Zero
                    if (aBit == 0 || bBit == 0)
                    {
                        bits += 1;
                        continue;
                    }
                    //default case: clear both bits
                    bits += 2;
                    break;
                case 1:
                    //only case where need to set a bit here, an OR between to nulls
                    if (aBit == 0 && bBit == 0)
                    {
                        bits++;
                    }
                    break;
            }
            //shift the least significant bits
            a /= 2;
            b /= 2;
            c /= 2;
        }

        return bits;
    }
}
