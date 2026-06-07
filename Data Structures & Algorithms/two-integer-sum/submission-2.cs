public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var indexed = nums
        .Select((value, index) => (value, index))
        .OrderBy(x => x.value)
        .ToArray();


        int s = 0;
        int e = nums.Length - 1;

        while (s <= e) {
            var (sValue, sIndex) = indexed[s];
            var (eValue, eIndex) = indexed[e];
            if(sValue + eValue == target) {
               var res = new int[] {sIndex, eIndex};
               Array.Sort(res);
               return res;
            }
            else if(sValue + eValue  > target) {
                e--;
            }
            else {
                s++;
            }
        }

        return new[] {0, 0};
    }
}
