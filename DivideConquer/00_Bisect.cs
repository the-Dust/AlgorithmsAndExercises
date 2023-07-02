using System;
using Utils;

namespace DivideConquer
{
    [ShouldRepeat]
    public class Bisect
    {
        public void SelfTest()
        {
            var arr = new int[] { 1, 2, 3, 4, 4, 4, 5, 6 };

            var lres1 = BinaryLeft(arr, -1);// 0
            var lres2 = BinaryLeft(arr, 1); // 0
            var lres3 = BinaryLeft(arr, 2); // 1
            var lres4 = BinaryLeft(arr, 4); // 3
            var lres5 = BinaryLeft(arr, 6); // 7
            var lres6 = BinaryLeft(arr, 8); // 8
            // 
            var rres1 = BinaryRight(arr, -1); // 0
            var rres2 = BinaryRight(arr, 1);  // 1
            var rres3 = BinaryRight(arr, 2);  // 2
            var rres4 = BinaryRight(arr, 4);  // 6
            var rres5 = BinaryRight(arr, 6);  // 8
            var rres6 = BinaryRight(arr, 8);  // 8
        }

        public int BinaryLeft(int[] arr, int p) => BinarySearch(arr, p, (a, b) => a >= b);

        public int BinaryRight(int[] arr, int p) => BinarySearch(arr, p, (a, b) => a > b);

        private int BinarySearch(int[] arr, int p, Func<int, int, bool> func)
        {
            var l = 0;
            var r = arr.Length;
            while (r - l > 1)
            {
                var m = l + (r - l) / 2;
                if (func(arr[m], p))
                    r = m;
                else
                    l = m;
            }
            return func(arr[l], p) ? l : r;
        }
    }
}
