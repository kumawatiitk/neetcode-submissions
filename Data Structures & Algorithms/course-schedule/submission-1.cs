public class Solution {



    public bool CanFinish(int numCourses, int[][] prerequisites) {

        var map = new Dictionary<int, Node>();
        var indegree = new int[numCourses];

        for(int i = 0; i < numCourses; i++) {
            map[i] = new Node(i);
        }

        foreach(int[] p in prerequisites) {
            map[p[1]].nb.Add(map[p[0]]);
            indegree[p[0]]++;
        }

        var que = new Queue<int>();
        for(int i = 0; i < numCourses; i++) {
            if(indegree[i] == 0) {
                que.Enqueue(i);
            }
        }

        while(que.Count != 0) {
            var curr = que.Dequeue();
            foreach(var nb in map[curr].nb) {
                indegree[nb.val]--;
                if(indegree[nb.val] == 0) {
                    que.Enqueue(nb.val);
                }
            }
        }

        for(int i = 0; i < numCourses; i++) {
            if(indegree[i] != 0) {
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
