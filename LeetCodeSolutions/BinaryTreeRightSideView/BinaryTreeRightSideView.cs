namespace LeetCodeSolutions;
public class BinaryTreeRightSideViewSolution
{
    public IList<int> RightSideView(TreeNode root)
    {
        List<int> returnList = new();
        TreeNode cursor = root;
        while (cursor != null)
        {
            returnList.Add(cursor.val);
            cursor = cursor.right;
        }

        return [.. returnList];
    }
}
