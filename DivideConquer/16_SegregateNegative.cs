using System;
using Utils;

namespace DivideConquer
{
    [ShouldRepeat]
    public class SegregateNegative
    {
        // https://www.geeksforgeeks.org/rearrange-positive-and-negative-numbers/

        public void SelfTest()
        {
            int[] arr = { 9, 1, -3, 7, -2, -4, 8, 5, 4, -6, 6, -5, -10 };

            Calculate(arr);
            Console.WriteLine(string.Join(" ", arr));
        }

        public void Calculate(int[] arr) => Calculate(arr, 0, arr.Length);

        private void Calculate(int[] arr, int l, int r)
        {
            if (r-l<=1)
                return;
            int m = l + (r - l) / 2;
            Calculate(arr, l, m);
            Calculate(arr, m, r);
            Merge(arr, l, m, r);
        }

        private void Merge(int[] arr, int l, int m, int r)
        {
            int a = l;
            int b = m;

            while (a < m && arr[a] < 0)
                a++;

            while (b < r && arr[b] < 0)
                b++;

            Reverse(arr, a, m-1);
            Reverse(arr, m, b-1);
            Reverse(arr, a, b - 1);
        }

        private void Reverse(int[] arr, int l, int r)
        {
            while (l < r)
            {
                (arr[r], arr[l]) = (arr[l], arr[r]);
                l++;
                r--;
            }
        }
    }
}
