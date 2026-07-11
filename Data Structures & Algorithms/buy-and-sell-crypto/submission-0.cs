public class Solution {
    public int MaxProfit(int[] prices) {
        int len = prices.Length;
        if(len == 0) return 0;
        int max = prices[len -1];
        int profit = 0;
        for(int i = len - 2; i >= 0; i--) {
            profit = Math.Max(profit, max - prices[i]);
            max = Math.Max(max, prices[i]);
        }

        return profit;
    }
}
