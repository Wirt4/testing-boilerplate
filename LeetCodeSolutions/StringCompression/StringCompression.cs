namespace LeetCodeSolutions;

public class StringCompression{
       //TODO: split into a void that edits the array directly, then return the length with "Compress"
    public int CompressString(ref char[] chars){
        
        if (chars.Length==1){
            return 1;
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

        Array.Resize(ref chars, j);
        return j;
    }
    public int Compress( char [] chars){
        return CompressString(ref chars);
    }
       
}