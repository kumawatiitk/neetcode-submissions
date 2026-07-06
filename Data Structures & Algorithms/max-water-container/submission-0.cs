public class Solution {
    public int MaxArea(int[] heights) {
        int len = heights.Length;

        int l = 0;
        int r = len - 1;
        int max = 0;
        while(l < r) {
            var curr = Math.Min(heights[l],  heights[r]) * (r - l);
            max = Math.Max(max, curr);
            if(heights[l] <= heights[r]) {
                l++;
            }else {
                r--;
            }
        }

        return max;
    }
}
