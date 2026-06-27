public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        
        int len = nums.Length;
        var prefixMul = new int[nums.Length + 1];
        var suffixMul = new int[nums.Length + 1];

        prefixMul[0] = 1;
        suffixMul[len] = 1;

        for(int i = 1; i <= len; i++) {
            prefixMul[i] = prefixMul[i - 1] * nums[i - 1];
        }

        for(int i = len - 1; i >= 0; i--) {
            suffixMul[i] = suffixMul[i + 1] * nums[i];
        }

        var res = new int[len];
        for(int i = 0; i < len; i ++) {
            res[i] = prefixMul[i] * suffixMul[i + 1];
        }

        return res;
    }
}
