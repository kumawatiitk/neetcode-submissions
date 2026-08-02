public class Solution {
    public bool Exist(char[][] board, string word) {
        if(board == null) return false;
        int lenX = board.Length;
        if(lenX == 0) return false;
        int lenY = board[0].Length;
        for(int i = 0; i < lenX; i++) {
            for(int j = 0; j < lenY; j++) {
                if(isExists(board, i, j, word, new StringBuilder())) {
                    return true;
                }
            }
        }

        return false;
    }

    bool isExists(char[][] board, int x, int y, string word, StringBuilder sb) {

        if(board[x][y] != word[sb.Length]) return false; 

        (int dr, int dc)[] dirs = { (0,1), (1,0), (0,-1), (-1,0) };

        if(sb.Length == word.Length - 1) return true;
        sb.Append(board[x][y]);
        var temp = board[x][y];
        board[x][y] = ',';
        foreach (var (dr, dc) in dirs) {
            int xn = x + dr;
            int yn = y + dc;
            if(IsWithinBoundary(board, xn, yn) && isExists(board, xn, yn, word, sb)) {
                return true;
            }
        }
        board[x][y] = temp;
        sb.Remove(sb.Length - 1, 1);

        return false;
    }

    bool IsWithinBoundary(char[][] board, int xn, int yn) {
        
        int xb = board.Length;
        int yb = board[0].Length;
        if(xn >= xb || xn < 0 || yn >= yb || yn < 0) return false;
        
        return true;
    }
}
