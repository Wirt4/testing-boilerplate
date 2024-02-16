using System.Dynamic;

namespace LeetCodeSolutions;
public class KeysAndRoomsSolution
{


    private class Rooms
    {
        private IList<IList<int>> _rooms;
        public Rooms(IList<IList<int>> rooms)
        {
            _rooms = rooms;
        }

        private bool DFSUtil(int v, bool[] visited)
        {
            visited[v] = true;
            bool traversed = true;
            foreach (bool thing in visited)
            {
                if (!thing)
                {
                    traversed = false;
                    break;
                }
            }

            if (traversed)
            {
                return true;
            }

            IList<int> vList = _rooms[v];
            foreach (var n in vList)
            {
                if (!visited[n])
                {
                    bool path = DFSUtil(n, visited);
                    if (path)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public Boolean DepthFirstSearch(int startRoom)
        {
            bool[] visited = new bool[_rooms.Count];
            return DFSUtil(startRoom, visited);
        }

    }
    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        Rooms roomGraph = new(rooms);
        return roomGraph.DepthFirstSearch(0);

    }
}
