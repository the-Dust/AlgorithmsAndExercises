using System;
using System.Collections.Generic;
using Utils;

namespace DynamicProgramming
{
    [ShouldRepeat]
    public class PrimitiveCalculator
    {
        public void SelfTest()
        {
            var calcRes1 = Calculate(1);
            var calcRes2 = Calculate(96234);
        }

        public int[] Calculate(int num)
        {
            int[] table = new int[num + 1];

            for (int i = 1; i <= num; i++)
            {
                table[i] = 1 + table[i - 1];
                if (i % 2 == 0)
                {
                    table[i] = Math.Min(1 + table[i / 2], table[i]);
                }
                if (i % 3 == 0)
                {
                    table[i] = Math.Min(1 + table[i / 3], table[i]);
                }
            }

            var cur = num;
            var res = new List<int>() { cur };
            
            while (cur > 1)
            {
                if (cur % 3 == 0 && table[cur] - table[cur / 3] == 1)
                {
                    cur /= 3;
                    res.Add(cur);
                }
                else if (cur % 2 == 0 && table[cur] - table[cur / 2] == 1)
                {
                    cur /= 2;
                    res.Add(cur);
                }
                else
                {
                    cur -= 1;
                    res.Add(cur);
                }
            }

            res.Reverse();
            return res.ToArray();
        }
    }
}
