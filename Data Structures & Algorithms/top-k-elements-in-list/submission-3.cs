public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {

        var nodeList = new List<Node>();
        var countMap = new Dictionary<int, int>();
        foreach(int num in nums) {
            var currValOfKey = countMap.GetValueOrDefault(num, 0);
            countMap[num] = currValOfKey + 1;
        }
        
        foreach(var (key, value) in countMap) {
            nodeList.Add(new Node() {Key = key, Value = value});
        }

        nodeList.Sort((node1, node2) => node2.Value - node1.Value);

        int count = 0;
        var result = new List<int>();
        foreach(var node in nodeList) {
            result.Add(node.Key);
            count++;
            if(count == k) {
                break;
            }
        }

        return result.ToArray();
    }

}

public class Node {
    public int Key;
    public int Value;
}

