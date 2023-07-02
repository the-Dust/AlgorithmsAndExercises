using System;
using Utils;

namespace DivideConquer
{
    [ShouldRepeat]
    public class MedianTwoSortedArrays
    {
        public void SelfTest()
        {
            var (mtaArr1, mtaArr2) = (new[] { 1, 2, 3, 4 }, new[] { 9, 10 });
            var (mtaArr3, mtaArr4) = (new[] { 1, 2, 3, 4 }, new[] { 0, 10 });
            var (mtaArr5, mtaArr6) = (new[] { 1, 2, 2, 2, 2, 10 }, new[] { 3, 3, 3, 3, 3, 3 });
            var (mtaArr7, mtaArr8) = (new[] { 1, 2, 2, 2, 2, 10 }, new[] { 3, 3, 3, 3, 3 });
            var (mtaArr9, mtaArr10) = (new[] { 1 }, new[] { 2 });
            var (mtaArr11, mtaArr12) = (new[] { 1, 3, 5, 7 }, new[] { 15 });
            var (mtaArr13, mtaArr14) = (new[] { 1, 2, 3, 4 }, new[] { 5, 6, 7, 8 });
            var (mtaArr15, mtaArr16) = (new[] { 1, 2, 3, 4 }, new[] { 5, 6, 7 });
            var (mtaArr17, mtaArr18) = (new[] { 1, 3, 5, 7 }, new[] { 2, 4, 6, 8 });
            var (mtaArr19, mtaArr20) = (new[] { 1, 3, 5, 7 }, new[] { 2, 4, 6 });
            var (mtaArr21, mtaArr22) = (new[] { 0, 0 }, new[] { 0, 0 });
            var mtaRes1 = Calculate(mtaArr1, mtaArr2); // 3.5
            var mtaRes2 = Calculate(mtaArr3, mtaArr4); // 2.5
            var mtaRes3 = Calculate(mtaArr5, mtaArr6); // 3
            var mtaRes4 = Calculate(mtaArr7, mtaArr8); // 3
            var mtaRes5 = Calculate(mtaArr9, mtaArr10); // 1.5
            var mtaRes6 = Calculate(mtaArr11, mtaArr12); // 5
            var mtaRes7 = Calculate(mtaArr13, mtaArr14); // 4.5
            var mtaRes8 = Calculate(mtaArr15, mtaArr16); // 4
            var mtaRes9 = Calculate(mtaArr17, mtaArr18); // 4.5
            var mtaRes10 = Calculate(mtaArr19, mtaArr20); // 4
            var mtaRes11 = Calculate(mtaArr21, mtaArr22); // 0
        }

        public double Calculate(int[] a, int[] b)
        { 
           if (a.Length < b.Length)
                return Calculate(b, a);

            var n1 = a.Length * 2;
            var n2 = b.Length * 2;

            var l = 0;
            var r = n2;

            while (l <= r)
            {
                var m2 = (l + r) / 2;
                var m1 = (n2 + n1) / 2 - m2;

                var l1 = m1 == 0 ? int.MinValue : a[(m1 - 1) / 2];
                var l2 = m2 == 0 ? int.MinValue : b[(m2 - 1) / 2];
                var r1 = m1 == n1 ? int.MaxValue : a[m1 / 2];
                var r2 = m2 == n2 ? int.MaxValue : b[m2 / 2];

                if (l1 > r2)
                    l = m2 + 1;
                else if (l2 > r1)
                    r = m2 - 1;
                else
                    return (Math.Max(l1, l2) + Math.Min(r1, r2)) / 2d;
            }

            return -1;
        }
    }
}
