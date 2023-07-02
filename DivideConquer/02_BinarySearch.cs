using Utils;

namespace DivideConquer
{
    [ShouldRepeat]
    public class BinarySearch
    {
        public void SelfTest()
        {
            var arr = new int[] { 1, 5, 8, 12, 13 };

            var res1 = Calculate(arr, 8); // 2
            var res2 = Calculate(arr, 1); // 0
            var res3 = Calculate(arr, 23); // -1
            var res4 = Calculate(arr, 1); // 0
            var res5 = Calculate(arr, 11); // -1
            var res6 = Calculate(arr, 5); // 1
            var res7 = Calculate(arr, 13); // 4
        }

        public int Calculate(int[] arr, int a) => Calculate(arr, a, 0, arr.Length);

        private int Calculate(int[] arr, int a, int s, int l)
        {
            while (s < l)
            {
                int m = (s + l) / 2;
                if (arr[m] == a)
                    return m;
                else if (arr[m] > a)
                    l = m;
                else
                    s = m + 1;
            }
            return -1;
        }
    }
}
