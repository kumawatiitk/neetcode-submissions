public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        
        var pq = new PriorityQueue<int, int>();
        var countMap = new Dictionary<int, int>();
        foreach(var num in nums) {
            var value = countMap.GetValueOrDefault(num, 0);
            countMap[num] = value + 1;
        }

        foreach(var (key, value) in countMap) {
            pq.Enqueue(key, value);
            if(pq.Count > k) {
                pq.Dequeue();
            }
        }

        var res = new List<int>();
        while(pq.Count > 0) {
             pq.TryDequeue(out int value, out int priority);
             res.Add(value);
        }
        return res.ToArray();
    }
}
