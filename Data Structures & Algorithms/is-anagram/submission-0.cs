public class Solution {
    public bool IsAnagram(string s, string t) {

        if(s == null && t == null) {
            return true;
        }

        if(s == null || t == null) return false;

        if(s.Length != t.Length) return false;
        var countMapS = new Dictionary<int, int>();

        foreach(var c in s) {
            var val = countMapS.GetValueOrDefault(c, 0);
            countMapS[c] = val + 1;
        }

        foreach(var c in t) {
            var val = countMapS.GetValueOrDefault(c, 0);
            // not anagram case
            if(val == 0) return false;

            countMapS[c] = val - 1;
            if(countMapS[c] == 0) {
                countMapS.Remove(c);
            }
        }

        return countMapS.Count == 0;


    }
}
