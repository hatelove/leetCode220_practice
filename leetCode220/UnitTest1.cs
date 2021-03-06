﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void nums_intMaxValue_should_not_throw_overflowException()
        {
            var nums = new int[] { int.MaxValue, -1 };
            ShouldBeFalse(nums, 1, 1);
        }

        [TestMethod]
        public void nums_20_11_14_30_17_18_k_is_1_tis_1_should_return_true()
        {
            var nums = new int[] { 20, 11, 14, 30, 17, 18 };
            ShouldBeTrue(nums, 1, 1);
        }

        [TestCategory("check find value index logic")]
        [TestMethod]
        public void nums_1_0_1_1_k_is_1_t_is_0_should_return_true()
        {
            var nums = new int[] { 1, 0, 1, 1 };
            ShouldBeTrue(nums, 1, 0);
        }

        [TestCategory("match t but not match k, has duplicate num")]
        [TestMethod]
        public void nums_0_10_22_15_0_5_22_12_1_5_k_is_3_t_is_3_should_return_false()
        {
            var nums = new int[] { 0, 10, 22, 15, 0, 5, 22, 12, 1, 5 };
            ShouldBeFalse(nums, 3, 3);
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
}