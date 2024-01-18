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
     
     private void PushinSequnce(HouseValue a, HouseValue b, ref Stack<HouseValue> stack){
        if (a.Value > b.Value){
            stack.Push(b);
            stack.Push(a);
            return;
        }
        stack.Push(a);
        stack.Push(b);
     }

     private HouseValue createCurrent(ref int[] nums, int index, ref Stack<HouseValue> houseStack){
        return new HouseValue(index, houseStack.Peek().Value + nums[index]);
     }
     public int Rob(int[] nums) {
        if (nums.Length ==1){
            return nums[0];
        }

        int lastIndex =  nums.Length -1;
        HouseValue last = new HouseValue(lastIndex, nums[lastIndex]);

        int penultimateIndex = lastIndex -1;
        HouseValue penultimate = new HouseValue(penultimateIndex, nums[penultimateIndex]);
        Stack <HouseValue> highestRoutes = new Stack<HouseValue>();
        PushinSequnce(last,penultimate, ref highestRoutes);
       

        //create a sorted stack that we never have to check if it's empty
        
        for (int i = penultimateIndex - 1; i>= 0; i--){
            HouseValue current;
            if (highestRoutes.Peek().IsAdjacentTo(i)){
                HouseValue temp = highestRoutes.Pop();

                current = createCurrent(ref nums, i, ref highestRoutes);

                PushinSequnce(temp, current, ref highestRoutes);
                continue;
            }

            current = createCurrent(ref nums, i, ref highestRoutes);;
            highestRoutes.Push(current);
            
        }
        
        return highestRoutes.Pop().Value;
    }
}