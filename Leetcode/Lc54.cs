using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class Lc54
    {
        public void SelfTest()
        {
            int[][] arr1 = { new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 7, 8, 9 } };
            int[][] arr2 = { new[] { 1, 2, 3, 4 }, new[] { 5, 6, 7, 8 }, new[] { 9, 10, 11, 12 } };

            var res1 = SpiralOrder(arr1); // [1,2,3,6,9,8,7,4,5]
            var res2 = SpiralOrder(arr2); // [1,2,3,4,8,12,11,10,9,5,6,7]
        }

        public IList<int> SpiralOrder(int[][] matrix)
        {
            int m = matrix[0].Length;
            int n = matrix.Length;
            int count = m * n;
            List<int> list = new();

            var step = new Step(m, n);
            for (int i = 0; i < count; i++)
            {
                list.Add(matrix[step.J][step.I]);
                step.Go();
            }
            return list;
        }

        class Step
        {
            public int I { get; private set; } = 0;
            public int J { get; private set; } = 0;

            private int direction = 0;
            private int right;
            private int bottom;
            private int left = -1;
            private int top = -1;

            public Step(int r, int b)
            {
                right = r;
                bottom = b;
            }

            public void Go()
            {
                if (I + 1 == right && J + 1 == bottom && I - 1 == left && J - 1 == top)
                    return;
                switch (direction)
                {
                    case 0:
                        if (I + 1 == right)
                        {
                            top++;
                            Rotate();
                            Go();
                        }
                        else
                            I++;
                        break;
                    case 1:
                        if (J + 1 == bottom)
                        {
                            right--;
                            Rotate();
                            Go();
                        }
                        else
                            J++;
                        break;
                    case 2:
                        if (I -1 == left)
                        {
                            bottom--;
                            Rotate();
                            Go();
                        }
                        else
                            I--;
                        break;
                    case 3:
                        if (J - 1 == top)
                        {
                            left++;
                            Rotate();
                            Go();
                        }
                        else
                            J--;
                        break;
                }
            }

            private void Rotate() => direction = (direction + 1) % 4;
        }
    }
}
