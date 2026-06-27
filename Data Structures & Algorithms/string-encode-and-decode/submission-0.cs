public class Solution {

    public string Encode(IList<string> strs) {
        return string.Join("", strs.Select(x => $"{x.Length.ToString("D3")}{x}"));

    }

    public List<string> Decode(string s) {

        var res = new List<string>();
        var currIndex = 0;
        while(currIndex < s.Length) {
            var lengthOfCurrString = int.Parse(s.Substring(currIndex, 3));
            res.Add(s.Substring(currIndex + 3, lengthOfCurrString));
            currIndex = currIndex + 3 + lengthOfCurrString;
        }

        return res;

   }
}
