namespace LeetCode
{
    //https://leetcode.com/study-plan/leetcode-75/?progress=x9mpl2n6
    static public class LeetCode75
    {
        //-------Day 1 -------//
        //https://leetcode.com/problems/running-sum-of-1d-array
        static public int[] RunningSum(int[] nums)
        {
            var result = nums[..];

            for (int i = 1; i < nums.Length; i++)
            {
                result[i] += result[i - 1];
            }

            return result;
        }

        //https://leetcode.com/problems/find-pivot-index/
        static public int PivotIndex(int[] nums)
        {
            var left = 0;
            var right = nums[1..].Sum();


            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (left == right) return i;

                left += nums[i];
                right -= nums[i + 1];
            }

            return left == 0 ? nums.Length - 1 : -1;
        }
    }
}
