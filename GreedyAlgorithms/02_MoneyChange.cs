using Utils;

namespace GreedyAlgorithms
{
    [ShouldRepeat]
    public class GreedyMoneyChange
    {
        public void SelfTest()
        {
            var res1 = Calculate(2); // 2
            var res2 = Calculate(28); // 6
            var res3 = Calculate(8); // 4
        }

        public int Calculate(int amount)
        {
            int tens = amount / 10;
            int fifth = (amount % 10) / 5;
            int ones = amount - tens * 10 - fifth * 5;
            return tens + fifth + ones;
        }
    }
}
