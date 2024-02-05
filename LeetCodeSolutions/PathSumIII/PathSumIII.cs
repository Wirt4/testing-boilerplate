namespace LeetCodeSolutions;
public class PathSumIIISolution
{

    public int PathSum(TreeNode root, int targetSum, int currentSum = 0)
    {
        //base case
        if (root != null)
        {
            if (root.val == targetSum)
            {
                return 1 + PathSum(root.left, targetSum) + PathSum(root.right, targetSum);
            }

            //root < 0, target <0 and currentSum < 0
            if (root.val < 0 && targetSum < 0 && currentSum < 0)
            {
                if (root.val < targetSum)
                {
                    return PathSum(root.left, targetSum) + PathSum(root.right, targetSum);
                }
            }

            //root < 0 target <0 and currentSum >=0

            //root < 0 target >=0 and currentSum <0

            //root < 0 target >=0 and currentSum >=0

            //root >=0, target <0 and currentSum <0

            //root >=0 target <0 and currentSum >=0

            //root >=0 target >=0 and currentSum <0
            //root >=0, target >=0 and currentSum >=0

        }
        return 0;
    }
}
