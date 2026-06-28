public class Solution {
    public int LongestConsecutive(int[] nums) {

        var set = new HashSet<int>();
        var dict = new Dictionary<int, int>();
        foreach(var num in nums) {
            set.Add(num);
        }

        var max = 0;
        foreach(var num in set) {
            if(dict.ContainsKey(num)) {
                continue;
            }

            var start = num;
            var end = start;
            while (set.Contains(end + 1) && !dict.ContainsKey(end + 1)) {
                end++;
            }

            for(int i = start; i <= end; i++) {
                dict[i] = end - start + 1 + dict.GetValueOrDefault(end + 1, 0); 

                if(max < dict[i]) {
                    max = dict[i];
                }
            }
        }

        return max;


        


        
    }
}
