using Utils;

namespace AlgorithmicWarmUp
{
    [ShouldRepeat]
    public class RangeSumQueries
    {
        public void SelfTest()
        {
            var arr = new[] { 2, -1, 7, 2, -3, -2, 4 };
            var ranges = new[] { (0, 0), (1, 3), (2, 5), (6, 6), (0, 6)};

            var res = Calculate(arr, ranges); // 2, 8, 4, 4, 9
        }

        public int[] Calculate(int[] arr, (int l, int r)[] ranges)
        {
            var sums = new int[arr.Length + 1];
            for(int i = 1; i < sums.Length; i++)
            {
                sums[i] = sums[i - 1] + arr[i - 1];
            }

            var result = new int[ranges.Length];
            for(int i = 0; i < ranges.Length; i++)
            {
                var l = ranges[i].l;
                var r = ranges[i].r;
                result[i] = sums[r + 1] - sums[l];
            }
            return result;
        }
    }
}
