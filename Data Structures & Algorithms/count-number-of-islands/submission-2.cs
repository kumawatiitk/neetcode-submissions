public class Solution {
    public int NumIslands(char[][] grid) {
        int ROWS = grid.Length;
        int COLS = grid[0].Length;
        DSU dsu = new DSU(ROWS * COLS);

         int[][] dirs = new int[][] {
            new int[] { 1, 0 }, new int[] { -1, 0 },
            new int[] { 0, 1 }, new int[] { 0, -1 }};
         int island = 0;

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) { 
                if(grid[r][c] == '1') {
                    island++;
                    foreach(var dir in dirs) {
                        var nr = r + dir[0];
                        var nc = c + dir[1];
                        if (nr >= 0 && nc >= 0 && nr < ROWS &&
                            nc < COLS && grid[nr][nc] == '1') {
                            if(dsu.Union( r * COLS + c,  nr * COLS + nc)) {
                                island--;
                            }
                        }
                    }
                }
            }
        }  
        return island;
    }
    
}

public class DSU {

    private int[] parent;
    private int[] size;
    public int Count { get; private set; }  // number of components


    public DSU(int n) {
        parent = new int[n];
        size = new int[n];
        Count = n;
        for (int i = 0; i < n; i++) {
            parent[i] = i;   // each node is its own root
            size[i] = 1;
        }
    }

    public int Find(int x) {

        while(parent[x] != x) {
            parent[x] = parent[parent[x]];
            x = parent[x];
        }

        return x;
    }

    public bool Union(int u, int v) { 

        int rootU = Find(u);
        int rootV = Find(v);

        if(rootU == rootV) return false;

        if (size[rootU] < size[rootV])      // union by size
            (rootU, rootV) = (rootV, rootU);

        parent[rootV] = rootU;
        size[rootU] += size[rootV]; 
        Count--;
        return true;
    }
}