public class Solution {
    public int[] TwoSum(int[] nums, int target) {

        var map = new Dictionary<int, int>();

        for(int i = 0; i < nums.Length; i++){
            map.Remove(nums[i]);
            map.Add(nums[i], i);
        }

        for(int i = 0; i < nums.Length; i++){
            if(map.ContainsKey(target - nums[i]) && i != map[target - nums[i]]) {
                return new int [] {i, map[target - nums[i]]};
            }
        }

        return new int[] {0, 0};
    }
}
