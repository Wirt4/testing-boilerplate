namespace LeetCodeSolutions;

public class StringCompression{

    private void writeCountToArray(int count, ref char[] chars, ref int writeIndex){
        writeIndex ++;
        if (count > 1){
            foreach (char digit in count.ToString()){
                chars[writeIndex] = digit;
                writeIndex ++;
                }
            }
    }
    public int CompressString(ref char[] chars){
        int initialLength = chars.Length;
        bool requiresCompression = false;

        for (int i = 1;  i < initialLength; i++){
            if (chars[i] == chars[i-1]){
                requiresCompression = true;
                break;
            }
        }

        if (!requiresCompression){
            return initialLength;
        }
        //will also be used for final length
        int writeIndex = 0;
        char lastChar = ' ';
        int count = - 1;

        for (int i=0; i< initialLength; i++){
            bool firstIndex = i == 0;
            bool lastIndex = i == initialLength - 1;
            bool sameCharAsPrevious = chars[i] == lastChar;

            if (firstIndex){
                lastChar = chars[i];
                count = 0;
            }

            if(lastIndex){
                char temp = chars[i];
                chars[writeIndex] = lastChar;

                if (sameCharAsPrevious){
                    count++;
                }

                writeCountToArray(count, ref chars, ref writeIndex);
                if (sameCharAsPrevious){
                    break;
                }

                chars[writeIndex] = temp;
                writeIndex++;
                break;
            }

            if (!sameCharAsPrevious && !firstIndex){
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
        // pass by ref here to make the tester for Leetcode work
        // the signature of the wrapper function itself may not be tested
        return CompressString(ref chars);
    }
       
}