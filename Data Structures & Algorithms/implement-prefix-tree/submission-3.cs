public class PrefixTree {

    TrieNode root;

    public PrefixTree() {
        root = new TrieNode();
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
    
    public bool Search(string word) {
        int len = word.Length;
        var curr = root;

        for(int i = 0; i < len; i++) {
            int index = word[i] - 'a';
            curr = curr.nodes[index];

            if(curr == null) return false;
        } 

        return curr.GetWord();
    }

    public bool Search(String word, int index, TrieNode node) {
        


        if(index == word.Length) {
            return node.GetWord();
        }

         if(node.nodes[word[index] - 'a'] == null) {
           return false;
        }

        return Search(word, index + 1,  node.nodes[word[index] - 'a'] );
    }
    
    public bool StartsWith(string prefix) {
        return StartsWith(prefix, 0, root);
    }

     public bool StartsWith(string word, int index, TrieNode node) {
        if(index >= word.Length) {
            return true;
        }

        if(node.nodes[word[index] - 'a'] == null) {
           return false;     
        }

        return StartsWith(word, index + 1,  node.nodes[word[index] - 'a'] );
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
