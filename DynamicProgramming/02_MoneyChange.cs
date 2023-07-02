using System;
using System.Linq;
using Utils;

namespace DynamicProgramming
{
    [ShouldRepeat]
    public class MoneyChange
    {
        public void SelfTest()
        {
            var mcRes1 = GetChange(34); // 9
            var mcRes2 = GetChange(26); // 7
            var mcRes3 = GetChange(15); // 4
        }

        public int GetChange(int money)
        {
            int[] map = Enumerable.Repeat(int.MaxValue, money+1).ToArray();
            map[0] = 0;
            int[] coins = { 1, 3, 4 };

            for (int i = 1; i <= money; i++)
            {
                foreach (var coin in coins)
                {
                    if (coin <= i)
                    {
                        map[i] = Math.Min(map[i], 1 + map[i - coin]);
                    }
                }
            }

            return map[money];
        }
    }
}
