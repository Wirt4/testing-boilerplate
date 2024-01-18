using System.Data;

namespace LeetCodeSolutions;

public class HouseRobber{
    private class HouseValue{
        private readonly int _location;
        private readonly int _value;
        public HouseValue(int location, int routeValue){
            _location = location;
            _value = routeValue;

        }

        public int Location => _location;
        public int Value => _value;
        public bool IsAdjacentTo(int ndx){
            return Math.Abs(ndx - _location) == 1;
        }
    }
     
    private class SortedHouseValues{
        private Stack<HouseValue> stack;
        public SortedHouseValues(){
            stack = new Stack<HouseValue>();
        }

        public void PushinSequnce(HouseValue a, HouseValue b){
            if (a.Value > b.Value){
            stack.Push(b);
            stack.Push(a);
            return;
        }
        stack.Push(a);
        stack.Push(b);
        }

        public HouseValue createCurrent(int value, int index ){
            return new HouseValue(index, value + stack.Peek().Value );
        }

        public bool TopIsAdjacent(int index){
            return stack.Peek().IsAdjacentTo(index);
        }

        public HouseValue Pop(){
            return stack.Pop();
        }

        public void Push(HouseValue v){
            stack.Push(v);
        }
    }

     public int Rob(int[] nums) {
        if (nums.Length ==1){
            return nums[0];
        }

        int lastIndex =  nums.Length -1;
        HouseValue last = new HouseValue(lastIndex, nums[lastIndex]);

        int penultimateIndex = lastIndex -1;
        HouseValue penultimate = new HouseValue(penultimateIndex, nums[penultimateIndex]);
        SortedHouseValues houseValues = new SortedHouseValues();
        houseValues.PushinSequnce(last,penultimate);
       

        //create a sorted stack that we never have to check if it's empty
        
        for (int i = penultimateIndex - 1; i>= 0; i--){
            HouseValue current;
            if (houseValues.TopIsAdjacent(i)){
                HouseValue temp = houseValues.Pop();
                current = houseValues.createCurrent(nums[i], i);
                houseValues.PushinSequnce(temp, current);
                continue;
            }

            current = houseValues.createCurrent(nums[i], i);
            houseValues.Push(current);
            
        }
        
        return houseValues.Pop().Value;
    }
}