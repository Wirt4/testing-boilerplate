using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Globalization;

namespace LeetCodeSolutions;

public class StringCompression{
       
       
    public int Compress( char [] chars){
        char lastChar= 'z';
        int readIndex = 0;
        int writeIndex = 1;
        int initialLength = chars.Length;
        int count = 0;


      

        while (readIndex < initialLength){
            bool isStart = readIndex == 0;
            bool isEnd = readIndex == initialLength -1;

            if (isStart && isEnd){
                return 1;
            }

            if (isStart){
                lastChar = chars[readIndex];
                count = 1;
                readIndex++;
                continue;
            }

            if (isEnd){
                if (count > 1){
                   foreach(char digit in count.ToString()){
                    chars[writeIndex] = digit;
                    writeIndex++;
                   }


                }
                break;
            }

            if (lastChar == chars[readIndex]){
                count ++;
                readIndex++;
                continue;
            }
            char temp = chars[readIndex];
            chars[writeIndex] = lastChar;
            lastChar = temp;
            writeIndex++;

            if (count > 1){
                   foreach(char digit in count.ToString()){
                    chars[writeIndex] = digit;
                    writeIndex++;
                   }


            }
            count = 1;
            readIndex++;
        }

        return writeIndex;

        
    }
       
}