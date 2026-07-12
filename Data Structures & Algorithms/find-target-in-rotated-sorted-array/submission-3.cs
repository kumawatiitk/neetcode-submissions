public class Solution {
    public int Search(int[] nums, int target) {
        
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

        var pivot = l;
        l = 0;
        r = nums.Length - 1;

        if(target >= nums[pivot] && target <= nums[r]) {
            l = pivot;
        } else {
            r = pivot - 1;
        }

        while(l <= r) {

            int mid = l + (r - l )/ 2;
            if(nums[mid] == target) {
                return mid;
            } else if (nums[mid] > target) {
                r = mid - 1;
            } else {
                l = mid + 1;
            }
        }

        return -1;
    }
}
