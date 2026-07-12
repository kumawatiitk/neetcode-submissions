public class Solution {
    public int FindMin(int[] nums) {
        return FindMinV1(nums, 0, nums.Length - 1);

    }

    int FindMinV1(int[] nums, int s, int e) {

        if(s == e)  return nums[s];
        if(s + 1 == e) return Math.Min(nums[s], nums[e]);

        int mid = s + (e - s + 1) / 2;

        if(nums[e] > nums[mid]) {
            return FindMinV1(nums, s, mid);
        } else {
            return FindMinV1(nums, mid + 1, e);
        }
    }
}
