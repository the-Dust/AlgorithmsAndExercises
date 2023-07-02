using Utils;

namespace DivideConquer
{
    [ShouldRepeat]
    public class SearchingASortedMatrix
    {
        public void SelfTest()
        {
            var arr = new int[][] {
                new[] { 02, 07, 15, 22, 40 },
                new[] { 03, 08, 19, 31, 42 },
                new[] { 09, 18, 32, 53, 54 },
                new[] { 11, 20, 33, 56, 60 },
                new[] { 14, 43, 44, 71, 74 },
            };

            var res1 = Calculate(arr, 33); // 3;2
            var res2 = Calculate(arr, 41); // -1;-1
            var res3 = Calculate(arr, 100); // -1;-1
            var res4 = Calculate(arr, 0); // -1;-1
            var res5 = Calculate(arr, 74); // 4;4
            var res6 = Calculate(arr, 2); // 0;0
        }

        public (int x, int y) Calculate(int[][] arr, int q)
        {
            int i = 0;
            int j = arr[0].Length - 1;
            while(i < arr.Length && j >= 0)
            {
                var k = arr[i][j];
                if (k == q)
                    return (i, j);
                else if (q > k)
                    i++;
                else
                    j--;
            }

            return (-1, -1);
        }
    }
}
