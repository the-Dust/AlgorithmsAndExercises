using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace DynamicProgramming
{
    [ShouldRepeat]
    public class InterleavingStrings
    {
        public void SelfTest()
        {
            var ilsRes1 = Calculate("ab", "cd", "abcd"); // true
            var ilsRes2 = Calculate("monkey", "tree", "mtonkreeye"); // true
            var ilsRes3 = Calculate("tree", "sort", "tsroerte"); // true
            var ilsRes4 = Calculate("ab", "cd", "abcdx"); // false
            var ilsRes5 = Calculate("ab", "cd", "adcb"); // false
            var ilsRes6 = Calculate("aabcc", "dbbca", "aadbbcbcac"); // true
            var ilsRes7 = Calculate("ab", "bc", "bbac"); // false

            var ilsRes11 = StackInterleave("ab", "cd", "abcd"); // true
            var ilsRes22 = StackInterleave("monkey", "tree", "mtonkreeye"); // true
            var ilsRes33 = StackInterleave("tree", "sort", "tsroerte"); // true
            var ilsRes44 = StackInterleave("ab", "cd", "abcdx"); // false
            var ilsRes55 = StackInterleave("ab", "cd", "adcb"); // false
            var ilsRes66 = StackInterleave("aabcc", "dbbca", "aadbbcbcac"); // true
        }

        public bool Calculate(string a, string b, string c)
        {
            if (a.Length + b.Length != c.Length)
            {
                return false;
            }

            var table = CreateTable(a, b, c);

            for (int i = 1; i < a.Length + 1; i++)
            {
                for (int j = 1; j < b.Length + 1; j++)
                {
                    table[i, j] = table[i - 1, j] && c[i + j - 1] == a[i - 1]
                        || table[i, j - 1] && c[i + j - 1] == b[j - 1];
                }
            }

            return table[a.Length, b.Length];
        }

        private bool[,] CreateTable(string a, string b, string c)
        {
            bool[,] table = new bool[a.Length + 1, b.Length + 1];
            table[0, 0] = true;
            for(int i = 1; i <= a.Length; i++)
            {
                table[i, 0] = table[i - 1, 0] && a[i - 1] == c[i - 1];
            }
            for (int i = 1; i <= b.Length; i++)
            {
                table[0, i] = table[0, i - 1] && b[i - 1] == c[i - 1];
            }
            return table;
        }

        // Incorrect solution, don't use it
        public bool StackInterleave(string a, string b, string c)
        {
            if (a.Length + b.Length != c.Length)
            {
                return false;
            }

            var stackA = new Stack<char>(a.Reverse().ToArray());
            var stackB = new Stack<char>(b.Reverse().ToArray());

            for(int i = 0; i < c.Length; i++)
            {
                if (stackA.Count > 0 && c[i] == stackA.Peek())
                {
                    stackA.Pop();
                }
                else if (stackB.Count > 0 && c[i] == stackB.Peek())
                {
                    stackB.Pop();
                }
                else return false;
            }
            return true;
        }
    }
}
