public class Solution {
    public bool IsValid(string s) {
        var stack = new Stack<char>();

        foreach(var c in s) {
            if(isOpen(c)) {
                stack.Push(c);
                continue;
            }

            if(isClose(c)) {
                if(stack.Count > 0 && match(stack.Peek(), c)) {
                    stack.Pop();
                }
                else {
                    return false;
                }
            } 
        }

        return stack.Count == 0;
        
    }

    bool match(char s1, char s2) {
        return (s1 == '(' && s2 == ')') || (s1 == '[' && s2 == ']') || (s1 == '{' && s2 == '}');
    }

    bool isOpen(char c) {
        return c == '(' || c == '[' || c == '{';
    }

     bool isClose(char c) {
        return c == ')' || c == ']' || c == '}';
    }

    
}
