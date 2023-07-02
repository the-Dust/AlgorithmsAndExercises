using System;
using Utils;

namespace DivideConquer
{
    [ShouldRepeat]
    public class NumberOfInversions
    {
        public void SelfTest()
        {
            int[] arr = { 2, 3, 9, 2, 9 };
            int[] arr2 = { 3, 2, 5, 9, 4 };
            var c1 = Count(arr); // 2
            var c2 = Count(arr2); // 0
        }

        public int Count(int[] arr)
        {
            return Count(arr, 0, arr.Length);
        }

        private int Count(int[] arr, int l, int r)
        {
            if (r - l <= 1)
                return 0;
            int m = l + (r - l) / 2;
            var leftInv = Count(arr, l, m);
            var rightInv = Count(arr, m, r);
            var mergeInv = Merge(arr, l, m, r);
            return leftInv + rightInv + mergeInv;
        }

        private int Merge(int[] arr, int l, int m, int r)
        {
            var temp = new int[r - l];
            var a = l;
            var b = m;
            var count = 0;

            for (int i = 0; i < r - l; i++)
            {
                if (a < m && (b == r || arr[a] <= arr[b]))
                {
                    temp[i] = arr[a];
                    a++;
                }
                else
                {
                    temp[i] = arr[b];
                    b++;
                    count += (m - a);
                }
            }
            Array.Copy(temp, 0, arr, l, r - l);
            return count;
        }
    }
}
