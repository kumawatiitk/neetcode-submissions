public class Solution {
    public int LengthOfLongestSubstring(string s) {

        int l = 0;
        int r = 0;
        int len = s.Length;
        var set = new HashSet<char>();
        var result = 0;
        while(r < len) {
            if(set.Contains(s[r])) {
                while(s[l] != s[r]) {
                    set.Remove(s[l]);
                    l++;
                }
                l++;
            }
            set.Add(s[r]);
            result = Math.Max(result, r - l + 1);
            r++;
        }

        return result;
    }
}
