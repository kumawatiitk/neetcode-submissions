public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        
        var countMap = new Dictionary<int, int>();

        foreach(var num in nums) {
            countMap[num] = countMap.GetValueOrDefault(num , 0) + 1;
        }

        var pq = new PriorityQueue<int, int>();

        foreach(var key in countMap.Keys) {
            pq.Enqueue(key, countMap[key]);
            
            if(pq.Count > k) {
                pq.Dequeue();
            }
        }

        var response = new List<int>();
        while(pq.Count > 0) {
            pq.TryDequeue(out var value, out var priority);
            response.Add(value);
        }
        return response.ToArray();
    }
}
