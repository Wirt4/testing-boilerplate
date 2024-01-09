namespace LeetCodeSolutions;
public class Zeroes{

//return -1 if out of bounds
    private int nextIndexOfZero(int ndx, ref int[] arr){
        while(arr[ndx] == 0){
                ndx++;
                if (ndx >= arr.Length){
                    return -1;
                }
            }
            return ndx; 
    }
    public void MoveZeroesByRef(ref int[] arr){
        int lengthOfArr = arr.Length;
        if (lengthOfArr == 1){
            return;
        }

        int i = 0;
        int j = 0;

        while (i<lengthOfArr){
            i = nextIndexOfZero(i, ref arr);

            if (i < 0 ){
                break;
            }

            arr[j] = arr[i];
            j++;
            i++;
        }

        while (j < lengthOfArr){
            arr[j] = 0;
            j++;
        }

       
    }
}