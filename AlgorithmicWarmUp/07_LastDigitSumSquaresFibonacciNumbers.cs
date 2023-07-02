using Utils;

namespace AlgorithmicWarmUp
{
    [ShouldRepeat]
    public class LastDigitSumSquaresFibonacciNumbers
    {
        public void SelfTest()
        {

        }

        public int Calculate(long n)
        {
            // (F1)^2 + (F2)^2 + ... + (Fn)^2 = Fn*F(n+1) - proof by induction

            var p = Pisano(10);
            var newN = (int)(n % p);
            var fn = Fib(newN);
            var fn1 = Fib(newN+1);
            return (fn * fn1) % 10;
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

        private int Fib(int n)
        {
            if (n < 2) return n;

            int a = 0;
            int b = 1;
            for(int i = 2; i<=n; i++)
            {
                var cur = (a + b) % 10;
                a = b;
                b = cur;
            }

            return b;
        }
    }
}
