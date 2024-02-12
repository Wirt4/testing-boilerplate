namespace LeetCodeSolutions;
public class BinaryTreeRightSideViewSolution
{
    private class QueuePair
    {
        public Queue<TreeNode> currentLevel;
        public Queue<TreeNode> nextLevel;
        public QueuePair(TreeNode root)
        {
            nextLevel = new();
            currentLevel = new();
            currentLevel.Enqueue(root);
        }
    }
    public IList<int> RightSideView(TreeNode? root)
    {
        QueuePair queues = new(root);
        Stack<int> traversedHistory = new();
        List<int> answer = new();
        while (queues.currentLevel.Count > 0)
        {
            TreeNode cur = queues.currentLevel.Dequeue();
            traversedHistory.Push(cur.val);

            if (cur.left != null)
            {
                queues.nextLevel.Enqueue(cur.left);
            }
            if (cur.right != null)
            {
                queues.nextLevel.Enqueue(cur.right);
            }

            if (queues.currentLevel.Count == 0)
            {
                queues.currentLevel = queues.nextLevel;
                queues.nextLevel = new();
                answer.Add(traversedHistory.Pop());
            }
        }

        return [.. answer];

    }
}
