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

        private Boolean AllRoomsTraversed(bool[] visited)
        {
            foreach (bool room in visited)
            {
                if (room) continue;

                return false;
            }

            return true;
        }

        private Boolean DFSUtil(bool[] visited, int roomNumber = 0)
        {
            visited[roomNumber] = true;

            if (AllRoomsTraversed(visited)) return true;

            foreach (var key in _rooms[roomNumber])
            {
                if (!visited[key] && DFSUtil(visited, key)) return true;
            }

            return false;
        }
        public Boolean DepthFirstSearch()
        {
            return DFSUtil(new bool[_rooms.Count]);
        }
    }
    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        Rooms roomGraph = new(rooms);
        return roomGraph.DepthFirstSearch();
    }
}
