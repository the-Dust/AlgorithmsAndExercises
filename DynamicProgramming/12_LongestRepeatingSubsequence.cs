using System;
using System.Collections.Generic;
using Utils;

namespace DynamicProgramming
{
    [ShouldRepeat]
    public class LongestRepeatingSubsequence
    {
        int[,] table;

        public void SelfTest()
        {
            var str1 = "axtbadcdbcfb";
            var str2 = "abc";
            var str3 = "aab";
            var str4 = "aabb";
            var str5 = "axxxy";
            var str6 = "letsleetcode";
            var res1 = Calculate(str1); // abc || adc
            var res2 = Calculate(str2); // ""
            var res3 = Calculate(str3); // a
            var res4 = Calculate(str4); // ab
            var res5 = Calculate(str5); // x
            var res6 = Calculate(str6); // lete
        }

        public string Calculate(string str)
        {
            table = new int[str.Length + 1, str.Length + 1];
            var used = new HashSet<int>();
            Func<int, int, int> lcs = null;
            lcs = (i, j) => {
                if (i == 0 || j == 0)
                    return 0;
                if (table[i, j] != 0)
                    return table[i, j];

                var res1 = lcs(i - 1, j);
                var res2 = lcs(i, j - 1);
                table[i, j] = Math.Max(res1, res2);
                var res3 = 0;
                if (i != j && str[i - 1] == str[j - 1] && !(used.Contains(j) || used.Contains(i))) {
                    res3 = lcs(i - 1, j - 1) + 1;
                    if (res3 > table[i, j])
                    {
                        table[i, j] = res3;
                        used.Add(i);
                        used.Add(j);
                    }
                }
                return table[i, j];
            };

            var res = lcs(str.Length, str.Length);
            return Restore(table, str);
        }

        private string Restore(int[,] table, string str)
        {
            int i = table.GetLength(0) - 1;
            int j = table.GetLength(1) - 1;
            int count = table[i, j];
            char[] arr = new char[count];
            while (i > 0 && j > 0 && table[i, j] != 0)
            {
                if (table[i, j] == table[i, j - 1])
                    j--;
                else if (table[i, j] == table[i - 1, j])
                    i--;
                else
                {
                    count--;
                    arr[count] = str[i - 1];
                    i--;
                    j--;
                }
            }
            return string.Concat(arr);
        }
    }
}
