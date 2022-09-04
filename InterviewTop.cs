namespace LeetCode
{
    public static class InterviewTop
    {
        //https://leetcode.com/problems/longest-common-prefix/
        static public string LongestCommonPrefix(string[] strs)
        {
            string result = "";

            for (int i = 0; i < strs[0].Length; i++)
            {
                result += strs[0][i];

                for (int j = 1; j < strs.Length; j++)
                {
                    if (strs[j].IndexOf(result) != 0)
                    {
                        return strs[0].Substring(0, i);
                    }
                }
            }

            return result;
        }


        //https://leetcode.com/problems/roman-to-integer/
        static public int RomanToInt(string s)
        {
            var romanToArabic = new Dictionary<char, int>()
            {
                {'I', 1 },
                {'V', 5 },
                {'X', 10 },
                {'L', 50 },
                {'C', 100 },
                {'D', 500 },
                {'M', 1000 }
            };
            int result = romanToArabic[s[s.Length - 1]];

            for (int i = s.Length - 2; i >= 0; i--)
            {
                if (romanToArabic[s[i]] < romanToArabic[s[i + 1]])
                {
                    result -= romanToArabic[s[i]];
                }
                else
                {
                    result += romanToArabic[s[i]];
                }
            }

            return result;
        }

        //https://leetcode.com/problems/two-sum/
        static public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return new int[0];
        }



    }
}
