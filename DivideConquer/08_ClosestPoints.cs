using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace DivideConquer
{
    [ShouldRepeat]
    public class ClosestPoints
    {
        public void SelfTest()
        {
            var arr1 = new int[][] { new[] { 0, 0 }, new[] { 3, 4 } };
            var arr2 = new int[][]
            {
                new[] { 4, 4 }, new[] { -2, -2 },
                new[] { -3, -4 }, new[] { -1, 3 },
                new[] { 2, 3 }, new[] { -4, 0 },
                new[] { 1, 1 }, new[] { -1, -1 },
                new[] { 3, -1 }, new[] { -4, 2 },
                new[] { -2, 4 },
            };

            var arr3 = new int[][]
            {
                new[] { -4, 0 },
                new[] { -4, -2 },
                new[] { -3, -4 },
                new[] { -2, -2 },
                new[] { -2, 4 },

                new[] { -1, -1 },
                new[] { -1, 3 },
                new[] { 1, 1 },
                new[] { 2, 3 },
                new[] { 3, -1 },
                new[] { 4, 4 },
                new[] { 5, 5 },

                new[] { -1, -1 },
            };


            var ans1 = Calculate(arr1);
            var ans2 = Calculate(arr2);
            var ans3 = Calculate(arr3);

            var ans11 = Calculate2(arr1);
            var ans22 = Calculate2(arr2);
            var ans33 = Calculate2(arr3);
        }

        public decimal Calculate(int[][] arr)
        {
            return Calculate(arr.OrderBy(x => x[0]).ToArray(), 0, arr.Length);
        }

        private decimal Calculate(int[][] arr, int l, int r)
        {
            var count = r - l;
            if (count < 2)
            {
                return int.MaxValue;
            }

            int m = l + (r - l) / 2;
            int pivot = arr[m][0];
            var h1 = Calculate(arr, l, m);
            var h2 = Calculate(arr, m, r);
            var h = Math.Min(h1, h2);
            long delta = (long)Math.Ceiling(h);
            var hm = Merge(arr, l, m, r, delta, pivot);
            return Math.Min(h, hm);
        }

        private decimal Merge(int[][] arr, int l, int m, int r, long delta, int pivot)
        {
            var list = new List<int[]>();
            var temp = new int[r - l][];
            var a = l;
            var b = m;
            var leftBound = pivot - delta;
            var rightBound = pivot + delta;

            for (int i = 0; i < temp.Length; i++)
            {
                if (b == r || a < m && arr[a][1] < arr[b][1])
                {
                    temp[i] = arr[a];
                    a++;
                }
                else
                {
                    temp[i] = arr[b];
                    b++;
                }

                AddToList(list, temp[i], leftBound, rightBound);
            }
            Array.Copy(temp, 0, arr, l, temp.Length);
            var ans = MinDist(list, delta);
            return ans;
        }

        private void AddToList(List<int[]> list, int[] point, long l, long r)
        {
            if (point[0] >= l && point[0] <= r)
                list.Add(point);
        }

        private decimal MinDist(List<int[]> list, long delta)
        {
            var ans = decimal.MaxValue;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j][1] - list[i][1] > delta)
                        break;
                    var d = Distance(list[i], list[j]);
                    if (d < ans)
                    {
                        ans = d;
                    }
                }
            }

            return ans;
        }

        private decimal Distance(int[] a, int[] b)
        {
            return (decimal)Math.Sqrt(Math.Pow(a[0] - b[0], 2) + Math.Pow(a[1] - b[1], 2));
        }

        public decimal Calculate2(int[][] arr)
        {
            var res = Calculate2(arr.OrderBy(x => x[0]).ToArray(), 0, arr.Length);
            return (decimal)Math.Sqrt(res);
        }

        private long Calculate2(int[][] arr, int l, int r)
        {
            int[][] temp = new int[arr.Length][];

            Func<int[][], int, int, long> func = null;
            func = (int[][] arr, int l, int r) =>
            {
                if (r - l < 4)
                {
                    var min = MinDist(arr, l, r);
                    Array.Sort(arr, l, r - l, new PointComparer());
                    return min;
                    
                }

                var m = l + (r - l) / 2;
                var pivot = arr[m];
                var h1 = func(arr, l, m);
                var h2 = func(arr, m, r);
                var h = Math.Min(h1, h2);
                var hm = Merge2(arr, temp, pivot, l, m, r, (long)Math.Ceiling(Math.Sqrt(h)));

                return Math.Min(h, hm);
            };
            return func(arr, l, r);
        }

        private long Merge2(int[][] arr, int[][] temp, int[] pivot, int l, int m, int r, long h)
        {
            int a = l;
            int b = m;
            long leftBount = pivot[0] - h;
            long rightBount = pivot[0] + h;
            List<int[]> list = new();

            for (int k = l; k < r; k++)
            {
                if (a == m || b < r && arr[a][1] > arr[b][1])
                {
                    temp[k] = arr[b];
                    b++;
                }
                else
                {
                    temp[k] = arr[a];
                    a++;
                }
                var tx = temp[k][0];
                if (tx >= leftBount && tx <= rightBount)
                    list.Add(temp[k]);
            }
            Array.Copy(temp, l, arr, l, r - l);
            return MinDist(list.ToArray(), 0, list.Count, h);
        }

        private long Distance2(int[] a, int[] b) => (long)(Math.Pow(a[0] - b[0], 2) + Math.Pow(a[1] - b[1], 2));

        private long MinDist(int[][] arr, int l, int r, long h = long.MaxValue)
        {
            long min = long.MaxValue;
            for (int i = l; i < r; i++)
            {
                for (int j = i + 1; j < r; j++)
                {
                    if (Math.Abs(arr[i][1] - arr[j][1]) > h)
                        break;
                    var d = Distance2(arr[i], arr[j]);
                    min = d < min ? d : min;
                }
            }
            return min;
        }

        class PointComparer : IComparer<int[]>
        {
            public int Compare(int[] x, int[] y) => x[1].CompareTo(y[1]);
        }
    }
}
