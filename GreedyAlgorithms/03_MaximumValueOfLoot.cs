using Utils;

namespace GreedyAlgorithms
{
    [ShouldRepeat]
    public class MaximumValueOfLoot
    {
        public void SelfTest()
        {

        }

        public decimal Calculate(int capacity, int[][] costsWeights)
        {
            var arr = costsWeights.OrderByDescending(x => x, new Comparer()).ToArray();
            var cur = capacity;
            decimal value = 0;
            for (int i = 0; i < arr.Length && cur > 0; i++)
            {
                int w = arr[i][1] > cur ? cur : arr[i][1];
                decimal priceForUnit = arr[i][0] / (decimal)arr[i][1];
                value += priceForUnit * w;
                cur -= w;
            }
            return value;
        }

        class Comparer : IComparer<int[]>
        {
            public int Compare(int[] x, int[] y)
            {
                var a = x[0] * y[1];
                var b = y[0] * x[1];
                return a.CompareTo(b);
            }
        }
    }
}
