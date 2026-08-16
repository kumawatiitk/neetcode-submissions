public class Solution {



    public bool CanFinish(int numCourses, int[][] prerequisites) {

        var map = new Dictionary<int, Node>();
        var visited = new Dictionary<int, int>();
        for(int i = 0; i < numCourses; i++) {
            map[i] = new Node(i);
        }

        foreach(int[] p in prerequisites) {
            map[p[0]].nb.Add(map[p[1]]);
        }

       for(int i = 0; i < numCourses; i++) { 
            if(visited.GetValueOrDefault(i, 0) == 0 && hasCycle(map[i], visited)) {
                return false;
            }
       }

       return true;

    }

    public bool hasCycle(Node node, Dictionary<int, int> visited) {

        visited[node.val] = 1;
        foreach(var n in node.nb) {
            if(visited.GetValueOrDefault(n.val, 0) == 0 && hasCycle(n, visited)) {
                return true;
            } else if(visited[n.val] == 1) {
                return true;
            }
        }

        visited[node.val] = 2;
        return false;
    }
}

public class Node {

    public int val;
    public List<Node> nb;
    public Node(int value) {
        val = value;
        nb = new List<Node>();
    }
}
