using System.Text;

namespace LeetCode
{
    //https://leetcode.com/study-plan/leetcode-75/?progress=x9mpl2n6
    static public class LeetCode75
    {
        #region Day1
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

        #endregion

        #region Day2
        //https://leetcode.com/problems/isomorphic-strings/
        static public bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length) return false;

            var map = new Dictionary<char, char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (map.ContainsKey(s[i]) && map[s[i]] != t[i])
                    return false;

                if (map.ContainsValue(t[i]))
                {
                    var key = map.FirstOrDefault(x => x.Value == t[i]).Key;
                    if (key != s[i]) return false;
                }

                map.TryAdd(s[i], t[i]);
            }

            return true;
        }

        //https://leetcode.com/problems/is-subsequence/
        static public bool IsSubsequence(string s, string t)
        {
            var subsequence = new StringBuilder(s.Length);
            for (int i = 0, j = 0; i < t.Length && j < s.Length; i++)
            {
                if (t[i] == s[j])
                {
                    subsequence.Append(t[i]);
                    j++;
                }
            }

            return s == subsequence.ToString();
        }

        #endregion

        #region Day3
        //https://leetcode.com/problems/merge-two-sorted-lists/
        static public ListNode? MergeTwoLists(ListNode list1, ListNode list2) =>
            InterviewTop.MergeTwoLists(list1, list2);

        //https://leetcode.com/problems/reverse-linked-list/
        static public ListNode ReverseList(ListNode head)
        {
            ListNode result = null;

            while (head != null)
            {
                result = new ListNode(head.val, result);
                head = head.next;
            }

            return result;
        }
    }

    #endregion
}

