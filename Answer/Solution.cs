using System;
using System.Linq;
using System.Collections.Generic;

namespace Answer
{
    public class Solution
    {
        /*
        You are given coins of different denominations and a total
        amount of money amount. Write a function to compute the
        fewest number of coins that you need to make up that amount.
        If that amount of money cannot be made up by any combination
        of the coins, return -1.

        Note:
        You may assume that you have an infinite number of each
        kind of coin.
         */
        public int CoinChange(int[] coins, int amount)
        {
            if (amount == 0) { return 0; }
            if (coins.Length == 0) { return -1; }

            HashSet<int> coinsHash = new HashSet<int>(
                coins.Where(coin => coin <= amount)
            );

            if (coinsHash.Contains(amount)) { return 1; }

            int coinsUsed = 1;

            List<int> amountsAfterUsingXCoins = coinsHash
                .Select(coin => amount - coin)
                .Where(value => value >= 0)
                .ToList();

            HashSet<int> amountsAlreadySeen = new HashSet<int>();

            while (amountsAfterUsingXCoins.Count > 0)
            {
                List<int> nextAmounts = new List<int>();

                foreach (int candidate in amountsAfterUsingXCoins)
                {
                    if (!amountsAlreadySeen.Contains(candidate))
                    {
                        if (candidate == 0) { return coinsUsed; }
                        amountsAlreadySeen.Add(candidate);

                        nextAmounts.AddRange(
                            coinsHash
                                .Select(coin => candidate - coin)
                                .Where(v => v >= 0 && !amountsAlreadySeen.Contains(v))
                        );
                    }
                }

                coinsUsed++;
                amountsAfterUsingXCoins = nextAmounts;
            }

            return -1;
        }
    }
}
