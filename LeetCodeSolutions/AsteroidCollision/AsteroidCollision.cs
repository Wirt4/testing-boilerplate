using System.ComponentModel;

namespace LeetCodeSolutions;
public class AsteroidCollisionSolution {
    private class StackWrapper{
        private readonly Stack <int> _stack;
        public StackWrapper(){
            _stack = new();
        }

        private bool HasMatchingSigns(int item){
            if (_stack.Peek() < 0 && item < 0 ){
                return true;
            }
            
            return _stack.Peek() > 0 && item > 0;
        }

        private bool WontCollide(int item){
            return _stack.Peek() < 0 && item > 0;
        }

        private bool HasCollision(int item, bool isEqual = false){
            if (IsEmpty){
                return false;
            }

            int diff = Math.Abs(item) - _stack.Peek();

            if (isEqual){
                return diff == 0;
            }

            return diff > 0;

        } 

        public void Push(int item){
            _stack.Push(item);
        }

        public bool HasDominantCollision(int item){
            return HasCollision(item);
        }

        public bool HasEqualCollision(int item){
            return HasCollision(item, true);
        }

        public void Pop(){
            _stack.Pop();
        }

        public int[] ToArray(){
            return [.. new Stack<int>(_stack)];
        }

        public bool WillBeStableWhenAdded(int item){
            return IsEmpty || HasMatchingSigns(item) || WontCollide(item);
        }

        public bool IsEmpty => _stack.Count == 0;
    }
   
    public int[] AsteroidCollision(int[] asteroids) {
        StackWrapper stableAsteroids =  new();
        foreach(int roid in asteroids){
            if (stableAsteroids.WillBeStableWhenAdded(roid)){
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
