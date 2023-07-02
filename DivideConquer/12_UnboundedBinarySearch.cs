using System.Linq;
using Utils;

namespace DivideConquer
{
    [ShouldRepeat]
    public class UnboundedBinarySearch
    {
        public void SelfTest()
        {
            int[] arr = Enumerable.Range(1, 1_000_000).ToArray();
            arr[100] = 100;

            var res1 = Calculate(arr, 99); // 98
            var res2 = Calculate(arr, 389_473); // 389_472
            var res3 = Calculate(arr, 101); // -1
        }

        public int Calculate(int[] arr, int q)
        {
            // assume that arr has infinity length
            var l = 0;
            var r = 1;
            while (arr[r] < q)
            {
                r *= 2;
            }
            while(l<r)
            {
                var m = l + (r - l) / 2;
                if (arr[m] == q)
                    return m;
                else if (arr[m] < q)
                    l = m + 1;
                else
                    r = m;
            }
            return -1;
        }
    }
}
