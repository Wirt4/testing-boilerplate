namespace LeetCodeSolutions;
public class AsteroidCollisionSolution {
    private class StackWrapper{
        private readonly Stack <int> _stack;
        public StackWrapper(){
            _stack =  new();
        }

        public void Push(int item){
            _stack.Push(item);
        }

        public bool HasMatchingSigns(int item){
            if (IsEmpty) return true;
            if (_stack.Peek() < 0 && item < 0 ) return true;
            return _stack.Peek() > 0 && item > 0;
        }

        public bool WillCollide(int item){
            return !(_stack.Peek() < 0 && item > 0);
        }

        public bool HasDominantCollision(int item){
            return ! IsEmpty && _stack.Peek() < Math.Abs(item);
        }

        public bool HasEqualCollision(int item){
           return  !IsEmpty && _stack.Peek() + item == 0;
        }

        public void Pop(){
            _stack.Pop();
        }

        public int[] ToArray(){
        int [] arr = [.. _stack];
        Array.Reverse(arr);
        return arr;
        }

        public bool IsEmpty => _stack.Count == 0;
    }
   
    public int[] AsteroidCollision(int[] asteroids) {
        StackWrapper stableAsteroids =  new();
        foreach(int roid in asteroids){
            if (stableAsteroids.IsEmpty || stableAsteroids.HasMatchingSigns(roid) || !stableAsteroids.WillCollide(roid)){
                stableAsteroids.Push(roid);
                continue;
            }

            while (stableAsteroids.HasDominantCollision(roid)){
                    stableAsteroids.Pop();
            }

            if (stableAsteroids.IsEmpty){
                stableAsteroids.Push(roid);
                    continue;
            }

            if (stableAsteroids.HasEqualCollision(roid)){
                stableAsteroids.Pop();
            }
        }

        return stableAsteroids.ToArray();
    }
}
