/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {
    public int MaxPathSum(TreeNode root) {

        var (max1, max2) = MaxPathSumV1(root);
        return Math.Max(max1, max2);
    }

    public (int, int) MaxPathSumV1(TreeNode root) {

        if(root == null) return (0, int.MinValue);

        var (nodeL, maxL) = MaxPathSumV1(root.left);
        var (nodeR, maxR) = MaxPathSumV1(root.right);
        
        var nodeMax = Math.Max(Math.Max(nodeL + root.val, nodeR + root.val), root.val);
        return (nodeMax, Math.Max(Math.Max(nodeMax, Math.Max(maxL, maxR)), nodeL + nodeR + root.val));
    }


}
