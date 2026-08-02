public class Solution {
    public List<List<int>> CombinationSum(int[] nums, int target) {        
        Array.Sort(nums);
        var dict = new Dictionary<string, List<int>>();
        comb(nums, 0, target, new List<int>(), dict);
        return dict.Values.ToList();

    }

    public void comb(int [] nums, int index, int target, List<int> temp,  Dictionary<string, List<int>> dict) {
        
        if(target == 0) {
            dict[string.Join(',', temp)] = new List<int>(temp);
            return;
        }

        if(index >= nums.Length || target < 0) return;

        if(nums[index] > target) return;
        
        temp.Add(nums[index]);
        comb(nums, index, target - nums[index], temp, dict);
        temp.RemoveAt(temp.Count - 1);

        comb(nums, index + 1, target, temp, dict);
    }
}
