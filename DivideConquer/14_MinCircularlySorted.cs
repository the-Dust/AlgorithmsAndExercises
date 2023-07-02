using Utils;

namespace DivideConquer
{
    [ShouldRepeat]
    public class MinCircularlySorted
    {
        public void SelfTest()
        {
            int[] arr1 = { 4, 6, 7, 9, 3 };
            int[] arr2 = { 7, 9, 3, 4, 6 };
            int[] arr3 = { 3, 4, 6, 7, 9 };
            int[] arr4 = { 3, 4, 6, 7, 9, 10 };
            int[] arr5 = { 10, 3, 4, 6, 7, 9 };
            int[] arr6 = { 10, 3, 4, 6, 7, 9, 10 };

            var a1 = Calculate(arr1); // 4
            var a2 = Calculate(arr2); // 2
            var a3 = Calculate(arr3); // 0
            var a4 = Calculate(arr4); // 0
            var a5 = Calculate(arr5); // 1
            var a6 = Calculate(arr6); // 1
        }

        public int Calculate(int[] arr)
        {
            return Calculate(arr, 0, arr.Length);
        }

        private int Calculate(int[] arr, int l, int r)
        {
            while (l < r)
            {
                int m = l + (r - l) / 2;
                if (arr[m] >= arr[l])
                    l = m + 1;
                else
                    r = m;
            }
            return r == arr.Length ? 0 : r;
        }

        //private int Calculate(int[] arr, int l, int r)
        //{
        //    if (r - l == 1)
        //    {
        //        return InPlace(arr, l) ? int.MaxValue : arr[l];
        //    }

        //    int m = l + (r - l) / 2;
        //    int lm = Calculate(arr, l, m);
        //    int rm = Calculate(arr, m, r);
        //    return Math.Min(lm, rm);
        //}

        //private bool InPlace(int[] arr, int i)
        //{
        //    (int l, int r) = Neighbours(i, arr.Length);
        //    return arr[l] <= arr[i] && arr[i] <= arr[r];
        //}

        //private (int l, int r) Neighbours(int pivot, int length)
        //{
        //    int l = (length + (pivot - 1)) % length;
        //    int r = (pivot + 1) % length;
        //    return (l, r);
        //}
    }
}
