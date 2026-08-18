public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        
        var map = new Dictionary<int, Node>();
        int [] visited = new int[n];
        for(int i = 0; i < n; i++) {
            map[i] = new Node(i);
        }

        foreach(int[] p in edges) {
            map[p[0]].nb.Add(map[p[1]]);
            map[p[1]].nb.Add(map[p[0]]);
        }

        if(hasCycle(map[0], visited, -1)) return false;

        for(int i = 0; i < n; i++) {
            if(visited[i] != 2) return false;
        }

        return true;
    }

    public bool hasCycle(Node node, int[] visited, int prev) {
        
        if(visited[node.val] == 1) {
            return true;
        }
        if(visited[node.val] == 2) {
            return false;
        }

        visited[node.val] = 1;
        foreach(var n in node.nb) {
            if(n.val != prev && hasCycle(n, visited, node.val)) {
                return true;
            }
        }

        visited[node.val] = 2;

        return  false;
    }
}

public class Node{

    public int val;
    public List<Node> nb;
    public Node(int value) {
        val = value;
        nb = new List<Node>();
    } 
}
