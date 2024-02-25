
namespace LeetCodeSolutions;
public class KthLargestElementSolution
{

    private class Heap(int size)
    {
        private readonly int[] _arr = new int[size + 1];
        private int _treeSize = 0;

        public void Insert(int num)
        {
            _treeSize++;
            _arr[_treeSize] = num;
            HeapifyUp(_treeSize);

        }

        private void SwapIfSmaller(int parentNdx, int childIndx)
        {
            if (_arr[childIndx] < _arr[parentNdx])
            {
                (_arr[parentNdx], _arr[childIndx]) = (_arr[childIndx], _arr[parentNdx]);
            }
        }
        private void HeapifyUp(int index)
        {
            if (index <= 1)
            {
                return;
            }

            int parentNdx = index / 2;
            SwapIfSmaller(parentNdx, index);
            HeapifyUp(parentNdx);
        }
        public int Size => _treeSize;
        public void RemoveHead()
        {
            _arr[1] = _arr[_treeSize];
            _treeSize--;
            HeapifyDown(1);
        }

        private void HeapifyDown(int index)
        {
            int left = index * 2;
            //no children
            if (_treeSize < left) { return; }
            //only the left node
            if (_treeSize == left)
            {
                SwapIfSmaller(index, left);
                return;
            }

            int right = left + 1;

            int smallestChildIndex = _arr[left] < _arr[right] ? left : right;
            SwapIfSmaller(index, smallestChildIndex);
            HeapifyDown(smallestChildIndex);
        }

        public int Peek()
        {
            return _arr[1];
        }
    }


    public int FindKthLargest(int[] nums, int k)
    {
        Heap heap = new(nums.Length);

        foreach (int num in nums)
        {
            heap.Insert(num);

            if (heap.Size > k)
            {
                heap.RemoveHead();
            }
        }
        return heap.Peek();
    }
}
