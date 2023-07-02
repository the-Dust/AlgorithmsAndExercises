using Utils;

namespace GreedyAlgorithms
{
    [ShouldRepeat]
    public class CarFueling
    {
        public void SelfTest()
        {
            var res1 = Calculate(950, 400, new[] { 200, 375, 550, 750 }); // 2
            var res2 = Calculate(10, 3, new[] { 1, 2, 5, 9 }); // -1
            var res3 = Calculate(200, 250, new[] { 100, 150 }); // 0
        }

        public int Calculate(int d, int v, int[] stops)
        {
            var s = stops.ToList();
            s.Prepend(0); // add start point
            s.Add(d); // add finish point
            int count = 0;
            int nextStop = v;
            int lastFill = 0;
            for (int i = 1; i < s.Count; i++)
            {
                if (s[i] > nextStop)
                {
                    if (s[i - 1] == lastFill)
                    {
                        return -1;
                    }
                    lastFill = s[i - 1];
                    nextStop = lastFill + v;
                    count++;
                    i--;
                }
            }
            return count;
        }
    }
}
