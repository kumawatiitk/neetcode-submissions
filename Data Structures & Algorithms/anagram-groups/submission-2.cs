public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        
       var map = new Dictionary<string, List<string>>();

        foreach (var str in strs) {
            int [] count = new int[26];
            foreach(var c in str) {
                count[c - 'a']++;
            }

            var key = string.Join(",", count);

            var listForKey = map.GetValueOrDefault(key, new List<string>());
            listForKey.Add(str);

            if(!map.ContainsKey(key)) {
                map[key] = listForKey;
            }
        }

        return new List<List<string>>(map.Values);
    }
}
