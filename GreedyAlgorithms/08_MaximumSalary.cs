using Utils;

namespace GreedyAlgorithms
{
    [ShouldRepeat]
    public class MaximumSalary
    {
        public void SelfTest()
        {

        }

        public long Calculate(int[] digits)
        {
            var arr = digits.OrderByDescending(x => x, new CustomComparer());
            var str = string.Concat(arr);
            var res = long.Parse(str);
            return res;
        }

        class CustomComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                var a = long.Parse($"{x}{y}");
                var b = long.Parse($"{y}{x}");
                return a.CompareTo(b);
            }
        }

        // alternative solution without string creation

        public long Calculate2(int[] digits)
        {
            var arr = digits
                .Select(ToDigitArray)
                .OrderByDescending(x => x, new CustomComparer2())
                .SelectMany(x => string.Concat(x));
            var str = string.Concat(arr);
            var res = long.Parse(str);
            return res;
        }

        private static int[] ToDigitArray(int n)
        {
            List<int> list = new List<int>();
            while (n > 0)
            {
                list.Add(n % 10);
                n = n / 10;
            }
            list.Reverse();
            return list.ToArray();
        }

        class CustomComparer2 : IComparer<int[]>
        {
            public int Compare(int[] x, int[] y)
            {
                var end = LCM(x.Length, y.Length);
                for (int i = 0; i < end; i++)
                {
                    var a = x[i % x.Length];
                    var b = y[i % y.Length];
                    if (a != b) return a.CompareTo(b);
                }

                return 0;
            }

            public static int LCM(int a, int b)
            {
                var gcd = GCD(a, b);
                return a * b / gcd;
            }

            public static int GCD(int a, int b)
            {
                if (b == 0) return a;
                return GCD(b, a % b);
            }
        }
    }
}
