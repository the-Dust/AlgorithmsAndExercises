using Utils;

namespace AlgorithmicWarmUp
{
    [ShouldRepeat]
    public class LastDigitFibonacciNumber
    {
        public void SelfTest()
        {

        }

        public int Calculate(int n)
        {
            if (n < 2) return n;

            var a = 0;
            var b = 1;
            for (var i = 2; i <= n; i++)
            {
                var cur = (a + b) % 10;
                a = b;
                b = cur;
            }
            return b;
        }
    }
}
