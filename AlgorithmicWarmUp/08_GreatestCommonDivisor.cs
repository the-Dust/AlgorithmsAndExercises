using Utils;

namespace AlgorithmicWarmUp
{
    [ShouldRepeat]
    public class GreatestCommonDivisor
    {
        public void SelfTest()
        {

        }

        public long Calculate(long a, long b)
        {
            if (a == 0) return b;
            return a > b ? Calculate(a % b, b) : Calculate(b % a, a);
        }
    }
}
