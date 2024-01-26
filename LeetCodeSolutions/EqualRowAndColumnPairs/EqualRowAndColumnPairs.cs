namespace LeetCodeSolutions;

public class EqualRowAndColumnPairsSolution{
    public int EqualPairs(int[][] grid) {
        int pairs = 0;
        // create a set of the rows
       HashSet<string> rows = new();
        for (int i = 0; i< grid.Length; i++){
            string row = string.Join("", grid[i]);
            if (rows.Contains(row)) pairs ++;
            rows.Add(row);
            
        }
        

        for (int rowNdx = 0; rowNdx < grid.Length; rowNdx++){
            int [] col = new int[grid.Length];
            for (int colNdx=0; colNdx < grid.Length; colNdx++){
                col[colNdx] = grid[colNdx][rowNdx];
            }
            string strCol = string.Join("", col);
            if (rows.Contains(strCol)){
                pairs ++;

                // then remove it
            }
        }
        
        return pairs;
    }
}