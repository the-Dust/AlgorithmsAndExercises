using DivideConquer;
using FluentAssertions;

namespace MainTests
{
    public class DivideConquer
    {
        private static readonly int[][] sorted2dArray = new int[][] {
                new[] { 02, 07, 15, 22, 40 },
                new[] { 03, 08, 19, 31, 42 },
                new[] { 09, 18, 32, 53, 54 },
                new[] { 11, 20, 33, 56, 60 },
                new[] { 14, 43, 44, 71, 74 },
        };

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 4, 4, 5, 6 }, -1, 0, 0)]
        [InlineData(new int[] { 1, 2, 3, 4, 4, 4, 5, 6 }, 1, 0, 1)]
        [InlineData(new int[] { 1, 2, 3, 4, 4, 4, 5, 6 }, 2, 1, 2)]
        [InlineData(new int[] { 1, 2, 3, 4, 4, 4, 5, 6 }, 4, 3, 6)]
        [InlineData(new int[] { 1, 2, 3, 4, 4, 4, 5, 6 }, 6, 7, 8)]
        [InlineData(new int[] { 1, 2, 3, 4, 4, 4, 5, 6 }, 8, 8, 8)]
        public void Bisect_Test(int[] arr, int num, int resultLeft, int resultRight)
        {
            var bisect = new Bisect();

            var lres = bisect.BinaryLeft(arr, num);
            var rres = bisect.BinaryRight(arr, num);

            Assert.Equal(lres, resultLeft);
            Assert.Equal(rres, resultRight);
        }

        [Theory]
        [InlineData(new int[] { 1, 5, 8, 12, 13 }, 8, 2)]
        [InlineData(new int[] { 1, 5, 8, 12, 13 }, 1, 0)]
        [InlineData(new int[] { 1, 5, 8, 12, 13 }, 23, -1)]
        [InlineData(new int[] { 1, 5, 8, 12, 13 }, 11, -1)]
        [InlineData(new int[] { 1, 5, 8, 12, 13 }, 5, 1)]
        [InlineData(new int[] { 1, 5, 8, 12, 13 }, 13, 4)]
        public void BinarySearch_Test(int[] arr, int num, int expected)
        {
            var obj = new BinarySearch();

            var res = obj.Calculate(arr, num);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(new int[] { 2, 4, 4, 4, 7, 7, 9 }, 9, 6)]
        [InlineData(new int[] { 2, 4, 4, 4, 7, 7, 9 }, 4, 1)]
        [InlineData(new int[] { 2, 4, 4, 4, 7, 7, 9 }, 5, -1)]
        [InlineData(new int[] { 2, 4, 4, 4, 7, 7, 9 }, 2, 0)]
        [InlineData(new int[] { 2, 4, 4, 4, 7, 7, 9 }, 1, -1)]
        [InlineData(new int[] { 2, 4, 4, 4, 7, 7, 9 }, 7, 4)]
        [InlineData(new int[] { 2, 4, 4, 4, 7, 7, 9 }, 13, -1)]
        public void BinarySearchWithDuplicates_Test(int[] arr, int num, int expected)
        {
            var obj = new BinarySearchWithDuplicates();

            var res = obj.Calculate(arr, num);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(new long[] { 2, 3, 9, 2, 2 }, true)]
        [InlineData(new long[] { 512766168, 717383758, 5, 126144732, 5, 573799007, 5, 5, 5, 405079772 }, false)]
        public void MajorityElement_Test(long[] arr, bool expected)
        {
            var obj = new MajorityElement();

            var res = obj.Calculate(arr);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(new long[] { 2, 3, 9, 2, 9 })]
        [InlineData(new long[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 })]
        [InlineData(new long[] { 7, 8, 6, 5, 1, 1, 1, 1, 1, 1, 1 })]
        [InlineData(new long[] { 7, 8, 6, 5, 1, 1, 1, 1, 1, 1 })]
        public void SpeedingUpRandomizedQuickSort_Test(long[] arr)
        {
            var obj = new SpeedingUpRandomizedQuickSort();

            obj.QuickSort(arr);

            arr.Should().BeInAscendingOrder();
        }

        [Theory]
        [InlineData(new[] { 2, 3, 9, 2, 9 }, 2)]
        [InlineData(new[] { 3, 2, 5, 9, 4 }, 3)]
        [InlineData(new[] { 1, 2, 3, 4 }, 0)]
        public void NumberOfInversions_Test(int[] arr, int expected)
        {
            var obj = new NumberOfInversions();

            var res = obj.Count(arr);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(new[] { 1, 6, 11 }, new[] { 1, 0, 0 }, /**/ new[] { 2, 3 }, new[] { 0, 5 }, new[] { 7, 10 })]
        [InlineData(new[] { -100, 100, 0 }, new[] { 0, 0, 1 }, /**/ new[] { 1, 3 }, new[] { -10, 10 })]
        [InlineData(new[] { 1, 6 }, new[] { 2, 0 }, /**/ new[] { 3, 2 }, new[] { 0, 5 }, new[] { -3, 2 }, new[] { 7, 10 })]
        public void OrganizingALottery_Test(int[] points, int[] expected, params int[][] segments)
        {
            var obj = new OrganizingALottery();

            var res = obj.Calculate(segments, points);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(5, new[] { 0, 0 }, new[] { 3, 4 })]
        [InlineData(
            1.414213,
            new[] { 4, 4 }, new[] { -2, -2 },
            new[] { -3, -4 }, new[] { -1, 3 },
            new[] { 2, 3 }, new[] { -4, 0 },
            new[] { 1, 1 }, new[] { -1, -1 },
            new[] { 3, -1 }, new[] { -4, 2 },
            new[] { -2, 4 }
        )]
        [InlineData(
            0,
            new[] { -4, 0 }, new[] { -4, -2 },
            new[] { -3, -4 }, new[] { -2, -2 },
            new[] { -2, 4 }, new[] { -1, -1 },
            new[] { -1, 3 }, new[] { 1, 1 },
            new[] { 2, 3 }, new[] { 3, -1 },
            new[] { 4, 4 }, new[] { 5, 5 },
            new[] { -1, -1 }
        )]
        [InlineData(0, new[] { 7, 7 }, new[] { 7, 7 })]
        public void ClosestPoints_Test(decimal expected, params int[][] arr)
        {
            var obj = new ClosestPoints();

            var res = obj.Calculate(arr);

            Assert.Equal(expected, res, 5);
        }


        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4 }, 0, 0)]
        [InlineData(new int[] { 1, 2, 3, 4 }, 2, 1)]
        [InlineData(new int[] { 1, 2, 2, 3, 4 }, 2, 2)]
        [InlineData(new int[] { 1, 2, 2, 2, 2 }, 2, 4)]
        [InlineData(new int[] { 2, 2, 2, 2 }, 2, 4)]
        [InlineData(new int[] { 2, 2, 2, 2, 3 }, 2, 4)]
        public void CountAnElementSortedArray_Test(int[] arr, int num, int expected)
        {
            var obj = new CountAnElementSortedArray();

            var res = obj.Calculate(arr, num);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, -1)]
        [InlineData(new int[] { 2, 3, 4, 5 }, -1)]
        [InlineData(new int[] { 0, 2, 3, 4, 5 }, 1)]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5, 7 }, 6)]
        [InlineData(new int[] { 0, 1, 2, 3, 5, 8, 9 }, 4)]
        [InlineData(new int[] { 0, 1, 2, 3, 7, 8, 9 }, 4)]
        public void SmallestMissingElement_Test(int[] arr, int expected)
        {
            var obj = new SmallestMissingElement();

            var res = obj.Calculate(arr);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3, 4 }, new[] { 9, 10 }, 3.5)]
        [InlineData(new[] { 1, 2, 3, 4 }, new[] { 0, 10 }, 2.5)]
        [InlineData(new[] { 1, 2, 2, 2, 2, 10 }, new[] { 3, 3, 3, 3, 3, 3 }, 3)]
        [InlineData(new[] { 1, 2, 2, 2, 2, 10 }, new[] { 3, 3, 3, 3, 3 }, 3)]
        [InlineData(new[] { 1 }, new[] { 2 }, 1.5)]
        [InlineData(new[] { 1, 3, 5, 7 }, new[] { 15 }, 5)]
        [InlineData(new[] { 1, 2, 3, 4 }, new[] { 5, 6, 7, 8 }, 4.5)]
        [InlineData(new[] { 1, 2, 3, 4 }, new[] { 5, 6, 7 }, 4)]
        [InlineData(new[] { 1, 3, 5, 7 }, new[] { 2, 4, 6, 8 }, 4.5)]
        [InlineData(new[] { 1, 3, 5, 7 }, new[] { 2, 4, 6 }, 4)]
        [InlineData(new[] { 0, 0 }, new[] { 0, 0 }, 0)]
        public void MedianTwoSortedArrays_Test(int[] a, int[] b, double expected)
        {
            var obj = new MedianTwoSortedArrays();

            var res = obj.Calculate(a, b);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(99, 98)]
        [InlineData(389_473, 389_472)]
        [InlineData(101, -1)]
        public void UnboundedBinarySearch_Test(int num, int expected)
        {
            int[] arr = Enumerable.Range(1, 1_000_000).ToArray();
            arr[100] = 100;
            var obj = new UnboundedBinarySearch();

            var res = obj.Calculate(arr, num);

            Assert.Equal(res, expected);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6 }, false)]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, false)]
        [InlineData(new[] { 6, 4, 7, 1, 89, 43, 16, 4 }, true)]
        [InlineData(new[] { 6, 4, 7, 1, 89, 43, 16 }, false)]
        [InlineData(new[] { 6, 4, 4, 7, 1, 89, 43, 16 }, true)]
        [InlineData(new[] { 6, 4, 7, 1, 89, 43, 16, 4, 10 }, true)]
        [InlineData(new[] { 6, 4, 7, 1, 89, 43, 16, 10 }, false)]
        [InlineData(new[] { 6, 4, 4, 7, 1, 89, 43, 16, 10 }, true)]
        [InlineData(new[] { 4, 4 }, true)]
        [InlineData(new[] { 1, 4, 4 }, true)]
        [InlineData(new[] { 4, 4, 1 }, true)]
        [InlineData(new[] { 4, 5, 4 }, true)]
        [InlineData(new[] { 4, 5, 3, 4 }, true)]
        [InlineData(new[] { 4, 5, 4, 3 }, true)]
        public void DuplicateSearch_Test(int[] arr, bool expected)
        {
            var obj = new DuplicateSearch();

            var res = obj.Calculate(arr);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(new[] { 4, 6, 7, 9, 3 }, 4)]
        [InlineData(new[] { 7, 9, 3, 4, 6 }, 2)]
        [InlineData(new[] { 3, 4, 6, 7, 9 }, 0)]
        [InlineData(new[] { 3, 4, 6, 7, 9, 10 }, 0)]
        [InlineData(new[] { 10, 3, 4, 6, 7, 9 }, 1)]
        [InlineData(new[] { 10, 3, 4, 6, 7, 9, 10 }, 1)]
        public void MinCircularlySorted_Test(int[] arr, int expected)
        {
            var obj = new MinCircularlySorted();

            var res = obj.Calculate(arr);

            Assert.Equal(expected, res);
        }

        [Fact]
        public void AnagramSearch_Test()
        {
            var obj = new AnagramSearch();

            var res = true;

            Assert.True(res);
        }

        [Theory]
        [InlineData(new[] { 9, 1, -3, 7, -2, -4, 8, 5, 4, -6, 6, -5, -10 }, new[] { -3, -2, -4, -6, -5, -10, 9, 1, 7, 8, 5, 4, 6 })]
        public void SegregateNegative_Test(int[] arr, int[] expected)
        {
            var obj = new SegregateNegative();

            obj.Calculate(arr);

            Assert.Equal(expected, arr);
        }

        [Theory]
        [InlineData(new int[] { -100, -7, 3, -2, 0, 7, -5, 4, 1, 2, -9, -8, 2, 3, 1 }, 10)]
        [InlineData(new int[] { -12, -14, 2, -4, -61, 39 }, 39)]
        public void MaxSumInterval_Test(int[] arr, int expected)
        {
            var obj = new MaxSumInterval();

            var res = obj.Calculate(arr);

            Assert.Equal(expected, res);
        }


        [Theory]
        [InlineData(33, 3, 2)]
        [InlineData(41, -1, -1)]
        [InlineData(100, -1, -1)]
        [InlineData(0, -1, -1)]
        [InlineData(74, 4, 4)]
        [InlineData(2, 0, 0)]
        public void SearchingASortedMatrix_Test(int num, int expectedX, int expectedY)
        {
            var obj = new SearchingASortedMatrix();

            var res = obj.Calculate(sorted2dArray, num);

            Assert.Equal((expectedX, expectedY), res);
        }
    }
}