public class Solution {
    public int FindMin(int[] nums) {
        int l = 0;
        int r = nums.Length - 1;

        while(l < r) {
            int mid = l + (r - l) / 2;
            if(nums[r] > nums[mid]) {
                r = mid;
            } else {
                l = mid + 1;
            }
        }

        return nums[l];
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
