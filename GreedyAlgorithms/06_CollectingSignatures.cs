using Utils;

namespace GreedyAlgorithms
{
    [ShouldRepeat]
    public class CollectingSignatures
    {
        public void SelfTest()
        {
            var res1 = Calculate(new[] { new[] { 1, 3 }, new[] { 2, 5 }, new[] { 3, 6 }, }); // 3
            var res2 = Calculate(new[] { new[] { 1, 3 }, new[] { 2, 5 }, new[] { 5, 6 }, new[] { 4, 7 }, }); // 3 6
        }

        public int[] Calculate(int[][] arr)
        {
            arr = arr.OrderBy(x => x[1]).ToArray(); // sort the segments by the ends
            var points = new List<int>();
            points.Add(arr[0][1]);
            for (int i = 1; i < arr.Length; i++)
            {
                var l = arr[i][0];
                if (l > points.Last())
                {
                    points.Add(arr[i][1]);
                }
            }
            return points.ToArray();
        }
    }
}
