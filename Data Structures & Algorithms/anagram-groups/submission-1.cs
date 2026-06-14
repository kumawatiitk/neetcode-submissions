public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        
       var map = new Dictionary<string, List<string>>();

        foreach (var str in strs) {
            var charArray = str.ToCharArray();
            Array.Sort(charArray);
            var key = new string(charArray);

            var listForKey = map.GetValueOrDefault(key, new List<string>());
            listForKey.Add(str);

            if(!map.ContainsKey(key)) {
                map[key] = listForKey;
            }
        }

        return new List<List<string>>(map.Values);
    }
}
