using Utils;

namespace AlgorithmicWarmUp
{
    [ShouldRepeat]
    public class LeastCommonMultiple
    {
        public void SelfTest()
        {

        }

        public long Calculate(long a, long b)
        {
            var gcd = GCD(a, b);
            var m = a / gcd;
            var n = b / gcd;
            return gcd * m * n;
        }

        private long GCD(long a, long b) => a == 0 || b == 0 ? Math.Max(a, b) : GCD(b, a % b);
    }
}
