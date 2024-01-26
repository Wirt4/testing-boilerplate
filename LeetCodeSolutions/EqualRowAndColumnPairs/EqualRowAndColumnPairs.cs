namespace LeetCodeSolutions;

public class EqualRowAndColumnPairsSolution{
    private class ArrayTracker{
        private readonly Dictionary<string, int> allArrs;
        public ArrayTracker(){
            allArrs = [];
        }

        private string StringifyArr(int[] arr){
            return string.Join("", arr);
        }
        public bool Contains(int[] arr){
            return allArrs.ContainsKey(StringifyArr(arr));
        }

        public void Add(int [] arr){
            string strArr = StringifyArr(arr);
            if (allArrs.ContainsKey(strArr)){
                allArrs[strArr]++;
                return;
            }

            allArrs.Add(strArr, 1);
        }

         public int NumberOfMatches(int [] column){
            string strCol = StringifyArr(column);
            if (!allArrs.TryGetValue(strCol, out int value)) return 0;
            return value;
        }
    }

    private class Grid{
        private int [][] grid;
        private readonly int length;
        public Grid(int [][] values){
            grid = values;
            length = values.Length;
        }

        public int[] Row(int index){
            return grid[index];
        }

        public int[] Column(int index){
            int[] column = new int[length];

            for (int rowNdx = 0; rowNdx < length; rowNdx++){
                column[rowNdx] = grid[rowNdx][index];
            }

            return column;
        }

        public int Length => length;

    }
    public int EqualPairs(int[][] grid) {
        int pairs = 0;
        ArrayTracker allRows = new();
        Grid gridWrapper = new Grid(grid);

        for (int i = 0; i < gridWrapper.Length; i++){
                allRows.Add(gridWrapper.Row(i));
        }

        for (int j = 0; j < gridWrapper.Length; j++){
            pairs += allRows.NumberOfMatches(gridWrapper.Column(j));
        }

        return pairs;
    }
}