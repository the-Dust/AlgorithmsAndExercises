using Utils;

namespace DivideConquer
{
    [ShouldRepeat]
    public class CountAnElementSortedArray
    {
        public void SelfTest()
        {
            int[] arr1 = { 1, 2, 3, 4 };
            int[] arr2 = { 1, 2, 2, 3, 4 };
            int[] arr3 = { 1, 2, 2, 2, 2 };
            int[] arr4 = { 2, 2, 2, 2 };
            int[] arr5 = { 2, 2, 2, 2, 3 };

            var res1 = Calculate(arr1, 0); // 0
            var res2 = Calculate(arr1, 2); // 1
            var res3 = Calculate(arr2, 2); // 2
            var res4 = Calculate(arr3, 2); // 4
            var res5 = Calculate(arr4, 2); // 4
            var res6 = Calculate(arr5, 2); // 4
        }

        public int Calculate(int[] arr, int q)
        {
            var first = BinarySearch(arr, q, true);
            var last = BinarySearch(arr, q, false);
            return first == -1 ? 0 : last - first + 1;
        }

        private int BinarySearch(int[] arr, int q, bool firstOccurrence)
        {
            int l = 0;
            int r = arr.Length;
            int res = -1;
            while(l < r)
            {
                int m = l + (r - l) / 2;
                if (arr[m] == q)
                {
                    res = m;
                    if(firstOccurrence)
                        r = m;
                    else
                        l = m + 1;
                }
                else if (arr[m] > q)
                    r = m;
                else
                    l = m + 1;
            }
            return res;
        }
    }
}
