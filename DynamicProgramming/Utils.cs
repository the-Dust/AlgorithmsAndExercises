using System;
using System.Linq;

namespace DynamicProgramming
{
    internal class InternalUtils
    {
        public static void PrintTable(int[,] table, string a)
        {
            Console.WriteLine("     " + string.Concat(a.Select(x => $"{x} ")));
            for (int i = 0; i < table.GetLength(0); i++)
            {
                Console.Write(i > 0 && i <= a.Length ? $"{a[i - 1]}: " : " : ");
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    Console.Write(table[i, j] == -1 ? "x " : table[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
