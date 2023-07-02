using Utils;

namespace DivideConquer
{
    [ShouldRepeat]
    public class BinarySearchWithDuplicates
    {
        public void SelfTest()
        {
            var arr = new int[] { 2, 4, 4, 4, 7, 7, 9 };

            var res1 = Calculate(arr, 9); // 6
            var res2 = Calculate(arr, 4); // 1
            var res3 = Calculate(arr, 5); // -1
            var res4 = Calculate(arr, 2); // 0
            var res5 = Calculate(arr, 1); // -1
            var res6 = Calculate(arr, 7); // 4
            var res7 = Calculate(arr, 13); // -1
        }

        public int Calculate(int[] arr, int a) => Calculate(arr, a, 0, arr.Length);

        private int Calculate(int[] arr, int a, int s, int e)
        {
            var res = -1;

            while (s < e)
            {
                var m = (s + e) / 2;
                if (arr[m] == a)
                {
                    res = m;
                    e = m;
                }
                else if (arr[m] > a)
                    e = m;
                else
                    s = m + 1;
            }
            return res;
        }
    }
}
