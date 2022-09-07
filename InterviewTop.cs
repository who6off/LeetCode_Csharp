namespace LeetCode
{
    //https://leetcode.com/problem-list/top-interview-questions/
    public static class InterviewTop
    {
        //------HARD---------------------------------------------------------
        //https://leetcode.com/problems/merge-k-sorted-lists/
        static public ListNode? MergeKLists(ListNode[] lists)
        {
            lists = lists.Where(i => i != null).ToArray();

            if (lists.Length == 0) return null;

            var result = CopyList(lists[0]);

            for (int i = 1; i < lists.Length; i++)
            {
                var resultPtr = result;
                ListNode? prevResultPtr = null;

                while (resultPtr != null && lists[i] != null)
                {
                    if (lists[i].val <= resultPtr.val)
                    {
                        var tmp = resultPtr.val;
                        resultPtr.val = lists[i].val;
                        resultPtr.next = new ListNode(tmp, resultPtr.next);
                        lists[i] = lists[i].next;
                    }

                    prevResultPtr = resultPtr;
                    resultPtr = resultPtr.next;
                }

                if (lists[i] != null && prevResultPtr != null)
                {
                    prevResultPtr.next = CopyList(lists[i]);
                }
            }

            return result;

            ListNode CopyList(ListNode lst)
            {
                var result = new ListNode(lst.val);
                var tail = result;
                var tailInput = lst.next;

                while (tailInput != null)
                {
                    tail.next = new ListNode(tailInput.val);
                    tail = tail.next;
                    tailInput = tailInput.next;
                }

                return result;
            }
        }




        //------EASY---------------------------------------------------------
        //https://leetcode.com/problems/merge-two-sorted-lists/
        static public ListNode? MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null && list2 == null) return null;
            if (list1 == null) return CopyList(list2);
            if (list2 == null) return CopyList(list1);

            var list1Copy = CopyList(list1);
            var list1Ptr = list1Copy;
            var list2Ptr = list2;
            ListNode? prevList1Ptr = null;

            while (list1Ptr != null && list2Ptr != null)
            {
                if (list2Ptr.val <= list1Ptr.val)
                {
                    var tmp = list1Ptr.val;
                    list1Ptr.val = list2Ptr.val;
                    list1Ptr.next = new ListNode(tmp, list1Ptr.next);
                    list2Ptr = list2Ptr.next;
                }

                prevList1Ptr = list1Ptr;
                list1Ptr = list1Ptr.next;
            }

            if (list2Ptr != null && prevList1Ptr != null)
            {
                prevList1Ptr.next = CopyList(list2Ptr);
            }

            return list1Copy;

            ListNode CopyList(ListNode lst)
            {
                var result = new ListNode(lst.val);
                var tail = result;
                var tailInput = lst.next;

                while (tailInput != null)
                {
                    tail.next = new ListNode(tailInput.val);
                    tail = tail.next;
                    tailInput = tailInput.next;
                }

                return result;
            }
        }


        //https://leetcode.com/problems/valid-parentheses/
        static public bool IsValid(string s)
        {
            var stack = new Stack<char>();
            var parentheses = new Dictionary<char, char>()
            {
                { '(', ')' },
                { '{', '}' },
                { '[', ']' },
            };

            foreach (var ch in s)
            {
                if (parentheses.ContainsKey(ch))
                {
                    stack.Push(ch);
                }
                else if (parentheses.ContainsValue(ch))
                {
                    if (
                        !stack.TryPop(out char openingParanthes) ||
                        parentheses[openingParanthes] != ch
                    )
                    {
                        return false;
                    }

                    Console.WriteLine(openingParanthes);
                }
            }

            return stack.Count == 0;
        }


        //https://leetcode.com/problems/longest-common-prefix/
        static public string LongestCommonPrefix(string[] strs)
        {
            var result = "";

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
            var result = romanToArabic[s[s.Length - 1]];

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
