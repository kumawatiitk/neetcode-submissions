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
        
        var curr = root;
        var res = new List<int>();
        int count = k;
        while(curr != null) {

            if(curr.left != null) {
                var pred = curr.left;
                while(pred.right != null && pred.right != curr) {
                    pred = pred.right;
                }

                if(pred.right == null) {
                    pred.right = curr;
                    curr = curr.left;
                    continue;
                } else {
                    pred.right = null;
                }

            }

            count--;
                
            if(count == 0) {
                return curr.val;
            }

            curr = curr.right;

        }

        return -1;

    }
}
