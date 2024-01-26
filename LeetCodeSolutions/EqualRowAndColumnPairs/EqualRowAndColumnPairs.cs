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
    public int EqualPairs(int[][] grid) {
       int pairs = 0;
        // create a set of the rows
        ArrayTracker tracker = new();

        for (int i = 0; i< grid.Length; i++){
            if (tracker.Contains(grid[i])) pairs ++;
            tracker.Add(grid[i]);
            
        }
        

        for (int rowNdx = 0; rowNdx < grid.Length; rowNdx++){
            int [] col = new int[grid.Length];
            for (int colNdx=0; colNdx < grid.Length; colNdx++){
                col[colNdx] = grid[colNdx][rowNdx];
            }
            
            if (tracker.Contains(col)){
                pairs ++;
            }
        }
        
        return pairs;
    }
}