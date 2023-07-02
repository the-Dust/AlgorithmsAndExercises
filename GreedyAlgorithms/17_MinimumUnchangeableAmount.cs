using Utils;

namespace GreedyAlgorithms
{
    [ShouldRepeat]
    public class MinimumUnchangeableAmount
    {
        public void SelfTest()
        {

        }

        public int Calculate(int[] coins)
        {

            #region solution
            if (coins.Length == 0) 
                return 1;

            var set = new HashSet<int>();

            foreach (var coin in coins)
            {
                var current = set.ToArray();
                set.Add(coin);
                foreach(var cur in current)
                    set.Add(cur + coin);
            }
            var arr = set.OrderBy(x => x).ToArray();
            var m = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] - m > 1)
                    return m + 1;
                m = arr[i];
            }
            return m + 1;
            #endregion
        }
    }
}
