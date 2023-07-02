using System;
using Utils;

namespace DynamicProgramming
{
    [ShouldRepeat]
    public class CoinGame
    {
        public void SelfTest()
        {
            var cgRes1 = Money(new[] { 2l, 1, 9, 3 }); // 11
            var cgRes2 = Money(new[] { 2l, 9, 1, 3 });
        }

        public long Money(long[] coins)
        {
            var table = new long[coins.Length + 1, coins.Length + 1];
            return Money(coins, table, 0, coins.Length);
        }

        private long Money(long[] coins, long[,] table, int i, int count)
        {
            if (count == 2)
            {
                return Math.Max(coins[i], coins[i + 1]);
            }
            if (table[i, count] != 0)
            {
                return table[i, count];
            }
            var res = Math.Max(MoneyLeft(coins, table, i, count), MoneyRight(coins, table, i, count));
            table[i, count] = res;
            return res;
        }

        private long MoneyLeft(long[] coins, long[,] table, int i, int count)
        {
            return coins[i] + Math.Min(Money(coins, table, i + 2, count - 2), Money(coins, table, i + 1, count - 2));
        }

        private long MoneyRight(long[] coins, long[,] table, int i, int count)
        {
            return coins[i + count - 1] + Math.Min(Money(coins, table, i + 1, count - 2), Money(coins, table, i, count - 2));
        }
    }
}
