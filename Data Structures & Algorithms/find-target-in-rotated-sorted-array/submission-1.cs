public class Solution {
    public int Search(int[] nums, int target) {
        int l = 0;
        int r = nums.Length - 1;

        while(l < r) {
            int mid = l + (r - l) / 2;
            if((nums[r] > nums[mid] && (target <= nums[r] && target > nums[mid]))
              ||  (nums[mid] >= nums[l] && (target > nums[mid] || target < nums[l]))) {
               l = mid + 1;
            } else {
                r = mid;
            }
        }

        return nums[l] == target ? l : -1;
    }
}
