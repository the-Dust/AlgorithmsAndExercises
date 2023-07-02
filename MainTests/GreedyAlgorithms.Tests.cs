using FluentAssertions;
using GreedyAlgorithms;
using static GreedyAlgorithms.PartyPlanningAtWork;

namespace MainTests
{
    public class GreedyAlgorithms
    {
        [Theory]
        [InlineData(2, 2)]
        [InlineData(28, 6)]
        [InlineData(8, 4)]
        public void GreedyMoneyChange_Test(int n, int expected)
        {
            var obj = new GreedyMoneyChange();

            var res = obj.Calculate(n);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(180.0, 50, new[] { 60, 20 }, new[] { 100, 50 }, new[] { 120, 30 })]
        [InlineData(166.6667, 10, new[] { 500, 30 })]
        public void MaximumValueOfLoot_Test(decimal expected, int capacity, params int[][] costsWeights)
        {
            var obj = new MaximumValueOfLoot();

            var res = obj.Calculate(capacity, costsWeights);

            Assert.Equal(expected, res, 4);
        }

        [Theory]
        [InlineData(950, 400, new[] { 200, 375, 550, 750 }, 2)]
        [InlineData(10, 3, new[] { 1, 2, 5, 9 }, -1)]
        [InlineData(200, 250, new[] { 100, 150 }, 0)]
        public void CarFueling_Test(int d, int v, int[] stops, int expected)
        {
            var obj = new CarFueling();

            var res = obj.Calculate(d, v, stops);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(new long[] { 1, 3, 5 }, new long[] { 2, 4, 1 }, 27)]
        [InlineData(new long[] { 1, 2, 3, 4, 5 }, new long[] { 1, 0, 1, 0, 1 }, 12)]
        public void MaximumAdvertisementRevenue_Test(long[] a, long[] b, int expected)
        {
            var obj = new MaximumAdvertisementRevenue();

            var res = obj.Calculate(a, b);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(new[] { 3 }, new[] { 1, 3 }, new[] { 2, 5 }, new[] { 3, 6 })]
        [InlineData(new[] { 3, 6 }, new[] { 1, 3 }, new[] { 2, 5 }, new[] { 5, 6 }, new[] { 4, 7 })]
        public void CollectingSignatures_Test(int[] expected, params int[][] arr)
        {
            var obj = new CollectingSignatures();

            var res = obj.Calculate(arr);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(6, new[] { 1, 2, 3 })]
        [InlineData(8, new[] { 1, 2, 5 })]
        [InlineData(2, new[] { 2 })]
        public void MaximumNumberPrizes_Test(int n, int[] expected)
        {
            var obj = new MaximumNumberPrizes();

            var res = obj.Calculate(n);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(new[] { 21, 2 }, 221)]
        [InlineData(new[] { 9, 4, 6, 1, 9 }, 99641)]
        [InlineData(new[] { 23, 39, 92 }, 923923)]
        public void MaximumSalary_Test(int[] digits, long expected)
        {
            var obj = new MaximumSalary();

            var res = obj.Calculate(digits);
            var res2 = obj.Calculate2(digits);

            Assert.Equal(expected, res);
            Assert.Equal(expected, res2);
        }

        [Fact]
        public void JobScheduling_Test()
        {
            var obj = new JobScheduling();
            var data = new[] { ("A", 50, 2), ("B", 20, 1), ("C", 30, 2), ("D", 25, 1), ("E", 15, 3), };
            var expectedSchedule = new[] { "C", "A", "E", null, null };
            var expectedProfit = 95;

            var res = obj.Calculate(data);

            Assert.Equal(expectedSchedule, res.schedule);
            Assert.Equal(expectedProfit, res.profit);
        }

        [Theory]
        [InlineData(new[] { 1, 3, 10 }, new[] { 5, 6, 8 }, /**/ new[] { 1, 5 }, new[] { 3, 6 }, new[] { 10, 8 })]
        [InlineData(new[] { 2, 4, 13 }, new[] { 6, 9, 11 }, /**/ new[] { 2, 6 }, new[] { 4, 9 }, new[] { 13, 11 })]
        public void MiceAndAFox_Test(int[] mices, int[] holes, params int[][] expected)
        {
            var obj = new MiceAndAFox();

            var res = obj.Calculate(mices, holes);

            Assert.Equal(expected, res);
        }

        [Fact]
        public void PartyPlanningAtWork_Test()
        {
            var a = new TreeNode("A");
            var b = new TreeNode("B");
            var c = new TreeNode("C");
            var d = new TreeNode("D", new[] { a, b, c });
            var e = new TreeNode("E");
            var f = new TreeNode("F");
            var g = new TreeNode("G");
            var h = new TreeNode("H", new[] { d, e });
            var i = new TreeNode("I", new[] { f });
            var j = new TreeNode("J", new[] { g });
            var k = new TreeNode("K", new[] { j, i, h });
            var expected = new[] { "A", "B", "C", "G", "F", "E", "K" };
            var obj = new PartyPlanningAtWork();

            var res = obj.Calculate(k);

            expected.Should().BeEquivalentTo(res);
        }

        [Theory]
        [InlineData(true, new[] { 3, 1 }, new[] { 2, 6 }, new[] { 1, 1 })]
        [InlineData(true, new[] { 7, 100 })]
        [InlineData(false, new[] { 2, 1 }, new[] { 7, 1 })]
        public void CookingADinner_Test(bool expected, params int[][] spans)
        {


            var obj = new CookingADinner();

            var res = obj.Calculate(spans);

            Assert.Equal(expected, res);
        }

        [Fact]
        public void GraphColoring_Test()
        {
            Assert.True(true);
        }

        [Theory]
        [InlineData(new[] { 10, 5, 21, 3 }, 65)]
        public void ConnectRopesWithMinimalCost_Test(int[] lengths, int expected)
        {
            var obj = new ConnectRopesWithMinimalCost();

            var res = obj.Calculate(lengths);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(new[] { false, true, true, true, false, true }, 4)]
        public void BulbSwitching_Test(bool[] bulbArr, int expected)
        {
            var obj = new BulbSwitching();

            var res = obj.Calculate(bulbArr);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(new[] { 2, 4, 8 }, 4)]
        [InlineData(new[] { 3, 6, 8, 12, 13 }, 10)]
        public void FriendsSeatTogether_Test(int[] positions, int expected)
        {
            var obj = new FriendsSeatTogether();

            var res = obj.Calculate(positions);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(new[] { 0 }, 1)]
        [InlineData(new[] { 1, 2, 4, 10 }, 8)]
        [InlineData(new[] { 1, 2, 3 }, 7)]
        public void MinimumUnchangeableAmount_Test(int[] coins, int expected)
        {
            var obj = new MinimumUnchangeableAmount();

            var res = obj.Calculate(coins);

            Assert.Equal(expected, res);
        }
    }
}
