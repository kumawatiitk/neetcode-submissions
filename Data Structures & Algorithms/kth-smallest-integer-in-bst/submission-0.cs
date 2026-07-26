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
    public int KthSmallest(TreeNode root, int k) {
        
        var stack = new Stack<(TreeNode, bool)>();
        stack.Push((root, false));
        int count = 0;
        while(stack.Count != 0) {
            var (node, visited) = stack.Pop();

            if(visited == false) {

                if(node.right != null) {
                    stack.Push((node.right, false));
                }

                stack.Push((node, true));

                if(node.left != null) {
                    stack.Push((node.left, false));
                }

            } else {
                count++;
            }

            if(count == k) {
                return node.val;
            }
        }

        return -1;
    }
}
