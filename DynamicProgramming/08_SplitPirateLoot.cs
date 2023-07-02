using System.Linq;
using Utils;

namespace DynamicProgramming
{
    [ShouldRepeat]
    public class SplitPirateLoot
    {
        public void SelfTest()
        {
            var splRes1 = Split(new[] { 3, 3, 3, 3 }); // false
            var splRes2 = Split(new[] { 30 }); // false
            var splRes3 = Split(new[] { 1, 2, 3, 4, 5, 5, 7, 7, 8, 10, 12, 19, 25 }); // true
        }

        public bool Split(int[] arr)
        {
            var sum = arr.Sum();
            if (sum % 3 != 0)
            {
                return false;
            }

            int v = sum / 3;
            var table = new bool[arr.Length + 1, v + 1, v + 1];
            table[0, 0, 0] = true;

            for (int n = 1; n <= arr.Length; n++)
            {
                for (int i = 0; i <= v; i++)
                {
                    for (int j = 0; j <= v; j++)
                    {
                        table[n, i, j] = table[n - 1, i, j];
                        int vCur = arr[n-1];
                        if (vCur <= i)
                        {
                            table[n, i, j] = table[n, i, j] || table[n - 1, i - vCur, j];
                        }
                        if (vCur <= j)
                        {
                            table[n, i, j] = table[n, i, j] || table[n - 1, i, j - vCur];
                        }
                    }
                }
            }

            return table[arr.Length, v, v];
        }
    }
}
