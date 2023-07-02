using Utils;

namespace GreedyAlgorithms
{
    [ShouldRepeat]
    public class MaximumAdvertisementRevenue
    {
        public void SelfTest()
        {
            var res1 = Calculate(new long[] { 1, 3, 5 }, new long[] { 2, 4, 1 }); // 27
            var res2 = Calculate(new long[] { 1, 2, 3, 4, 5 }, new long[] { 1, 0, 1, 0, 1 }); // 12
        }

        public long Calculate(long[] a, long[] b)
        {
            var s1 = a.OrderBy(x => x);
            var s2 = b.OrderBy(x => x).ToArray();
            var ans = s1.Select((e, i) => e * s2[i]).Sum();
            return ans;
        }
    }
}
