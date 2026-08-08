public class PrefixTree {

    TreeNode root;

    public PrefixTree() {
        root = new TreeNode(' ');
    }
    
    public void Insert(string word) {
        Insert(word, 0, root);
    }

    public void Insert(String word, int index, TreeNode node) {

        if(index >= word.Length) {
            return;
        }

        if(node.nodes[word[index] - 'a'] == null) {
            node.nodes[word[index] - 'a'] =  new TreeNode(word[index]);  
        }

        if(index == word.Length - 1) {
            node.nodes[word[index] - 'a'].SetWord();
        }   

        Insert(word, index + 1,  node.nodes[word[index] - 'a'] );
    }
    
    public bool Search(string word) {
        return Search(word, 0, root);
    }

    public bool Search(String word, int index, TreeNode node) {

        if(index >= word.Length) {
            return false;
        }

         if(node.nodes[word[index] - 'a'] == null) {
           return false;
        }

        if(index == word.Length - 1) {
           return  node.nodes[word[index] - 'a'].GetWord();
        } 

        return Search(word, index + 1,  node.nodes[word[index] - 'a'] );
    }
    
    public bool StartsWith(string prefix) {
        return StartsWith(prefix, 0, root);
    }

     public bool StartsWith(string word, int index, TreeNode node) {
        if(index >= word.Length) {
            return true;
        }

        if(node.nodes[word[index] - 'a'] == null) {
           return false;     
        }

        return StartsWith(word, index + 1,  node.nodes[word[index] - 'a'] );
     }
}

public class TreeNode {

    public TreeNode[] nodes;
    char c;
    bool isWord;
    public TreeNode(char s, bool word = false) {
        c = s;
        nodes = new TreeNode[26];
        isWord = word;
    }

    public void SetWord() {
        isWord = true;
    }

    public bool GetWord() {
        return isWord;
    }
}
