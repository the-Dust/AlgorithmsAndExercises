using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace DynamicProgramming
{
    [ShouldRepeat]
    public class MaximumValueArithmeticExpression
    {
        private Dictionary<char, Func<long, long, long>> operations = new()
        {
            ['+'] = (a, b) => a + b,
            ['-'] = (a, b) => a - b,
            ['*'] = (a, b) => a * b,
        };

        public void SelfTest()
        {
            var str1 = "5-8";
            var str2 = "3+2*4";
            var str3 = "5-8+7*4-8+9";
            var res1 = Calculate(str1); // -3
            var res2 = Calculate(str2); // 20
            var res3 = Calculate(str3); // 200
        }

        public long Calculate(string expression)
        {
            var (nums, ops) = Parse(expression);
            Calculation[,] cache = new Calculation[nums.Length + 1, nums.Length + 1];

            Func<int, int, Calculation> calculateInternal = null;

            calculateInternal = (int l, int r) =>
            {
                if (cache[l, r] != null)
                    return cache[l, r];
                if (l == r)
                {
                    cache[l, r] = new Calculation(nums[l], nums[l]);
                    return cache[l, r];
                }

                var arr = new int[r - l].Select((e, i) =>
                {
                    var m = l + i;
                    var op = ops[m];
                    var left = calculateInternal(l, m);
                    var right = calculateInternal(m + 1, r);
                    var arr = new long[] {
                        op(left.Min, right.Min),
                        op(left.Min, right.Max),
                        op(left.Max, right.Min),
                        op(left.Max, right.Max)
                    };
                    return arr;
                }).SelectMany(x => x).ToArray();
                cache[l, r] = new Calculation(arr.Min(), arr.Max());
                return cache[l, r];
            };

            var res = calculateInternal(0, nums.Length - 1);

            return res.Max;
        }

        private (int[] nums, Func<long, long, long>[] ops) Parse(string expression)
        {
            int[] nums = new int[expression.Length/2+1];
            Func<long, long, long>[] ops = new Func<long, long, long>[expression.Length/2];
            int i = 0;
            for(; i< expression.Length-1; i+=2)
            {
                nums[i/2] = expression[i] - '0';
                ops[i/2] = operations[expression[i + 1]];
            }
            nums[i / 2] = expression[i] - '0';
            return (nums, ops);
        }

        class Calculation
        {
            public long Min { get; set; }
            public long Max { get; set; }

            public Calculation(long min, long max)
            {
                Min = min; Max = max;
            }
        }
    }
}
