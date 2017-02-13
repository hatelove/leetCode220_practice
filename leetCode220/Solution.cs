using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCode220
{
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
                var current = (long)orderByNum[indexOfOrderByNum].Item2;
                var currentIndex = orderByNum[indexOfOrderByNum].Item1;

                while ((indexOfOrderByNum + counter) <= orderByNum.Count - 1)
                {
                    //r
                    var right = (long)orderByNum[indexOfOrderByNum + counter].Item2;
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
                    var left = (long)orderByNum[indexOfOrderByNum - counter].Item2;
                    var leftIndex = orderByNum[indexOfOrderByNum - counter].Item1;
                    if ((current - left) <= t && Math.Abs(leftIndex - currentIndex) <= k)
                    {
                        return true;
                    }
                    counter++;
                }

                orderByNum.Remove(orderByNum[indexOfOrderByNum]);
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
