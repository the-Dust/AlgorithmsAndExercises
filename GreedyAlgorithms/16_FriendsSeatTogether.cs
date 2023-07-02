using Utils;

namespace GreedyAlgorithms
{
    [ShouldRepeat]
    public class FriendsSeatTogether
    {
        public void SelfTest()
        {

        }

        public int Calculate(int[] positions)
        {
            return Calculate(positions, positions.Length, 0, positions.Length - 1);
        }

        private int Calculate(int[] positions, int count, int l, int r)
        {
            if (count < 2)
                return 0;
            var leftToRightMoves = positions[r] - positions[l] - (count - 1);

            return leftToRightMoves + Calculate(positions, count - 2, l + 1, r - 1);
        }
    }
}
