using System;
using Utils;

namespace DivideConquer
{
    [ShouldRepeat]
    public class SpeedingUpRandomizedQuickSort
    {
        public void SelfTest()
        {
            var arr1 = new long[] { 2, 3, 9, 2, 9 };
            var arr2 = new long[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            QuickSort(arr1);
            QuickSort(arr2);
        }

        public void QuickSort(long[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1, new Random());
        }

        private void QuickSort(long[] arr, int l, int r, Random rnd)
        {
            if (r - l < 1)
                return;
            var pivot = rnd.Next(l, r + 1);
            var medians = Partition(arr, pivot, l, r);
            QuickSort(arr, l, medians[0] - 1, rnd);
            QuickSort(arr, medians[1] + 1, r, rnd);
        }

        private int[] Partition(long[] arr, int p, int l, int r)
        {
            int s = l;
            int e = r - 1;
            var pivot = arr[p];
            Swap(ref arr[p], ref arr[r]);
            for (int i = l; i <= e; i++)
            {
                if (arr[i] < pivot)
                {
                    Swap(ref arr[i], ref arr[s]);
                    s++;
                }
                else if (arr[i] == pivot)
                {
                    Swap(ref arr[i], ref arr[e]);
                    e--;
                    i--;
                }
            }
            if (e < s)
            {
                return new[] { s, r };
            }
            var d = r - e;
            for (int i = e; i >= s; i--)
            {
                arr[i + d] = arr[i];
                arr[i] = pivot;
            }
            e = s + d - 1;
            return new int[] { s, e };
        }

        private void Swap(ref long a, ref long b)
        {
            var temp = a;
            a = b;
            b = temp;
        }
    }
}
