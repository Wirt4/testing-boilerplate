namespace LeetCodeSolutions;
public class BinaryTreeRightSideViewSolution
{
    public IList<int> RightSideView(TreeNode? root)
    {
        if (root == null)
        {
            return [];
        }

        Queue<TreeNode> currentLevel = new();
        currentLevel.Enqueue(root);
        Queue<TreeNode> nextLevel = new();
        Stack<int> traversedHistory = new();
        List<int> answer = new();
        while (currentLevel.Count > 0)
        {
            TreeNode cur = currentLevel.Dequeue();
            traversedHistory.Push(cur.val);
            if (cur.left != null)
            {
                nextLevel.Enqueue(cur.left);
            }
            if (cur.right != null)
            {
                nextLevel.Enqueue(cur.right);
            }

            if (currentLevel.Count == 0)
            {
                currentLevel = nextLevel;
                nextLevel = new();
                answer.Add(traversedHistory.Pop());
            }
        }

        return [.. answer];

    }
}
