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
            if (amount == 0)
            {
                return 0;
            }
            if (coins.Length == 0)
            {
                return -1;
            }

            HashSet<int> coinsHash = new HashSet<int>(
                coins.Where(coin => coin <= amount)
            );

            int steps = 1;

            HashSet<int> candidates = new HashSet<int>(
                coinsHash
                    .Select(coin => amount - coin)
                    .Where(value => value >= 0));

            HashSet<int> alreadySeen = new HashSet<int>();

            while (candidates.Count > 0)
            {
                HashSet<int> nextCandidates = new HashSet<int>();

                foreach (int candidate in candidates)
                {
                    if (candidate == 0)
                    {
                        return steps;
                    }
                    alreadySeen.Add(candidate);
                    foreach (var newCandidate in coinsHash
                            .Select(coin => candidate - coin)
                            .Where(v => v >= 0)
                            .Where(v => !alreadySeen.Contains(v))
                            .Where(v => !nextCandidates.Contains(v)))
                    {
                        nextCandidates.Add(newCandidate);
                    };
                }

                steps++;
                candidates = nextCandidates;
            }

            return -1;
        }
    }
}
