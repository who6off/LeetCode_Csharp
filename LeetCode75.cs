using System.Text;

namespace LeetCode
{
    //https://leetcode.com/study-plan/leetcode-75/?progress=x9mpl2n6
    static public class LeetCode75
    {
        //-----------------------------------------------------//
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
        //-----------------------------------------------------//

        //-----------------------------------------------------//
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
        //-----------------------------------------------------//

        //-----------------------------------------------------//
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

        #endregion
        //-----------------------------------------------------//

        //-----------------------------------------------------//
        #region Day4
        //https://leetcode.com/problems/middle-of-the-linked-list/
        static public ListNode MiddleNode(ListNode head)
        {
            var ptr = head;
            var length = 0;

            while (ptr != null)
            {
                length++;
                ptr = ptr.next;
            }

            ptr = head;

            for (var i = 0; i < length / 2; i++)
                ptr = ptr.next;

            return ptr;
        }

        //https://leetcode.com/problems/linked-list-cycle-ii/
        static public ListNode DetectCycle(ListNode head)
        {
            var ptr = head;
            var length = 0;

            while (ptr != null)
            {
                length++;

                var cycledNode = head;
                for (var i = 0; i < length; i++)
                {
                    if (ptr.next == cycledNode)
                        return cycledNode;

                    cycledNode = cycledNode.next;
                }

                ptr = ptr.next;


            }

            return null;
        }
        #endregion
        //-----------------------------------------------------//

        //-----------------------------------------------------//
        #region Day5
        //https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        static public int MaxProfit(int[] prices)
        {
            //int result = 0;
            //int sell, profit;

            //for (int i = 0; i < prices.Length - 1; i++)
            //{
            //    sell = prices[i + 1];

            //    for (int j = i + 2; j < prices.Length; j++)
            //        if (prices[j] > sell) sell = prices[j];

            //    profit = sell - prices[i];

            //    if (profit > result) result = profit;
            //}

            //return result < 0 ? 0 : result;

            var left = 0;
            var right = 1;
            var profit = 0;

            while (right < prices.Length)
            {
                var tmp = prices[right] - prices[left];

                if (tmp < 0)
                    left++;
                else
                    right++;

                if (tmp > profit) profit = tmp;
            }

            return profit;
        }

        //https://leetcode.com/problems/longest-palindrome
        static public int LongestPalindrome(string s)
        {
            var map = new Dictionary<char, int>();
            var result = 0;

            foreach (var ch in s)
            {
                if (map.ContainsKey(ch))
                    map[ch]++;
                else
                    map.Add(ch, 1);
            }

            foreach (var (key, value) in map)
            {
                var tmp = value % 2;

                if (tmp == 0)
                {
                    result += value;
                    map.Remove(key);
                }
                else if ((value != 1) && (tmp != 0))
                {
                    result += (value - 1);
                    map[key] = 1;
                }
            }

            if (map.Count > 0) result++;

            return result;
        }
        #endregion
        //-----------------------------------------------------//

        //-----------------------------------------------------//
        #region Day 6
        //https://leetcode.com/problems/n-ary-tree-preorder-traversal/
        static public IList<int> Preorder(Node root)
        {
            var result = new List<int>();

            Traversal(root);

            return result;

            void Traversal(Node node)
            {
                if (node == null) return;

                result.Add(node.val);

                foreach (var child in node.children)
                    Traversal(child);
            }
        }

        //https://leetcode.com/problems/binary-tree-level-order-traversal/
        static public IList<IList<int>> LevelOrder(TreeNode root)
        {
            if (root == null) return Array.Empty<int[]>();

            var result = new List<List<int>>() { };

            Traversal(root, 0);

            return result.ToArray();

            void Traversal(TreeNode? node, int level = 0)
            {
                if (node == null) return;

                if (result.Count < level + 1)
                    result.Add(new List<int>());

                result[level].Add(node.val);

                Traversal(node.left, level + 1);
                Traversal(node.right, level + 1);
            }
        }

        #endregion
        //-----------------------------------------------------//

    }
}

