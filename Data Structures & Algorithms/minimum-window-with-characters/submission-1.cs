public class Solution {
    public string MinWindow(string s, string t) {
        var dict = new Dictionary<char, int>();
        var curr = new Dictionary<char, int>();
        foreach(var c in t) {
            dict[c] =  dict.GetValueOrDefault(c) + 1;
        }

        int l = 0;
        int r = 0;
        int len = s.Length;
        int count = 0;
        int result = int.MaxValue;
        int rl = -1;
        int rr = -1;
        while(r < len) {
            var currChar = s[r];
            if(dict.ContainsKey(currChar)) {
                curr[currChar] =  curr.GetValueOrDefault(currChar) + 1;
                if(curr[currChar] == dict[currChar]) {
                    count++;
                }
            }

            while(count == dict.Count) {
                if(result >=  r - l + 1) {
                    result = r - l + 1;
                    rr = r;
                    rl = l;
                }

                if(dict.ContainsKey(s[l])) {
                    curr[s[l]] =  curr.GetValueOrDefault(s[l]) - 1;
                    if(curr[s[l]] == dict[s[l]] - 1) {
                        count--;
                    }
                }
                l++;
            }
            r++;
        }

        return rl == -1 ? "" : s.Substring(rl, rr - rl + 1);
    }
}
