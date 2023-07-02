using Utils;

namespace AlgorithmicWarmUp
{
    [ShouldRepeat]
    public class FibonacciNumber
    {
        public void SelfTest()
        {

        }

        public long Calculate(long num)
        {
            if (num < 2) return num;

            long a = 0;
            long b = 1;
            for (long n = 2; n <= num; n++)
            {
                var cur = a + b;
                a = b;
                b = cur;
            }
            return b;
        }
    }
}
