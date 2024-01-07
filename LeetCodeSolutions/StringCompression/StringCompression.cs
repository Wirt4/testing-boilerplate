using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Globalization;

namespace LeetCodeSolutions;

public class StringCompression{
    private class Clicker{
        private int count;
        private int length;

        public Clicker(){
            length = 0;
        }
        public void initiateNewChar(){
            count = 1;
        }

        public void click(){
            count++;
        }

        public void finish(){
            updateLength();
        }

        public void updateLength(){
            length++;

            if (count ==1 ){
                return;
            }

            do{
                length++;
                count /=10;
            }while(count >10);
        }
        public int Length{
            get{return length;}
        }
    }
    public int Compress(char [] chars){
        Clicker c = new Clicker();
        for (int i=0; i< chars.Length; i++){
            if (i==0){
                c.initiateNewChar();
                continue;
            }

            if (i == chars.Length-1){
                c.finish();
                continue;
            }

            if (chars[i] == chars[i-1]){
                c.click();
                continue;
            }
            
            c.updateLength();
            c.initiateNewChar();
        
        }
       return c.Length;
    }
       
}