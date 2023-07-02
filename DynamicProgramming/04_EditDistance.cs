using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace DynamicProgramming
{
    [ShouldRepeat]
    public class EditDistance
    {
        public void SelfTest()
        {
            var edRes1 = Get("short", "ports", true); // 3
            var edRes2 = Get("editing", "distance", true); // 5
            var edRes3 = Get("ab", "ab", true); // 0
        }

        public int Get(string a, string b, bool reconstruct = false)
        {
            var table = BuildTable(a.Length+1, b.Length+1);
            for (int i = 1; i < a.Length + 1; i++)
            {
                for (int j = 1; j < b.Length + 1; j++)
                {
                    var delete = table[i-1, j] + 1;
                    var insert = table[i, j-1] + 1;
                    var mismatch = table[i - 1, j - 1] + 1;
                    var match = table[i - 1, j - 1];

                    if (a[i-1] == b[j-1])
                    {
                        table[i, j] = Min(delete, insert, match);
                    }
                    else
                    {
                        table[i, j] = Min(delete, insert, mismatch);
                    }
                }
            }

            if (reconstruct)
            {
                Reconstruct(table, a, b);
            }

            return table[a.Length, b.Length];
        }

        private int[,] BuildTable(int l, int m)
        {
            var table = new int[l, m];
            for (int i = 0; i < l; i++)
            {
                table[i, 0] = i;
            }
            for (int i = 0; i < m; i++)
            {
                table[0, i] = i;
            }

            return table;
        }

        private T Min<T>(params T[] values)
        {
            return values.Min();
        }

        private void Reconstruct(int[,] table, string a, string b)
        {
            var list = new List<char[]>();

            int i = table.GetLength(0) - 1;
            int j = table.GetLength(1) - 1;
            while (i > 0 || j > 0)
            {
                if (i > 0 && table[i, j] == table[i - 1, j] + 1)
                {
                    list.Add(new[] { a[i - 1], '-' });
                    i--;
                }
                else if (j > 0 && table[i, j] == table[i, j-1] + 1)
                {
                    list.Add(new[] { '-', b[j - 1] });
                    j--;
                }
                else
                {
                    list.Add(new[] { a[i - 1], b[j - 1] });
                    i--;
                    j--;
                }
            }

            list.Reverse();
            var str1 = string.Concat(list.Select(x => x[0]));
            var str2 = string.Concat(list.Select(x => x[1]));
            Console.WriteLine(str1);
            Console.WriteLine(str2);
        }
    }
}
