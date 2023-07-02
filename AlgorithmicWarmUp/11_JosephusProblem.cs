using Utils;

namespace AlgorithmicWarmUp
{
    [ShouldRepeat]
    public class JosephusProblem
    {
        public void SelfTest()
        {

        }

        public int Calculate(int n, int k)
        {
            // zero-based numeration
            return n < 2 ? 0 : (k + Calculate(n - 1, k)) % n;
        }
    }
}
