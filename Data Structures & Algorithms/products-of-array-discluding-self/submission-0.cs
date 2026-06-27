public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        
        var zeroCount = nums.Where(x => x == 0).Count();
        var res = new int[nums.Length];
        if(zeroCount > 1) {
            return res;
        }
        
        if(zeroCount == 1) {
            var index = Array.IndexOf(nums, 0);
            res[index] = nums.Where(x => x != 0).Aggregate((acc, x) => acc * x);
            return res;
        }
        
        var mul = nums.Aggregate((acc, x) => acc * x);
        for(int i = 0; i < nums.Length; i++) {
            res[i] = mul/nums[i];
        }

        return res;

    }
}
