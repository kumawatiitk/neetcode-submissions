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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        return BuildTree(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
    }

    public TreeNode BuildTree(int[] preorder, int ps, int pe, int[] inorder, int iss, int ie) 
    {
        if(ps > pe || iss > ie) return null;
        var newNode = new TreeNode(preorder[ps]);
        
        if(ps == pe) return newNode;

        var index = binarySearch(inorder, preorder[ps], iss, ie);
        var totalElementInLeftTree = index - iss;

        var leftNode = BuildTree(preorder, ps + 1, ps + totalElementInLeftTree, inorder, iss, index - 1);
        var rightNode = BuildTree(preorder, ps + totalElementInLeftTree + 1, pe, inorder, index + 1, ie);

        newNode.left = leftNode;
        newNode.right = rightNode;

        return newNode;
    }

    public int binarySearch(int[] inorder, int key, int s, int e) {
        for(int i = s; i <= e; i++) {
            if(key == inorder[i]) return i;
        }

        return -1;

    }

}
