public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        
        Array.Sort(nums);
        int len = nums.Length;
        var res = new HashSet<(int, int, int)>();
        for(int i = 0 ; i < len; i++) {
            int l = i + 1;
            int r = len - 1;

            int needed = -1 * nums[i];
            while(l < r) {
                if(nums[l] + nums[r] == needed) {
                    res.Add((nums[i], nums[l], nums[r]));
                    l++;
                    r--;
                }
                else if(nums[l] + nums[r] > needed) {
                    r--;
                } else {
                    l++;
                }
            }
        }

        return res.Select(t => (List<int>)new List<int> { t.Item1, t.Item2, t.Item3 }).ToList();
    }
}
