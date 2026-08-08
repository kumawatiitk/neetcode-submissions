public class Solution {
    TrieNode root;
    public List<string> FindWords(char[][] board, string[] words) {
        root = new TrieNode();
        foreach(var word in words) {
            Insert(word);
        }
        int m = board.Length;
        int n = board[0].Length;
        var result = new HashSet<string>();
        
        for(int i = 0; i < m; i++) {
            for(int j = 0; j < n; j++) {
                findWords(board, i, j, root, result, new HashSet<(int, int)>(), new StringBuilder());
            }
        }

        return result.ToList();
    }

    public void findWords(char[][] board, int i, int j, TrieNode node, HashSet<string> words, HashSet<(int, int)> visited, StringBuilder sb) {

        int m = board.Length;
        int n = board[0].Length;
       int[][] dirs = { new[] {0,1}, new[] {0,-1}, new[] {-1,0}, new[] {1,0} };

        if(i < 0 || j < 0 || i >= m || j >= n || visited.Contains((i, j))) return;

        int index = board[i][j] - 'a';
        if(node.nodes[index] == null) return;
        visited.Add((i, j));
        sb.Append(board[i][j]);

        if(node.nodes[index].GetWord()) {
            words.Add(sb.ToString());
        }

        foreach(var dir in dirs) {
            findWords(board, i + dir[0] , j + dir[1], node.nodes[index], words, visited, sb);
        }

        sb.Remove(sb.Length - 1, 1);
        visited.Remove((i, j));

    }

        
    public void Insert(string word) {
        Insert(word, 0, root);
    }

    public void Insert(String word, int index, TrieNode node) {

        if(index == word.Length) {
            node.SetWord();
            return;
        }

        node.nodes[word[index] - 'a'] =    node.nodes[word[index] - 'a']  ?? new TrieNode(); 
        Insert(word, index + 1,  node.nodes[word[index] - 'a'] );
    }
}

public class TrieNode {

    public TrieNode[] nodes;
    bool isWord;
    public TrieNode(bool word = false) {
        nodes = new TrieNode[26];
        isWord = word;
    }

    public void SetWord() {
        isWord = true;
    }

    public bool GetWord() {
        return isWord;
    }
}
