using System;
using System.Linq;
using Utils;

namespace DynamicProgramming
{
    [ShouldRepeat]
    public class LongestCommonSubsecuence3
    {
        public void SelfTest()
        {
            var lcs3Res1 = Get(new[] { 1, 2, 3 }, new[] { 2, 1, 3 }, new[] { 1, 3, 5 }); // 2
            var lcs3Res2 = Get(
                new[] { 8, 3, 2, 1, 7 },
                new[] { 8, 2, 1, 3, 8, 10, 7 },
                new[] { 6, 8, 3, 1, 4, 7 }); // 3
        }

        public int Get(int[] a, int[] b, int[] c)
        {
            var table = new int[a.Length + 1, b.Length + 1, c.Length + 1];

            for (int i = 1; i <= a.Length; i++)
            {
                for (int j = 1; j <= b.Length; j++)
                {
                    for (int k = 1; k <= c.Length; k++)
                    {
                        table[i, j, k] = Max(table[i - 1, j, k], table[i, j - 1, k], table[i, j, k - 1]);
                        if (a[i - 1] == b[j - 1] && b[j - 1] == c[k - 1])
                        {
                            table[i, j, k] = Math.Max(table[i, j, k], table[i - 1, j - 1, k - 1] + 1);
                        }
                    }
                }
            }

            return table[a.Length, b.Length, c.Length];
        }

        private int Max(params int[] val) => val.Max();
    }
}
