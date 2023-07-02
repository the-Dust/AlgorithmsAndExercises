using Utils;

namespace AlgorithmicWarmUp
{
    [ShouldRepeat]
    public class LastDigitSumFibonacciNumbers
    {
        public void SelfTest()
        {

        }

        public long Calculate(long n)
        {
            // S(n) = F(n+2) - 1
            // Доказательство по индукции: 
            // 0: S(0) = F(2) - 1 => 0 === 0
            // n+1: S(n+1) = S(n) + F(n+1) = F(n+2) - 1 + F(n+1) === F(n+3) - 1

            var p = Pisano(10);
            var newN = (n + 2) % p;
            var res = Fib(newN, 10) - 1;
            return res;
        }

        private long Fib(long n, long m)
        {
            if (m < 2) return n;

            long a = 0;
            long b = 1;

            for (int i = 2; i <= n; i++)
            {
                var cur = (a + b) % m;
                a = b;
                b = cur;
            }

            return b;
        }

        private long Pisano(long m)
        {
            if (m < 2) return m;

            long a = 0;
            long b = 1;
            var i = 0;
            do
            {
                var cur = (a + b) % m;
                a = b;
                b = cur;
                i++;
            } while (!(a == 0 && b == 1));

            return i;
        }
    }
}
