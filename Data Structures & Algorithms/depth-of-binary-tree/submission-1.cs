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
    public int MaxDepth(TreeNode root) {
        var stack = new Stack<(TreeNode, int)>();
        var max = 0;
        if(root != null) {
            stack.Push((root, 1));
        }

        while(stack.Count != 0) {
            var (node, height) = stack.Pop();
            max = Math.Max(max, height);
            if(node.right != null) {
                stack.Push((node.right, height + 1));
            }
            if(node.left != null) {
                stack.Push((node.left, height + 1));
            }
        }

        return max;
    }
}
