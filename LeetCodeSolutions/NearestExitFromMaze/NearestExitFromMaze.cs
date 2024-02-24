namespace LeetCodeSolutions;
public class NearestExitFromMazeSolution
{
    private class TravelNode
    {
        public int x;
        public int y;
    }

    private bool IsValid(int x, int y, int n, int m)
    {
        return x >= 0 && x < n && y >= 0 && y < m;
    }
    public int NearestExit(char[][] maze, int[] entrance)
    {
        int n = maze.Length;
        int m = maze[0].Length;

        Queue<TravelNode> queue = new();
        queue.Enqueue(new() { x = entrance[0], y = entrance[1] });
        maze[entrance[0]][entrance[1]] = '+';
        int steps = 0;
        while (queue.Count > 0)
        {
            int size = queue.Count;

            for (int i = 0; i < size; i++)
            {
                TravelNode currentNode = queue.Dequeue();
                if (currentNode.x == 0 || currentNode.y == 0 || currentNode.x == n - 1 || currentNode.y == m - 1)
                {
                    if (currentNode.x != entrance[0] || currentNode.y != entrance[1])
                    {
                        return steps;
                    }
                }

                if (IsValid(currentNode.x + 1, currentNode.y, n, m) && maze[currentNode.x + 1][currentNode.y] == '.')
                {
                    maze[currentNode.x + 1][currentNode.y] = '+';
                    queue.Enqueue(new() { x = currentNode.x + 1, y = currentNode.y });
                }

                if (IsValid(currentNode.x - 1, currentNode.y, n, m) && maze[currentNode.x - 1][currentNode.y] == '.')
                {
                    maze[currentNode.x - 1][currentNode.y] = '+';
                    queue.Enqueue(new() { x = currentNode.x - 1, y = currentNode.y });
                }

                if (IsValid(currentNode.x, currentNode.y + 1, n, m) && maze[currentNode.x][currentNode.y + 1] == '.')
                {
                    maze[currentNode.x][currentNode.y + 1] = '+';
                    queue.Enqueue(new() { x = currentNode.x, y = currentNode.y + 1 });
                }

                if (IsValid(currentNode.x, currentNode.y - 1, n, m) && maze[currentNode.x][currentNode.y - 1] == '.')
                {
                    maze[currentNode.x][currentNode.y - 1] = '+';
                    queue.Enqueue(new() { x = currentNode.x, y = currentNode.y - 1 });
                }
            }
            steps++;
        }
        return -1;
    }
}


