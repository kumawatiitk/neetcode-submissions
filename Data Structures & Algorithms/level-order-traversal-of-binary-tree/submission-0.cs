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
    public List<List<int>> LevelOrder(TreeNode root) {

        var que = new Queue<(TreeNode, int)>();
        var res = new List<List<int>>();

        if(root == null) return res;

        que.Enqueue((root, 0));
        var currLevel = 0;
        var currLevelList = new List<int>();
        while(que.Count != 0) {
            var (node, level) = que.Dequeue();

            if(currLevel != level) {
                res.Add(currLevelList);
                currLevel = level;
                currLevelList = new List<int>();
            }
            currLevelList.Add(node.val);

            if(node.left != null)
                que.Enqueue((node.left, level + 1));

            if(node.right != null)
                que.Enqueue((node.right, level + 1));


        }
        res.Add(currLevelList);
        return res;
    }
}
