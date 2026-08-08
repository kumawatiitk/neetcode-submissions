public class Solution {
    public int NumIslands(char[][] grid) {
        
        int m = grid.Length;
        int n = grid[0].Length; 
        
        var visited = new HashSet<(int, int)>();
        int count = 0;
        for(int i = 0; i < m; i++) {
            for(int j = 0; j < n; j++) {
                if(grid[i][j] == '1' &&  !visited.Contains((i , j))){
                    count++;
                    dfs(grid, i, j, visited);
                }
            }
        }

        return count;
    }

    void dfs(char[][] board, int i, int j,  HashSet<(int, int)> visited) {
        
        int m = board.Length;
        int n = board[0].Length;
        int[][] dirs = { new[] {0,1}, new[] {0,-1}, new[] {-1,0}, new[] {1,0} };

        if(i < 0 || j < 0 || i >= m || j >= n ||  board[i][j] == '0' ||  visited.Contains((i, j))) return;
        
        visited.Add((i, j));
        foreach(var dir in dirs) {
            dfs(board, i + dir[0] , j + dir[1], visited);
        }

    }
}
