using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace leetCode220
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void k_is_0_should_return_false()
        {
            var nums = new int[] { 9 };
            ShouldBeFalse(nums, 0, 0);
        }

        [TestMethod]
        public void nums_length_less_than_2_should_return_false()
        {
            var nums = new int[] { 9 };
            ShouldBeFalse(nums, 1, 1);
        }

        [TestMethod]
        public void when_t_is_0_and_k_is_1_nums_5_5_should_return_true()
        {
            var nums = new int[] { 5, 5 };
            ShouldBeTrue(nums, 1, 0);
        }

        [TestMethod]
        public void when_t_is_0_and_k_is_1_nums_5_6_5_should_return_false()
        {
            var nums = new int[] { 5, 6, 5 };
            ShouldBeFalse(nums, 1, 0);
        }

        private void ShouldBeTrue(int[] nums, int k, int t)
        {
            Assert.IsTrue(new Solution().ContainsNearbyAlmostDuplicate(nums, k, t));
        }

        private static void ShouldBeFalse(int[] nums, int k, int t)
        {
            Assert.IsFalse(new Solution().ContainsNearbyAlmostDuplicate(nums, k, t));
        }
    }

    public class Solution
    {
        /// <summary>
        /// 給定整數數組，找出在陣列中是否存在兩個不同的索引i和j，
        /// 使得nums [i]和nums [j]之間的絕對差最大為t，
        /// 並且i和j之間的絕對差最大k。
        /// </summary>
        /// <param name="nums">The nums.</param>
        /// <param name="k">The k.</param>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            if (k == 0 || nums.Length < 2)
            {
                return false;
            }

            var set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!set.Add(nums[i])) return true;

                if (i >= k) set.Remove(nums[i - k]);
            }

            return false;
        }
    }
}