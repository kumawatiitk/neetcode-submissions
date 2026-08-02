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
        
        int count = target/nums[index];
        for(int i = 0 ; i <= count; i++) {            
            var tempVal = i;
            while(tempVal > 0) {
                temp.Add(nums[index]);
                tempVal--;
            }

            comb(nums, index + 1, target - nums[index] * i, temp, dict);
            
            tempVal = i;
            while(tempVal > 0) {
                temp.RemoveAt(temp.Count - 1);
                tempVal--;
            }
        }
         
        
    }
}
