using System;
using Utils;

namespace DynamicProgramming
{
    [ShouldRepeat]
    public class LongestPalindrome
    {
        public void SelfTest()
        {
            var lpRes1 = Calculate("bmanchdaem"); // madam
            var lpRes2 = Calculate("bmanchddaem"); // maddam
            var lpRes3 = Calculate("abc"); // c
            var lpRes4 = Calculate("abyuzsfqpmccbagggg"); // abccba
        }

        public string Calculate(string a)
        {
            int[,] table = CreateTable(a.Length + 1, a.Length + 1);
            var l = Calculate(a, 0, a.Length, table);
            var res = GetPalindrome(table, a);
            return res;
        }

        private int Calculate(string a, int i, int j, int[,] table)
        {
            if (table[i, j] == -1)
            {
                if (i == j)
                    table[i, j] = 0;
                else if (j - i == 1)
                    table[i, j] = 1;
                else
                {
                    if (a[i] == a[j-1])
                        table[i, j] = Calculate(a, i + 1, j - 1, table) + 2;
                    else
                        table[i, j] = Math.Max(Calculate(a, i + 1, j, table), Calculate(a, i, j - 1, table));
                }
            }
            
            return table[i, j];
        }

        private string GetPalindrome(int[,] table, string a)
        {
            int i = 0;
            int j = table.GetLength(1) - 1;
            char[] word = new char[table[i, j]];
            int cur = 0;
            while(i != j)
            {
                if (table[i, j] == 1) 
                {
                    word[cur] = a[j - 1];
                    break;
                }
                if (table[i,j] == table[i,j - 1])
                    j--;
                else if (table[i, j] == table[i + 1, j])
                    i++;
                else
                {
                    word[cur] = a[j-1];
                    word[word.Length - cur - 1] = a[j - 1];
                    cur++;
                    i++;
                    j--;
                }
            }
            return string.Concat(word);
        }

        private int[,] CreateTable(int a, int b)
        {
            var table = new int[a, b];
            for(int i = 0; i<table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    table[i, j] = -1;
                }
            }
            return table;
        }
    }
}
