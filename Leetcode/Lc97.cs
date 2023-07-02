using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class Lc97
    {
        public void SelfTest()
        {
            var res0 = IsInterleave("ab", "bc", "bbac"); // true
            var res1 = IsInterleave("aabcc", "dbbca", "aadbbcbcac"); // true
            var res2 = IsInterleave("aabcc", "dbbca", "aadbbbaccc"); // false
            var res3 = IsInterleave("", "", ""); // true
        }

        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length)
                return false;
            bool[,] table = new bool[s1.Length + 1, s2.Length + 1];
            table[0, 0] = true;
            for (int i = 1; i <= s1.Length; i++)
                table[i, 0] = table[i - 1, 0] && s1[i - 1] == s3[i - 1];
            for (int i = 1; i <= s2.Length; i++)
                table[0, i] = table[0, i - 1] && s2[i - 1] == s3[i - 1];
            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    var cur = s3[i + j - 1];
                    table[i, j] = (table[i - 1, j] || table[i, j - 1])
                        && (s1[i - 1] == cur || s2[j - 1] == cur);
                }
            }
            return table[s1.Length, s2.Length];
        }
    }
}
