using Utils;

namespace GreedyAlgorithms
{
    [ShouldRepeat]
    public class CookingADinner
    {
        public void SelfTest()
        {
            var res1 = Calculate(new[] { new[] { 3, 1 }, new[] { 2, 6 }, new[] { 1, 1 } }); // true
            var res2 = Calculate(new[] { new[] { 7, 100 } }); // true
            var res3 = Calculate(new[] { new[] { 2, 1 }, new[] { 7, 1 } }); // false
        }

        public bool Calculate(int[][] spans)
        {
            spans = spans.OrderByDescending(x => x[0] + x[1]).ToArray();
            var acc = spans[0][1];
            for (int i = 1; i < spans.Length; i++)
            {
                var itemCooking = spans[i][0];
                var itemStayFresh = spans[i][1];
                acc = Math.Min(acc - itemCooking, itemStayFresh);
            }
            return acc >= 0;
        }
    }
}
