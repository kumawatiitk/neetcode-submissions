public class Solution {
    public int MaxProfit(int[] prices) {
        
        int l = 0;
        int r = l + 1;
        int len = prices.Length;
        int profit = 0;
        while(r < len) {
            profit = Math.Max(profit, prices[r] - prices[l]);

            if(prices[r] > prices[l]) {
                r++;
            } else {
                l = r;
                r = l + 1;
            }
        }

        return profit;
    }
}
