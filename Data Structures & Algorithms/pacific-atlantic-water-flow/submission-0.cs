public class Solution {

    int [,] count;

    public List<List<int>> PacificAtlantic(int[][] heights) {
    
        int m = heights.Length;
        int n = heights[0].Length;
        bool [,] pacific = new bool[m, n];
        bool [,] atlantic = new bool[m, n];

        for(int i = 0; i < n; i++) {
            dfs(heights, 0, i, pacific, -1);
            dfs(heights, m - 1, i, atlantic, -1);
        }

        for(int i = 0; i < m; i++) {
            dfs(heights, i, 0, pacific, -1);
            dfs(heights, i, n - 1, atlantic, -1);
        }

        var res = new List<List<int>>();
        for(int i = 0; i < m; i++) {
            for(int j = 0; j < n; j++) {
                if(pacific[i, j] && atlantic[i, j]) {
                    res.Add(new List<int>{i , j});
                }
            }
        }

        return res;
    }

    public void dfs(int[][] heights, int i, int j, bool[,] visited, int prev) {

        int[][] dirs = 
        {
            new[] { 1, 0 },
            new[] { -1, 0 },
            new[] { 0, 1 },
            new[] { 0, -1 }
        };

        int m = heights.Length;
        int n = heights[0].Length;

        if(i < 0 || j < 0 || i >= m || j >= n || visited[i, j]  || ( prev != -1 && heights[i][j] <  prev)) {
            return;
        }

        visited[i, j] = true;

        foreach(var dir in dirs) {
            var nr = i + dir[0];
            var nc = j + dir[1];
            dfs(heights, nr, nc, visited, heights[i][j]);
        }
    }


}
