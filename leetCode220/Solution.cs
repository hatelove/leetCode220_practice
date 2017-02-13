using System;
using System.Collections.Generic;
using System.Linq;

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

            var list = new List<int>();
            for (int i = 0; i < orderByNum.Count; i++)
            {
                list.Add(orderByNum[i].Item2);

                if (i > 0)
                {
                    //single
                    var counter = 1;
                    while ((i - counter) >= 0)
                    {
                        var diffValue = (long)list[i] - (long)list[i - counter];
                        if (diffValue > t)
                        {
                            break;
                        }

                        var diffIndex = Math.Abs(orderByNum[i].Item1 - orderByNum[i - counter].Item1);
                        if (diffIndex <= k)
                        {
                            return true;
                        }
                        counter++;
                    }
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