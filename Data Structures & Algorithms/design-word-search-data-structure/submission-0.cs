public class WordDictionary {
      TrieNode root;
    public WordDictionary() {
         root = new TrieNode();
    }
    
    public void AddWord(string word) {
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
        return Search(word, 0, root);
    }

    public bool Search(String word, int index, TrieNode node) {
        
        if(index == word.Length) {
            return node.GetWord();
        }

        if(word[index] == '.') {
            foreach(var child in node.nodes) {
                if(child != null && Search(word, index + 1,  child)) {
                    return true;
                }
            }

            return false;
        }
        else if (node.nodes[word[index] - 'a'] == null) {
           return false;
        } else {
            return Search(word, index + 1,  node.nodes[word[index] - 'a'] );
        }
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
