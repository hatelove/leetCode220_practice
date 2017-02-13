using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace leetCode220
{
    [TestClass]
    public class UnitTest1
    {
        [TestCategory("validation")]
        [TestMethod]
        public void k_is_0_should_return_false()
        {
            var nums = new int[] { 9 };
            ShouldBeFalse(nums, 0, 0);
        }

        [TestCategory("validation")]
        [TestMethod]
        public void nums_length_less_than_2_should_return_false()
        {
            var nums = new int[] { 9 };
            ShouldBeFalse(nums, 1, 1);
        }

        [TestCategory("t is 0")]
        [TestMethod]
        public void when_t_is_0_and_k_is_1_nums_5_5_should_return_true()
        {
            var nums = new int[] { 5, 5 };
            ShouldBeTrue(nums, 1, 0);
        }

        [TestCategory("t is 0")]
        [TestMethod]
        public void when_t_is_0_and_k_is_1_nums_5_6_5_should_return_false()
        {
            var nums = new int[] { 5, 6, 5 };
            ShouldBeFalse(nums, 1, 0);
        }

        [TestCategory("t is not 0")]
        [TestMethod]
        public void when_t_is_1_and_k_is_1_nums_5_6_should_return_true()
        {
            var nums = new int[] { 5, 6 };
            ShouldBeTrue(nums, 1, 1);
        }

        [TestCategory("t is not 0")]
        [TestMethod]
        public void when_t_is_1_and_k_is_1_nums_6_5_should_return_true()
        {
            var nums = new int[] { 6, 5 };
            ShouldBeTrue(nums, 1, 1);
        }

        [TestMethod]
        public void when_t_is_2_and_k_is_2_nums_6_5_4_should_return_true()
        {
            var nums = new int[] { 6, 5, 4 };
            ShouldBeTrue(nums, 2, 2);
        }

        [TestMethod]
        public void nums_1_3_1_k_is_2_t_is_1_should_be_true()
        {
            var nums = new int[] { 1, 3, 1 };
            ShouldBeTrue(nums, 2, 1);
        }

        [TestMethod]
        public void MyTestMethod_()
        {
            var nums = new int[] { 20, 11, 14, 30, 17, 18 };
            ShouldBeTrue(nums, 1, 1);
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
            if (k == 0)
            {
                return false;
            }

            var orderByNum = nums.Select((x, index) => Tuple.Create(index, x))
                .OrderBy(x => x.Item2).ToList();

            //var set = new HashSet<int>(new DiffEqualityComparer(t));
            for (int i = 0; i < nums.Length; i++)
            {
                var item = nums[i];

                var indexOfOrderByNum = orderByNum.FindIndex(x => x.Item2 == item);

                var counter = 1;
                var current = orderByNum[indexOfOrderByNum].Item2;
                var currentIndex = orderByNum[indexOfOrderByNum].Item1;

                while ((indexOfOrderByNum + counter) <= orderByNum.Count - 1)
                {
                    //r
                    var right = orderByNum[indexOfOrderByNum + counter].Item2;
                    var rightIndex = orderByNum[indexOfOrderByNum + counter].Item1;

                    if ((right - current) <= t && Math.Abs(rightIndex - currentIndex) <= k)
                    {
                        return true;
                    }
                    counter++;
                }

                counter = 1;
                while ((indexOfOrderByNum - counter) >= 0)
                {
                    var left = orderByNum[indexOfOrderByNum - counter].Item2;
                    var leftIndex = orderByNum[indexOfOrderByNum - counter].Item1;
                    if ((current - left) <= t && Math.Abs(leftIndex - currentIndex) <= k)
                    {
                        return true;
                    }
                    counter++;
                }
            }

            return false;
        }
    }

    internal class DiffEqualityComparer : IEqualityComparer<int>
    {
        private readonly int _t;

        public DiffEqualityComparer(int t)
        {
            this._t = t;
        }

        public bool Equals(int x, int y)
        {
            return Math.Abs((long)x - (long)y) <= this._t;
        }

        public int GetHashCode(int obj)
        {
            return 0;
        }
    }
}