using System;
using Utils;

namespace DivideConquer
{
    [ShouldRepeat]
    public class DuplicateSearch
    {
        private Random rnd = new();

        public void SelfTest()
        {
            int[] arr1 = { 1, 2, 3, 4, 5, 6 };
            int[] arr2 = { 1, 2, 3, 4, 5 };
            int[] arr3 = { 6, 4, 7, 1, 89, 43, 16, 4 };
            int[] arr4 = { 6, 4, 7, 1, 89, 43, 16 };
            int[] arr5 = { 6, 4, 4, 7, 1, 89, 43, 16 };

            int[] arr6 = { 6, 4, 7, 1, 89, 43, 16, 4, 10 };
            int[] arr7 = { 6, 4, 7, 1, 89, 43, 16, 10 };
            int[] arr8 = { 6, 4, 4, 7, 1, 89, 43, 16, 10 };

            int[] arr9 = { 4, 4 };
            int[] arr10 = { 1, 4, 4 };
            int[] arr11 = { 4, 4, 1 };
            int[] arr12 = { 4, 5, 4 };
            int[] arr13 = { 4, 5, 3, 4 };
            int[] arr14 = { 4, 5, 4, 3 };

            var res1 = Calculate(arr1); // 0
            var res2 = Calculate(arr2); // 0
            var res3 = Calculate(arr3); // 1
            var res4 = Calculate(arr4); // 0
            var res5 = Calculate(arr5); // 1

            var res6 = Calculate(arr6); // 1
            var res7 = Calculate(arr7); // 0
            var res8 = Calculate(arr8); // 1

            var res9 = Calculate(arr9); // 1
            var res10 = Calculate(arr10); // 1
            var res11 = Calculate(arr11); // 1
            var res12 = Calculate(arr12); // 1
            var res13 = Calculate(arr13); // 1
            var res14 = Calculate(arr14); // 1

        }

        public bool Calculate(int[] arr)
        {
            return QuickSort(arr, 0, arr.Length);
        }

        private bool QuickSort(int[] arr, int l, int r)
        {
            if (r - l <= 1)
                return false;

            var q = rnd.Next(l, r);
            var j = Partition(arr, l, q, r, out var hasEqual);
            return hasEqual || QuickSort(arr, l, j) || QuickSort(arr, j+1, r);
        }

        private int Partition(int[] arr, int l, int q, int r, out bool hasEqual)
        {
            int j = l;
            var pivot = arr[q];
            Swap(ref arr[r - 1], ref arr[q]);
            hasEqual = false;
            for (int i = l; i < r - 1; i++)
            {
                if (arr[i] == pivot)
                {
                    hasEqual = true;
                    break;
                }
                else if (arr[i] < pivot)
                {
                    Swap(ref arr[i], ref arr[j]);
                    j++;
                }
            }
            Swap(ref arr[r - 1], ref arr[j]);
            return j;
        }

        private void Swap(ref int a, ref int b) => (a, b) = (b, a);
    }
}
