using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace LeetCodeSolutions;
public class VowelWindow{
    private class Window{
        private int _NumberOfVowels;
        private int _endNdx;
        private readonly int _windowLength;
        private readonly int _offset;
        private readonly HashSet<char> _vowels;
        private readonly string  _str;

        private bool IsVowel(int ndx){
            return _vowels.Contains(_str[ndx]);

        }
        public Window(string s, int k){
            _NumberOfVowels = 0;
            _str = s;
            _windowLength = s.Length;
            _offset = k;
            _endNdx = _offset;
            _vowels = new HashSet<char>(['a', 'e', 'i', 'o', 'u']);

            for (int i=0; i< k; i++){
                if (IsVowel(i)){
                    _NumberOfVowels++;
                }
            }
        }
       /// current number of values in window 
        public int NumberOfVowels => _NumberOfVowels;

        /// Returns whether the shift operation can be peformed without throwing
        public bool HasAdditionalSpace => _endNdx < _windowLength;

        
    /** 
        moves the "window" one index to the right and updates the vowell count accordingly
    */
        public void Shift(){
            if (IsVowel(_endNdx - _offset)){
                _NumberOfVowels--;
            }

            if(IsVowel(_endNdx)){
                _NumberOfVowels++;
            }

            _endNdx++;
        }
    }

      public int MaxVowels(string s, int k) {
        Window window = new Window(s, k);
        int maxVowels = window.NumberOfVowels;

        while (window.HasAdditionalSpace){
            window.Shift();
            if (window.NumberOfVowels > maxVowels){
                maxVowels = window.NumberOfVowels;
            }

        }

        return maxVowels;
       
    }
}