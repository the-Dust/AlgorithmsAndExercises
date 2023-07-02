using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace DivideConquer
{
    [ShouldRepeat]
    public class OrganizingALottery
    {
        public void SelfTest()
        {
            var segments1 = new[] { new[] { 2, 3 }, new[] { 0, 5 }, new[] { 7, 10 }, };
            var points1 = new[] { 1, 6, 11 };

            var segments2 = new[] { new[] { 1, 3 }, new[] { -10, 10 }, };
            var points2 = new[] { -100, 100, 0 };

            var segments3 = new[] { new[] { 3, 2 }, new[] { 0, 5 }, new[] { -3, 2 }, new[] { 7, 10 }, };
            var points3 = new[] { 1, 6 };

            var res1 = Calculate(segments1, points1); // 1 0 0
            var res2 = Calculate(segments2, points2); // 0 0 1
            var res3 = Calculate(segments3, points3); // 2 0
        }

        public int[] Calculate(int[][] segments, int[] points)
        {
            var starts = segments.Select(x => x[0]).OrderBy(x => x).ToArray();
            var ends = segments.Select(x => x[1]).OrderBy(x => x).ToArray();
            var wins = points.Select(p => FindSegments(p, starts, ends)).ToArray();
            return wins;
        }

        private int FindSegments(int p, int[] starts, int[] ends)
        {
            var count = starts.Length;
            count -= BinaryLeft(ends, p);
            count -= starts.Length - BinaryRight(starts, p);
            return count;
        }

        // Refer to DivideConquer.Bisect.cs

        private int BinaryLeft(int[] arr, int p) => BinarySearch(arr, p, (a, b) => a >= b);

        private int BinaryRight(int[] arr, int p) => BinarySearch(arr, p, (a, b) => a > b);

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
