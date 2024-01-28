namespace LeetCodeSolutions;
public class AsteroidCollisionSolution {
   
    public int[] AsteroidCollision(int[] asteroids) {
        Stack<int> stableAsteroids = new();

        foreach(int roid in asteroids){
            if (stableAsteroids.Count == 0){
                stableAsteroids.Push(roid);
                continue;
            }

            if (stableAsteroids.Peek() < 0 && roid < 0){
                stableAsteroids.Push(roid);
                continue;
            }


            // in this case, the rightmost asteroid of the array and the new asteroid will never intersect
            if (stableAsteroids.Peek() < 0 && roid > 0){
                stableAsteroids.Push(roid);
                continue;
            }

            if (stableAsteroids.Peek() > 0 && roid > 0){
                stableAsteroids.Push(roid);
                continue;
            }
            
            //the remaining possiblility is a positive moving stack asteroid and negatively moving new asteroid
            while (stableAsteroids.Count > 0 && stableAsteroids.Peek() < Math.Abs(roid)){
                stableAsteroids.Pop(); // all geting smacked by the new 'roid
            }

            if (stableAsteroids.Count == 0){
                stableAsteroids.Push(roid);
            }

            if (stableAsteroids.Count > 0 && stableAsteroids.Peek() + roid == 0){
                stableAsteroids.Pop();
                continue;
            }



           

        }

        int [] stableAsteroidsArr = [.. stableAsteroids];
        Array.Reverse(stableAsteroidsArr);
        return stableAsteroidsArr;
    }
}
