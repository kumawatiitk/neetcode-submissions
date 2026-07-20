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
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        
        if(root == null && subRoot == null) return true;
        if(subRoot == null) return true;
        if(root == null) return  false;

        if(IsSame(root, subRoot))  {
            return true;
        } 

        return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
    }

    public bool IsSame(TreeNode node1, TreeNode node2) {
        if(node1 == null && node2 == null) return true;
        if(node1 == null || node2 == null) return  false;

        if(node1.val != node2.val) return false;

        return IsSame(node1.right, node2.right) && IsSame(node1.left, node2.left);
    }
}
