using AlgorithmicWarmUp;

namespace MainTests
{
    public class AlgorithmicWarmUp
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(3, 2)]
        [InlineData(10, 55)]
        public void FibonacciNumber_Test(long num, long expected)
        {
            var obj = new FibonacciNumber();

            var res = obj.Calculate(num);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(3, 2)]
        [InlineData(139, 1)]
        [InlineData(91239, 6)]
        public void LastDigitFibonacciNumber_Test(int n, int expected)
        {
            var obj = new LastDigitFibonacciNumber();

            var res = obj.Calculate(n);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(1, 239, 1)]
        [InlineData(115, 1000, 885)]
        [InlineData(2816213588, 239, 151)]
        public void HugeFibonacciNumber_Test(long n, int m, int expected)
        {
            var obj = new HugeFibonacciNumber();

            var res = obj.Calculate(n, m);
            var res2 = obj.Calculate2(n, m);

            Assert.Equal(expected, res);
            Assert.Equal(expected, res2);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(3, 4)]
        [InlineData(100, 5)]
        public void LastDigitSumFibonacciNumbers_Test(long n, int expected)
        {
            var obj = new LastDigitSumFibonacciNumbers();

            var res = obj.Calculate(n);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(3, 7, 1)]
        [InlineData(10, 10, 5)]
        [InlineData(1, 2, 2)]
        [InlineData(1, 3, 4)]
        public void LastDigitPartialSumFibonacciNumbers_Test(long m, long n, int expected)
        {
            var obj = new LastDigitPartialSumFibonacciNumbers();

            var res = obj.Calculate(m, n);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(7, 3)]
        [InlineData(73, 1)]
        [InlineData(1234567890, 0)]
        public void LastDigitSumSquaresFibonacciNumbers_Test(long n, int expected)
        {
            var obj = new LastDigitSumSquaresFibonacciNumbers();

            var res = obj.Calculate(n);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(18, 35, 1)]
        [InlineData(14159572, 63967072, 4)]
        [InlineData(28851538, 1183019, 17657)]
        public void GreatestCommonDivisor_Test(long a, long b, int expected)
        {
            var obj = new GreatestCommonDivisor();

            var res = obj.Calculate(a, b);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(18, 35, 630)]
        [InlineData(10, 10, 10)]
        [InlineData(761457, 614573, 467970912861)]
        public void LeastCommonMultiple_Test(long a, long b, long expected)
        {
            var obj = new LeastCommonMultiple();

            var res = obj.Calculate(a, b);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(13, 3, 12)]
        [InlineData(7, 5, 5)]
        [InlineData(2, 1, 1)]
        [InlineData(5, 2, 2)]
        [InlineData(41, 3, 30)]
        public void JosephusProblem_Test(int n, int k, int expected)
        {
            var obj = new JosephusProblem();

            var res = obj.Calculate(n, k);

            Assert.Equal(expected, res);
        }

        [Fact]
        public void RangeSumQueries_Test()
        {
            var arr = new[] { 2, -1, 7, 2, -3, -2, 4 };
            var ranges = new[] { (0, 0), (1, 3), (2, 5), (6, 6), (0, 6) };
            var expected = new[] { 2, 8, 4, 4, 9 };

            var obj = new RangeSumQueries();

            var res = obj.Calculate(arr, ranges);

            Assert.Equal(expected, res);
        }
    }
}
