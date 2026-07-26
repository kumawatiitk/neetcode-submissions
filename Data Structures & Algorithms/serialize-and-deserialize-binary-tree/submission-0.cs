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

public class Codec {

    // Encodes a tree to a single string.
    public string Serialize(TreeNode root) {
        if(root == null) return null;

        var que = new Queue<TreeNode>();
        que.Enqueue(root);

        var list = new List<string>(); 
        while(que.Count != 0) {
            var curr = que.Dequeue();
            if(curr == null) {
                list.Add("#");
                continue;
            }
            list.Add(curr.val.ToString());
            que.Enqueue(curr.left);
            que.Enqueue(curr.right);
        }

        return  string.Join(",", list);
    }

    // Decodes your encoded data to tree.
    public TreeNode Deserialize(string data) {
        if(data == null) return null;
        string[] parts = data.Split(',');   

        int i = 1;
        var root = new TreeNode(int.Parse(parts[0]));
        var que = new Queue<TreeNode>();
        que.Enqueue(root);
        while(i < parts.Length) {

            var curr = que.Dequeue();
            curr.left = parts[i].Equals("#") ? null :  new TreeNode(int.Parse(parts[i]));
            i++;
            curr.right = parts[i].Equals("#") ? null :  new TreeNode(int.Parse(parts[i]));
            i++;

            if(curr.left != null) {
                que.Enqueue(curr.left);
            }

            if(curr.right != null) {
                que.Enqueue(curr.right);
            }
        }

        return root;
    }
}
