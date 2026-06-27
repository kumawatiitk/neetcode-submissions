public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var countMap = new Dictionary<int, int>();
        foreach(int num in nums) {
            countMap[num] = countMap.GetValueOrDefault(num, 0) + 1;
        }

        var keys = countMap.Keys.ToList();
        keys.Sort((key1, key2) => countMap[key2] - countMap[key1]);
        return keys.Take(k).ToArray();
    }

}

