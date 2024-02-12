namespace LeetCodeSolutions;
public class BinaryTreeRightSideViewSolution
{
    public IList<int> RightSideView(TreeNode? root)
    {
        List<int> returnList = new();
        int level = 0;
        Queue<TreeNode?> levelTraversalQueue = new();

        levelTraversalQueue.Enqueue(root);
        while (levelTraversalQueue.Count > 0)
        {
            Stack<int> valueStack = new();
            for (int i = 0; i < (int)Math.Pow(2, level); i++)
            {
                TreeNode? cur = levelTraversalQueue.Dequeue();
                if (cur == null) continue;
                levelTraversalQueue.Enqueue(cur.left);
                levelTraversalQueue.Enqueue(cur.right);
                valueStack.Push(cur.val);
            }
            if (valueStack.TryPop(out int value))
            {
                returnList.Add(value);
            }
        }

        return [.. returnList];
    }
}
