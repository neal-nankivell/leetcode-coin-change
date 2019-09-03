using Answer;
using NUnit.Framework;

namespace Tests
{
    public class SolutionTests
    {
        [TestCase(
            new[] { 1, 2, 5 },
            11,
            ExpectedResult = 3
        )]
        [TestCase(
            new[] { 2 },
            3,
            ExpectedResult = -1
        )]
        [TestCase(
            new[] { 2, 3, 4 },
            5,
            ExpectedResult = 2
        )]
        [TestCase(
            new[] { 1 },
            0,
            ExpectedResult = 0
        )]
        [TestCase(
            new[] { 1, 2147483647 },
            2,
            ExpectedResult = 2
        )]
        [TestCase(
            new[] { 186, 419, 83, 408 },
            6249,
            ExpectedResult = 20
        )]
        [TestCase(
            new[] { 1, 6, 10 },
            12,
            ExpectedResult = 2
        )]
        [TestCase(
            new[] { 1 },
            1,
            ExpectedResult = 1
        )]
        public int CoinChange(int[] coins, int amount)
        {
            var sut = new Solution();
            return sut.CoinChange(coins, amount);
        }
    }
}