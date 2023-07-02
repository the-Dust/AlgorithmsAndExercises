using System;
using System.Linq;
using Utils;

namespace DivideConquer
{
    [ShouldRepeat]
    public class MaxSumInterval
    {
        public void SelfTest()
        {
            int[] arr1 = { -100, -7, 3, -2, 0, 7, -5, 4, 1, 2, -9, -8, 2, 3, 1 };
            int res = Calculate(arr1);
        }

        public int Calculate(int[] arr)
        {
            return Calculate(arr, 0, arr.Length);
        }

        private int Calculate(int[] arr, int l, int r)
        {
            if (r - l <= 1)
                return arr[l];

            int m = l + (r - l)/2;
            int left = Calculate(arr, l, m);
            int right = Calculate(arr, m, r);
            int cross = Merge(arr, l, m, r);
            return Math.Max(left, Math.Max(cross, right));
        }

        private int Merge(int[] arr, int l, int m, int r)
        {
            int[] prefix = new int[m-l];
            int[] suffix = new int[r-m];
            Array.Copy(arr, l, prefix, 0, m-l);
            Array.Copy(arr, m, suffix, 0, r - m);
            for (int i = prefix.Length - 1; i > 0; i--)
            {
                prefix[i-1] += prefix[i];
            }
            for (int i = 0; i < suffix.Length-1; i++)
            {
                suffix[i+1] += suffix[i];
            }

            return prefix.Max() + suffix.Max();
        }
    }
}
