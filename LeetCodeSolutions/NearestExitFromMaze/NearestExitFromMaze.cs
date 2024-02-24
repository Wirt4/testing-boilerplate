namespace LeetCodeSolutions;
public class NearestExitFromMazeSolution
{
    private class TravelNode
    {
        public int x;
        public int y;
    }

    private class Maze
    {
        private readonly char[][] _maze;
        private readonly int _width;
        private readonly int _height;

        public Maze(char[][] maze)
        {
            _maze = maze;
            _width = maze.Length;
            _height = maze[0].Length;
        }

        public bool AreValidCoords(TravelNode node)
        {
            return node.x >= 0 && node.x < _width && node.y >= 0 && node.y < _height && _maze[node.x][node.y] == '.';
        }

        public void MarkAsVisited(TravelNode node)
        {
            _maze[node.x][node.y] = '+';
        }

        public bool AtExit(TravelNode node)
        {
            return node.x == 0 || node.y == 0 || node.x == _width - 1 || node.y == _width - 1;
        }
    }

    public int NearestExit(char[][] maze, int[] entrance)
    {
        Maze mazeObj = new(maze);
        Queue<TravelNode> queue = new();
        TravelNode starter = new() { x = entrance[0], y = entrance[1] };
        queue.Enqueue(starter);
        mazeObj.MarkAsVisited(starter);
        int steps = 0;

        while (queue.Count > 0)
        {
            int size = queue.Count;

            for (int i = 0; i < size; i++)
            {
                TravelNode currentNode = queue.Dequeue();
                if (mazeObj.AtExit(currentNode))
                {
                    if (currentNode.x != entrance[0] || currentNode.y != entrance[1])
                    {
                        return steps;
                    }
                }

                TravelNode eastNode = new() { x = currentNode.x + 1, y = currentNode.y };
                if (mazeObj.AreValidCoords(eastNode))
                {
                    mazeObj.MarkAsVisited(eastNode);
                    queue.Enqueue(eastNode);
                }

                TravelNode westNode = new() { x = currentNode.x - 1, y = currentNode.y };
                if (mazeObj.AreValidCoords(westNode))
                {
                    mazeObj.MarkAsVisited(westNode);
                    queue.Enqueue(westNode);
                }

                TravelNode northNode = new() { x = currentNode.x, y = currentNode.y + 1 };
                if (mazeObj.AreValidCoords(northNode))
                {
                    mazeObj.MarkAsVisited(northNode);
                    queue.Enqueue(northNode);
                }

                TravelNode southNode = new() { x = currentNode.x, y = currentNode.y - 1 };
                if (mazeObj.AreValidCoords(southNode))
                {
                    mazeObj.MarkAsVisited(southNode);
                    queue.Enqueue(southNode);
                }
            }
            steps++;
        }
        return -1;
    }
}


