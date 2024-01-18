namespace LeetCodeSolutions;

public class HouseRobber{
    private class House{
        private readonly int _location;
        private int _value;
        public House(int routeValue, int location){
            _location = location;
            _value = routeValue;
        }

        public int Location => _location;
        public int Value => _value;
        public bool IsNextDoor(House house){
            return Math.Abs(house.Location - _location) == 1;
        }

        public void AddValue(int additionalValue){
            _value += additionalValue;
        }
    }
     
    private class SortedHouseValues{
        private readonly Stack<House> stack;
        public SortedHouseValues(){
            stack = new Stack<House>();
        }

        public void PushinSequnce(House a, House b){
            if (a.Value > b.Value){
            stack.Push(b);
            stack.Push(a);
            return;
        }

        stack.Push(a);
        stack.Push(b);
        }

        //can this take a House Argument as a thing?
        public bool TopIsNextDoor(House house){
            return stack.Peek().IsNextDoor(house);
        }

        public House Pop(){
            return stack.Pop();
        }

        public void Push(House v){
            stack.Push(v);
        }

        public int TopValue(){
            return stack.Peek().Value;
        }

    }

     public int Rob(int[] nums) {
        if (nums.Length == 1){
            return nums[0];
        }

        int lastIndex =  nums.Length -1;
        House last = new House(nums[lastIndex], lastIndex);
        
        int penultimateIndex = lastIndex - 1;
        House penultimate = new House(nums[penultimateIndex], penultimateIndex);

        SortedHouseValues houseValues = new SortedHouseValues();
        houseValues.PushinSequnce(last, penultimate);
       
        for (int i = penultimateIndex - 1; i >= 0; i--){
            House current = new House(nums[i], i);
            if (houseValues.TopIsNextDoor(current)){
                House temp = houseValues.Pop();
                current.AddValue(houseValues.TopValue());
                houseValues.PushinSequnce(temp, current);
                continue;
            }

            current.AddValue(houseValues.TopValue());
            houseValues.Push(current);
            
        }
        
        return houseValues.TopValue();
    }
}