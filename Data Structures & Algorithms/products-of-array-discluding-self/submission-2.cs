public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        
        int len = nums.Length;
        var res = new int[len];
        res[0] = 1;
        for(int i = 1; i < len; i++) {
            res[i] = res[i - 1] * nums[i - 1];
        }
        int suffix = 1;
        for(int i = len - 1; i >=  0; i--) {
            res[i] = res[i] * suffix;
            suffix *= nums[i];
        }

        return res;
    }
}
