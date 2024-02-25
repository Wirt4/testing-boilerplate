namespace LeetCodeSolutions;
public class NearestExitFromMazeSolution
{
    private class TravelNode
    {
        public int x;
        public int y;

        public bool EquivalentTo(int[] coords)
        {
            return x == coords[0] && y == coords[1];
        }
    }

    private class Maze
    {
        private readonly char[][] _maze;
        private readonly int _width;
        private readonly int _height;

        private Queue<TravelNode> _queue;

        public int Steps;

        public Maze(char[][] maze, int[] entrance)
        {
            _maze = maze;
            _width = maze.Length;
            _height = maze[0].Length;
            _queue = new();
            Steps = 0;

            PushIfValid(new() { x = entrance[0], y = entrance[1] });
        }

        private void PushIfValid(TravelNode node)
        {
            if (AreValidCoords(node))
            {
                MarkAsVisited(node);
                _queue.Enqueue(node);
            }
        }

        public void PushNeighborsToQueue(TravelNode node)
        {
            int x = node.x;
            int y = node.y;
            PushIfValid(new() { x = x + 1, y = y });
            PushIfValid(new() { x = x - 1, y = y });
            PushIfValid(new() { x = x, y = y + 1 });
            PushIfValid(new() { x = x, y = y - 1 });
        }

        public TravelNode PopFromQueue()
        {
            return _queue.Dequeue();
        }
        private bool AreValidCoords(TravelNode node)
        {
            return IsWithinRange(node.x, _width) && IsWithinRange(node.y, _height) && _maze[node.x][node.y] == '.';
        }

        public bool HasUnexploredSquares()
        {
            return _queue.Count > 0;
        }

        public int NumberOfAdjacentSquares()
        {
            return _queue.Count;
        }

        private static bool IsWithinRange(int index, int length)
        {
            return index >= 0 && index < length;
        }

        private void MarkAsVisited(TravelNode node)
        {
            _maze[node.x][node.y] = '+';
        }

        public bool AtExit(TravelNode node)
        {
            return FirstOrLastIndex(node.x, _width) || FirstOrLastIndex(node.y, _height);
        }

        private static bool FirstOrLastIndex(int ndx, int length)
        {
            return ndx == 0 || ndx == length - 1;
        }
    }

    public int NearestExit(char[][] maze, int[] entrance)
    {
        Maze mazeRunner = new(maze, entrance);

        while (mazeRunner.HasUnexploredSquares())
        {
            int squares = mazeRunner.NumberOfAdjacentSquares();

            for (int i = 0; i < squares; i++)
            {
                TravelNode currentNode = mazeRunner.PopFromQueue();

                if (mazeRunner.AtExit(currentNode) && !currentNode.EquivalentTo(entrance))
                {
                    return mazeRunner.Steps;
                }

                mazeRunner.PushNeighborsToQueue(currentNode);
            }

            mazeRunner.Steps++;
        }

        return -1;
    }
}


