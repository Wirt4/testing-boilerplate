namespace LeetCodeSolutions;

public class StringCompression{
       //TODO: split into a void that edits the array directly, then return the length with "Compress"
    public void CompressString(ref char[] chars){
        if (chars.Length==1){
            return;
        }

        char lastChar = ' ';
        int j = 0;
        int count= -1;

        for (int i=0; i< chars.Length; i++){
            if (i == 0){
                lastChar = chars[i];
                count = 0;
            }

            if(i == chars.Length - 1){
                count++;
                j++;
                if (count > 1){
                    foreach (char digit in count.ToString()){
                        chars[j] = digit;
                        j++;
                    }
                }
                 Array.Resize(ref chars, j);
                 break;

            }

            if (lastChar != chars[i]){
                char temp = chars[i];
                chars[j] = lastChar;
                j++;

                if (count > 1){
                    foreach (char digit in count.ToString()){
                        chars[j] = digit;
                        j++;
                    }
                }

                lastChar = temp;
                count = 1;
                continue;
            }

            count ++;

        }
    }
    public int Compress( char [] chars){
        CompressString(ref chars);
        return chars.Length;
    }
       
}