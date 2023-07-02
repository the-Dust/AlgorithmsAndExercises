using Utils;

namespace AlgorithmicWarmUp
{
    [ShouldRepeat]
    public class LastDigitPartialSumFibonacciNumbers
    {
        public void SelfTest()
        {

        }

        public int Calculate(long m, long n)
        {
            int p = Pisano(10);
            int newN = (int)(n + 2) % p;
            int newM = (int)(m + 1) % p;
            var sn = Fib(newN);
            var sm = Fib(newM);
            var res = (10 + sn - sm) % 10;
            return res;
        }

        private int Fib(int m)
        {
            if (m < 2) return m;

            int a = 0;
            int b = 1;
            for (int i = 2; i <= m; i++)
            {
                var cur = (a + b) % 10;
                a = b;
                b = cur;
            }
            return b;
        }

        private int Pisano(int m)
        {
            if (m < 2) return m;

            int a = 0;
            int b = 1;
            int i = 0;
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
