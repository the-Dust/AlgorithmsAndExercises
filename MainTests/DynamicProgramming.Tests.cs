using DynamicProgramming;
using FluentAssertions;

namespace MainTests
{
	public class DynamicProgramming
    {
		[Theory]
		[InlineData(34, 9)]
		[InlineData(26, 7)]
		[InlineData(15, 4)]
		public void MoneyChange_Test(int money, int expected)
		{
			var obj = new MoneyChange();

			var res = obj.GetChange(money);

			Assert.Equal(expected, res);
		}

		[Theory]
		[InlineData(1, new[] { 1 })]
		[InlineData(96234, 
			new[] { 1, 3, 9, 10, 11, 22, 66, 198, 594, 1782, 5346, 16038, 16039, 32078, 96234 },
			new[] { 1, 3, 9, 10, 11, 33, 99, 297, 891, 2673, 8019, 16038, 16039, 48117, 96234 })]
		public void PrimitiveCalculator_Test(int n, params int[][] expected)
		{
			var obj = new PrimitiveCalculator();

			var res = obj.Calculate(n);

			expected.Should().ContainEquivalentOf(res);
        }

		[Theory]
		[InlineData("short", "ports", 3)]
		[InlineData("editing", "distance", 5)]
		[InlineData("ab", "ab", 0)]
		public void EditDistance_Test(string a, string b, int expected)
		{
			var obj = new EditDistance();

			var res = obj.Get(a, b);

			Assert.Equal(expected, res);
		}

		[Theory]
		[InlineData(new[] { 2, 7, 5 }, new[] { 2, 5 }, 2)]
		[InlineData(new[] { 7 }, new[] { 1, 2, 3, 4 }, 0)]
		[InlineData(new[] { 2, 7, 8, 3 }, new[] { 5, 2, 8, 7 }, 2)]
		public void LongestCommonSubsecuence2_Test(int[] a, int[] b, int expected)
		{
			var obj = new LongestCommonSubsecuence2();

			var res = obj.Get(a, b);

			Assert.Equal(expected, res);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3 }, new[] { 2, 1, 3 }, new[] { 1, 3, 5 }, 2)]
		[InlineData(new[] { 8, 3, 2, 1, 7 }, new[] { 8, 2, 1, 3, 8, 10, 7 }, new[] { 6, 8, 3, 1, 4, 7 }, 3)]
		public void LongestCommonSubsecuence3_Test(int[] a, int[] b, int[] c, int expected)
		{
			var obj = new LongestCommonSubsecuence3();

			var res = obj.Get(a, b, c);

			Assert.Equal(expected, res);
		}

		[Theory]
		[InlineData(new[] { 1, 4, 8 }, 10, new[] { 1, 8 })]
		[InlineData(new[] { 1, 3, 4 }, 8, new[] { 1, 3, 4 })]
        [InlineData(new[] { 5, 7, 12, 18 }, 20, new[] { 7, 12 })]
        public void Knapsack_Test(int[] weights, int capacity, int[] expected)
		{
			var obj = new Knapsack();

			var res = obj.Calculate(weights, capacity);

			Assert.Equal(expected, res);
		}

		[Theory]
		[InlineData(new[] { 3, 3, 3, 3 }, false)]
		[InlineData(new[] { 30 }, false)]
		[InlineData(new[] { 1, 2, 3, 4, 5, 5, 7, 7, 8, 10, 12, 19, 25 }, true)]
		public void SplitPirateLoot_Test(int[] arr, bool expected)
		{
			var obj = new SplitPirateLoot();

			var res = obj.Split(arr);

			Assert.Equal(expected, res);
		}

		[Theory]
		[InlineData("5-8", -3)]
		[InlineData("3+2*4", 20)]
		[InlineData("5-8+7*4-8+9", 200)]
		public void MaximumValueArithmeticExpression_Test(string str, int expected)
		{
			var obj = new MaximumValueArithmeticExpression();

			var res = obj.Calculate(str);

			Assert.Equal(expected, res);
		}

		[Theory]
		[InlineData("bmanchdaem", "madam")]
		[InlineData("bmanchddaem", "maddam")]
		[InlineData("abc", "c")]
		[InlineData("abyuzsfqpmccbagggg", "abccba")]
		public void LongestPalindrome_Test(string str, string expected)
		{
			var obj = new LongestPalindrome();

			var res = obj.Calculate(str);

			Assert.Equal(expected, res);
		}

		[Theory]
		[InlineData("axtbadcdbcfb", new[] { "abc", "adc" })]
		[InlineData("abc", new[] { "" })]
		[InlineData("aab", new[] { "a" })]
		[InlineData("aabb", new[] { "ab" })]
		[InlineData("axxxy", new[] { "x" })]
		[InlineData("letsleetcode", new[] { "lete" })]
		public void LongestRepeatingSubsequence_Test(string str, string[] expected)
		{
			var obj = new LongestRepeatingSubsequence();

			var res = obj.Calculate(str);

			res.Should().BeOneOf(expected);
		}

		[Theory]
		[InlineData("ab", "cd", "abcd", true)]
		[InlineData("monkey", "tree", "mtonkreeye", true)]
		[InlineData("tree", "sort", "tsroerte", true)]
		[InlineData("ab", "cd", "abcdx", false)]
		[InlineData("ab", "cd", "adcb", false)]
		[InlineData("aabcc", "dbbca", "aadbbcbcac", true)]
		[InlineData("ab", "bc", "bbac", false)]
		public void InterleavingStrings_Test(string a, string b, string c, bool expected)
		{
			var obj = new InterleavingStrings();

			var res = obj.Calculate(a, b, c);

			Assert.Equal(expected, res);
		}

		[Theory]
		[InlineData(2, 3)]
		[InlineData(3, 4)]
		[InlineData(4, 11)]
		[InlineData(5, 15)]
		public void DominoTiling_Test(int n, int expected)
		{
			var obj = new DominoTiling();

			var res = obj.Calculate(n);

			Assert.Equal(expected, res);
		}

		[Theory]
		[InlineData(4, 157_140)]
		public void ColoringABoard_Test(int n, int expected)
		{
			var obj = new ColoringABoard();

			var res = obj.Calculate(n);

			Assert.Equal(expected, res);
		}

		[Theory]
		[InlineData(
			10,
			new[] { 3, 2, 3 },
			new[] { 8, 3, 1 },
			new[] { 5, 4, 2 },
			new[] { 9, 2, 8 })
		]
		public void ContrastHousePainting_Test(int expected, params int[][] table)
		{
			var obj = new ContrastHousePainting();

			var res = obj.Calculate(table);

			Assert.Equal(expected, res);
		}

		[Theory]
		[InlineData(0, 1)]
		[InlineData(1, 1)]
		[InlineData(2, 2)]
		[InlineData(3, 5)]
		[InlineData(4, 14)]
		[InlineData(5, 42)]
		[InlineData(6, 132)]
		[InlineData(7, 429)]
		[InlineData(8, 1430)]
		public void NonIntersectingChords_Test(int n, int expected)
		{
			var obj = new NonIntersectingChords();

			var res = obj.Calculate(n);

			Assert.Equal(expected, res);
		}

		[Fact]
		public void FunPartyPlanningAtWork_Test()
		{
			var obj = new FunPartyPlanningAtWork();
			var head1 = new Node
			{
				Weight = 3,
				Children = new[] {
					new Node { Weight = 5,
						Children = new[] { new Node { Weight = 2 } } },
					new Node { Weight = 1,
						Children = new[] { new Node { Weight = 3 } } },
					new Node { Weight = 6,
						Children = new[] {
							new Node { Weight = 2 },
							new Node { Weight = 7, Children = new[] {
								new Node { Weight = 1 },
								new Node { Weight = 2 },
								new Node { Weight = 1 },
							} },
						}
					}
				}
			};
			var expected1 = 18;

			var res1 = obj.Calculate(head1);

			Assert.Equal(expected1, res1);
		}

		[Theory]
		[InlineData(new[] { 2l, 1, 9, 3 }, 11)]
		[InlineData(new[] { 2l, 9, 1, 3 }, 12)]
        [InlineData(new[] { 3l, 4 }, 4)]
        public void CoinGame_Test(long[] coins, int expected)
		{
			var obj = new CoinGame();

			var res = obj.Money(coins);

			Assert.Equal(expected, res);
		}
	}
}
