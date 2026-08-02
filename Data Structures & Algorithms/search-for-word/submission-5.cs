public class Solution {
    public bool Exist(char[][] board, string word) {
        if(board == null) return false;
        int lenX = board.Length;
        if(lenX == 0) return false;
        int lenY = board[0].Length;
        for(int i = 0; i < lenX; i++) {
            for(int j = 0; j < lenY; j++) {
                if(isExists(board, i, j, word, 0)) {
                    return true;
                }
            }
        }

        return false;
    }

    bool isExists(char[][] board, int x, int y, string word, int len) {
        
        if(len == word.Length) return true;
        if((IsWithinBoundary(board, x, y) == false) || board[x][y] != word[len]) return false; 

        (int dr, int dc)[] dirs = { (0,1), (1,0), (0,-1), (-1,0) };

        var temp = board[x][y];
        board[x][y] = ',';
        foreach (var (dr, dc) in dirs) {
            int xn = x + dr;
            int yn = y + dc;
            if(isExists(board, xn, yn, word, len + 1)) {
                return true;
            }
        }
        board[x][y] = temp;

        return false;
    }

    bool IsWithinBoundary(char[][] board, int xn, int yn) {
        
        int xb = board.Length;
        int yb = board[0].Length;
        if(xn >= xb || xn < 0 || yn >= yb || yn < 0) return false;
        
        return true;
    }
}
