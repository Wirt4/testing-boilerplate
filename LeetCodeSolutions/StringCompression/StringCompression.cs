namespace LeetCodeSolutions;

public class StringCompression{

    private void writeCountToArray(int count, ref char[] chars, ref int writeIndex){
        writeIndex++;
        if (count > 1){
            foreach (char digit in count.ToString()){
                chars[writeIndex] = digit;
                writeIndex++;
                }
            }
    }
    public int CompressString(ref char[] chars){
        int initialLength = chars.Length;

        if (initialLength==1){
            //array of one, no change
            return initialLength;
        }

        int writeIndex = 0;
        char lastChar = ' ';
        int count = - 1;

        for (int i=0; i< initialLength; i++){
            bool firstIndex = i == 0;
            bool lastIndex = i == initialLength - 1;

            if (firstIndex){
                lastChar = chars[i];
                count = 0;
            }

            if(lastIndex){
                count++;

                writeCountToArray(count, ref chars, ref writeIndex);
                break;
            }

            if (lastChar != chars[i]){
                char temp = chars[i];
                chars[writeIndex] = lastChar;
                lastChar = temp;

                writeCountToArray(count, ref chars, ref writeIndex);

                count = 1;
                continue;
            }

            count ++;
        }

        Array.Resize(ref chars, writeIndex);
        return writeIndex;
    }
    public int Compress( char [] chars){
        return CompressString(ref chars);
    }
       
}