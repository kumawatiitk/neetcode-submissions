public class Solution {
    public bool Exist(char[][] board, string word) {
        if(board == null) return false;
        int lenX = board.Length;
        if(lenX == 0) return false;
        int lenY = board[0].Length;
        var visited = new bool[lenX, lenY];

        for(int i = 0; i < lenX; i++) {
            for(int j = 0; j < lenY; j++) {
                if(isExists(board, i, j, word, 0, visited)) {
                    return true;
                }
            }
        }

        return false;
    }

    bool isExists(char[][] board, int x, int y, string word, int len, bool [,] visited) {
        
        if(len == word.Length) return true;
        if((IsWithinBoundary(board, x, y) == false) || visited[x, y] || board[x][y] != word[len]) return false; 

        (int dr, int dc)[] dirs = { (0,1), (1,0), (0,-1), (-1,0) };

;
        visited[x, y] = true;
        foreach (var (dr, dc) in dirs) {
            int xn = x + dr;
            int yn = y + dc;
            if(isExists(board, xn, yn, word, len + 1, visited)) {
                return true;
            }
        }
         visited[x, y] = false;

        return false;
    }

    bool IsWithinBoundary(char[][] board, int xn, int yn) {
        
        int xb = board.Length;
        int yb = board[0].Length;
        if(xn >= xb || xn < 0 || yn >= yb || yn < 0) return false;
        
        return true;
    }
}
