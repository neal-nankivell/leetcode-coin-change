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
        public int CoinChange(int[] coins, int amount)
        {
            var sut = new Solution();
            return sut.CoinChange(coins, amount);
        }
    }
}