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
     public int Rob(int[] nums) {
        if (nums.Length ==1){
            return nums[0];
        }

        Stack <HouseValue> highestRoutes = new Stack<HouseValue>();
        HouseValue last = new HouseValue(nums.Length-1, nums[nums.Length-1]);
        HouseValue penultimate = new HouseValue(nums.Length -2, nums[nums.Length-2]);
        if (last.Value > penultimate.Value){
            highestRoutes.Push(penultimate);
            highestRoutes.Push(last);
        }else{
            highestRoutes.Push(last);
            highestRoutes.Push(penultimate);
        }

        //create a sorted stack that we never have to check if it's empty
        
        for (int i = nums.Length -3; i>= 0; i--){
            HouseValue current;
            if (highestRoutes.Peek().IsAdjacentTo(i)){
                HouseValue temp = highestRoutes.Pop();
                int lootValue =  highestRoutes.Peek().Value + nums[i];
                current = new HouseValue(i, lootValue);
                if (current.Value > temp.Value){
                    highestRoutes.Push(temp);
                    highestRoutes.Push(current);
                }else{
                    highestRoutes.Push(current);
                    highestRoutes.Push(temp);
                }

            }else{
                int lootValue =  highestRoutes.Peek().Value + nums[i];
                current = new HouseValue(i, lootValue);
                highestRoutes.Push(current);
            }
        }

          

            
    
        
        return highestRoutes.Pop().Value;
    }
}