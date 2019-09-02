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
        public int CoinChange(int[] coins, int amount)
        {
            var sut = new Solution();
            return sut.CoinChange(coins, amount);
        }
    }
}