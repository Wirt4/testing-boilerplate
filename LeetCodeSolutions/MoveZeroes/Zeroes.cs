namespace LeetCodeSolutions;
public class Zeroes{
    public void MoveZeroesByRef(ref int[] arr){
        if (arr.Length == 1){
            return;
        }

        int i = 0;
        int j = 0;

        while (i<arr.Length){
            while(arr[i] == 0){
                i++;
            }

            arr[j] = arr[i];
            j++;
            i++;
        }

        while (j < arr.Length){
            arr[j] = 0;
            j++;
        }

       
    }
}