using System.Runtime.CompilerServices;

namespace LeetCodeSolutions;
public class LongestCommonSubsequenceSolution
{
    private class DynamicProgrammingTable
    {
        private int[][] _table;
        private string _a;
        private string _b;
        public DynamicProgrammingTable(string a, string b)
        {
            _a = a;
            _b = b;
            AllocateTableSpace(a.Length, b.Length);
            PopulateTableValues();
        }
        private void AllocateTableSpace(int iLength, int bLength)
        {
            _table = new int[iLength + 1][];
            for (int i = 0; i < _table.Length; i++)
            {
                _table[i] = new int[bLength + 1];
            }
        }

        private void PopulateTableValues()
        {
            for (int ndxA = _a.Length; ndxA >= 0; ndxA--)
            {
                for (int ndxB = _b.Length; ndxB >= 0; ndxB--)
                {
                    _table[ndxA][ndxB] = CurrentLength(ndxA, ndxB);
                }
            }
        }

        private int CurrentLength(int ndxA, int ndxB)
        {
            if (ndxA >= _a.Length || ndxB >= _b.Length) { return 0; }

            if (_a[ndxA] == _b[ndxB]) { return 1 + _table[ndxA + 1][ndxB + 1]; }

            return Math.Max(_table[ndxA + 1][ndxB], _table[ndxA][ndxB + 1]);
        }
        public int LongestCommonSubsequence => _table[0][0];
    }
    public int LongestCommonSubsequence(string text1, string text2)
    {
        DynamicProgrammingTable table = new(text1, text2);
        return table.LongestCommonSubsequence;
    }
}
