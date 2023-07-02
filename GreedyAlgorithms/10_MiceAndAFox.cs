using Utils;

namespace GreedyAlgorithms
{
    [ShouldRepeat]
    public class MiceAndAFox
    {
        public void SelfTest()
        {
            var res1 = Calculate(new[] { 1, 3, 10 }, new[] { 5, 6, 8 }); // 1-5 3-6 10-8
            var res2 = Calculate(new[] { 2, 4, 13 }, new[] { 6, 9, 11 }); // 2-6 4-9 13-11
        }

        public int[][] Calculate(int[] mices, int[] holes)
        {
            Array.Sort(mices);
            Array.Sort(holes);
            var result = new int[mices.Length][];
            for (int i = 0; i < mices.Length; i++)
            {
                result[i] = new[] { mices[i], holes[i] };
            }
            return result;
        }
    }
}
