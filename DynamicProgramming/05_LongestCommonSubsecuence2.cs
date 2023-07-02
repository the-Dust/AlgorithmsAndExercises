using System;
using System.Linq;
using Utils;

namespace DynamicProgramming
{
    [ShouldRepeat]
    public class LongestCommonSubsecuence2
    {
        public void SelfTest()
        {
            var lcs2Res1 = Get(new[] { 2, 7, 5 }, new[] { 2, 5 }); // 2
            var lcs2Res2 = Get(new[] { 7 }, new[] { 1, 2, 3, 4 }); // 0
            var lcs2Res3 = Get(new[] { 2, 7, 8, 3 }, new[] { 5, 2, 8, 7 }); // 2
        }

        public int Get(int[] a, int[] b)
        {
            var table = new int[a.Length + 1, b.Length + 1];
            for (int i = 1; i <= a.Length; i++)
            {
                for (int j = 1; j <= b.Length; j++)
                {
                    table[i, j] = Math.Max(table[i - 1, j], table[i, j - 1]);
                    if (a[i - 1] == b[j - 1])
                    {
                        table[i, j] = Math.Max(table[i, j], table[i - 1, j - 1] + 1);
                    }
                }
            }

            return table[a.Length, b.Length];
        }

        private int Max(params int[] arr) => arr.Max();
    }
}
