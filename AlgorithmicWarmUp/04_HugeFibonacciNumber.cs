using Utils;

namespace AlgorithmicWarmUp
{
    [ShouldRepeat]
    public class HugeFibonacciNumber
    {
        public void SelfTest()
        {

        }

        public long Calculate(long n, int m)
        {
            var p = Pisano(m);
            var newN = n % p;
            return Fib(newN, m);
        }

        private long Fib(long n, int m)
        {
            if (n < 2) return n;

            var a = 0;
            var b = 1;
            for (var i = 2; i <= n; i++)
            {
                var cur = (a + b) % m;
                a = b;
                b = cur;
            }
            return b;
        }

        private int Pisano(int m)
        {
            var i = 0;
            var a = 0;
            var b = 1;
            do
            {
                var cur = (a + b) % m;
                a = b;
                b = cur;
                i++;
            } while (!(a == 0 && b == 1));
            return i;
        }

        // second solution with matrix exponentiation

        public long Calculate2(long n, int m)
        {
            if (n < 2) return n;

            var arr = new int[][] { new[] { 0, 1 }, new[] { 1, 1 } };
            var p = Pisano(m);
            var iTrim = (int)(n % p);
            var res = FastPower(arr, iTrim, m);
            return res[1][0];
        }

        private int[][] MultiplyMatrix(int[][] a, int[][] b, int m)
        {
            int r00 = (a[0][0] * b[0][0] + a[0][1] * b[1][0]) % m;
            int r01 = (a[0][0] * b[0][1] + a[0][1] * b[1][1]) % m;
            int r10 = (a[1][0] * b[0][0] + a[1][1] * b[1][0]) % m;
            int r11 = (a[1][0] * b[0][1] + a[1][1] * b[1][1]) % m;
            return new int[][] { new[] { r00, r01 }, new[] { r10, r11 } };
        }

        private int[][] FastPower(int[][] a, int n, int m)
        {
            if (n == 0)
            {
                return new int[][] { new[] { 1, 0 }, new[] { 0, 1 } };
            }
            if (n % 2 == 0)
            {
                var z = FastPower(a, n / 2, m);
                return MultiplyMatrix(z, z, m);
            }
            else
            {
                var z = FastPower(a, n / 2, m);
                var pow = MultiplyMatrix(z, z, m);
                return MultiplyMatrix(pow, a, m);
            }
        }
    }
}
