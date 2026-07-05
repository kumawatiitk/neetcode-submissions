public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        

        int len = nums.Length;
        var map = new Dictionary<int, int>();
        for(int i = 0; i < len; i++) {
            map[nums[i]] = i;
        }
        var res = new HashSet<(int, int, int)>();

        for(int i = 0; i < len; i ++) {
            for(int j = i + 1; j < len; j++) {
                var needed = -1 * (nums[i] + nums[j]);
                if(map.ContainsKey(needed) && map[needed] > j) {
                    var arr = new int[] {nums[i], nums[j], needed};
                    Array.Sort(arr);
                    res.Add((arr[0], arr[1], arr[2]));
                }
            }
        }

        return res.Select(t => (List<int>)new List<int> { t.Item1, t.Item2, t.Item3 }).ToList();
    }
}
