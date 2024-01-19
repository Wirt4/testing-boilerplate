namespace LeetCodeSolutions;
public class VowelWindow{
    private class Window{
        private int _NumberOfVowels;
        private int _endNdx;
        private readonly int _offset;
        private readonly HashSet<char> _vowels;
        private readonly string  _str;

        private bool IsVowel(int ndx){
            return _vowels.Contains(_str[ndx]);

        }

        private void AdjustIfVowel(int ndx, int increment){
            if (IsVowel(ndx)) _NumberOfVowels += increment;
        }
        private void UptickIfVowel(int ndx){
            AdjustIfVowel(ndx, 1);
        }

        private void DowntickIfVowel(int ndx){
            AdjustIfVowel(ndx, -1);
        }
        public Window(string s, int k){
            _NumberOfVowels = 0;
            _str = s;
            _offset = k;
            _endNdx = _offset;
            _vowels = new HashSet<char>(['a', 'e', 'i', 'o', 'u']);

            for (int i=0; i< k; i++){
                UptickIfVowel(i);
            }
        }
        public int NumberOfVowels => _NumberOfVowels;

        public bool HasAdditionalSpace => _endNdx < _str.Length;

        public void Shift(){
            DowntickIfVowel(_endNdx - _offset);
            UptickIfVowel(_endNdx);

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