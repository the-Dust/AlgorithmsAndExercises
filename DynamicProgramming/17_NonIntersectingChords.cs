using System;
using System.Linq;
using Utils;

namespace DynamicProgramming
{
    [ShouldRepeat]
    public class NonIntersectingChords
    {
        private long[] map = Array.Empty<long>();

        public void SelfTest()
        {
            var a1 = Calculate(0); // 1
            var a2 = Calculate(1); // 1
            var a3 = Calculate(2); // 2
            var a4 = Calculate(3); // 5
            var a5 = Calculate(4); // 14
            var a6 = Calculate(5); // 42
            var a7 = Calculate(6); // 132
            var a8 = Calculate(7); // 429
            var a9 = Calculate(8); // 1430
        }

        public long Calculate(int n)
        {
            map = Enumerable.Repeat(-1l, n+1).ToArray();
            return Ways(n);
        }

        private long Ways(int i, int a)
        {
            var k = (i - 1) / 2;
            var n = a / 2;
            return Ways(k) * Ways(n - k - 1);
        }

        private long Ways(int n)
        {
            var a = 2 * n;

            if (a <= 2)
                return 1;
            if (map[n] != -1)
                return map[n];

            long result = 0;
            
            for(int i = 1; i < a; i += 2)
            {
                result += Ways(i, a);
            }
            map[n] = result;
            return result;
        }
    }
}
