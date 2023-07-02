using System;
using System.Collections.Generic;
using Utils;

namespace DynamicProgramming
{
    [ShouldRepeat]
    public class Knapsack
    {
        public void SelfTest()
        {
            var knapsackRes1 = Calculate(new[] { 1, 4, 8 }, 10);
            var knapsackRes2 = Calculate(new[] { 1, 3, 4 }, 8);
        }

        public int[] Calculate(int[] weights, int capacity)
        {
            bool[,] table = new bool[weights.Length + 1, capacity + 1];
            for (int i = 0; i < weights.Length + 1; i++)
            {
                table[i, 0] = true;
            }

            for (int i = 1; i < weights.Length + 1; i++)
            {
                for (int w = 1; w < capacity + 1; w++)
                {
                    int wi = weights[i-1];
                    if (wi > w)
                    {
                        table[i, w] = table[i - 1, w];
                    }
                    else
                    {
                        table[i, w] = table[i - 1, w] || table[i - 1, w - wi];
                    }
                }
            }

            var list = new List<int>();

            for (int i = weights.Length, j = capacity; i > 0 || j > 0;)
            {
                var cur = table[i, j];
                var left = table[i - 1, j];
                if (!cur)
                {
                    j--;
                }
                else if (cur && !left)
                {
                    var wi = weights[i-1];
                    list.Add(wi);
                    j -= wi;
                    i--;
                }
                else
                {
                    i--;
                }
            }

            list.Reverse();
            return list.ToArray();
        }
    }
}
