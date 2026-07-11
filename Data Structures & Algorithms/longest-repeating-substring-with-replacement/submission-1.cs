public class Solution {
    public int CharacterReplacement(string s, int k) {

        int l = 0;
        int r = 0;
        var freq = new int [26];

        int len = s.Length;
        int res = 0;
        while(r < len) {
            freq[s[r] - 'A']++;
            int max = freq.Max();
            if(r - l + 1 - max <= k) {
                res = Math.Max(res, r - l + 1);
                r++;
            } else {
                freq[s[l] - 'A']--;
                freq[s[r] - 'A']--;
                l++;
            }

        }

        return res;
        
    }
}
