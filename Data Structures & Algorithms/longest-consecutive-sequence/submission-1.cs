public class Solution {
    public int LongestConsecutive(int[] nums) {
        Array.Sort(nums);
        int len = nums.Length;
        int curr = 0;
        int max = 0;
        while(curr < len) {
            var streak = 1;
            while(curr + 1 < len && (nums[curr + 1] == nums[curr] + 1 || nums[curr + 1] == nums[curr])) {
                if(nums[curr + 1] == nums[curr] + 1) {
                    streak++;
                }
                curr++;
            }
            if(max < streak) {
                max = streak;
            }
            curr++;
        }
        return max;        
    }
}
