/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {

        if(node == null) return null;
        var dict = new Dictionary<int, Node>();
        var visited = new HashSet<int>();

        var que = new Queue<(Node, Node)>();
        var root = new Node(node.val);
         visited.Add(root.val);
        que.Enqueue((root, node));
        dict[root.val] = root;

        while(que.Count != 0) {
            var (curr, org) = que.Dequeue();
            foreach(var nb in org.neighbors) {
                var newNode = dict.GetValueOrDefault(nb.val, new Node(nb.val));
                dict[nb.val] = newNode;
                curr.neighbors.Add(newNode);
                if(!visited.Contains(nb.val)) {
                    que.Enqueue((newNode, nb));
                    visited.Add(nb.val);
                }
            }
        }

        return root;
    }
}
