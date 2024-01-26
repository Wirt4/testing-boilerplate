using System.Runtime.CompilerServices;

namespace LeetCodeSolutions;

public class EqualRowAndColumnPairsSolution{
    private class ArrayTracker{
        private readonly HashSet<string> allArrs;
        public ArrayTracker(){
            allArrs = [];
        }

        private string StringifyArr(int[] arr){
            return string.Join("", arr);
        }
        public bool Contains(int[] arr){
            return allArrs.Contains(StringifyArr(arr));
        }

        public void Add(int [] arr){
            allArrs.Add(StringifyArr(arr));
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
            if (allRows.Contains(gridWrapper.Row(i))){
                pairs ++;
            }else{
                allRows.Add(gridWrapper.Row(i));
            }
        }

        for (int j = 0; j < gridWrapper.Length; j++){
            if (allRows.Contains(gridWrapper.Column(j))){
                pairs ++;
            }
        }

        return pairs;
    }
}