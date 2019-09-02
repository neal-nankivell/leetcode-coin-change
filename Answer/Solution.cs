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
            // O(log(N)) where N is the number of coins
            Array.Sort(coins);

            var remaining = amount;
            var count = 0;

            // Greedy solution, will fail on some edge cases
            for (int i = coins.Length - 1; i >= 0; i--)
            {
                while (remaining >= 0)
                {
                    remaining -= coins[i];
                    count++;
                }

                if (remaining < 0)
                {
                    remaining += coins[i];
                    count--;
                }

                if (remaining == 0)
                {
                    break;
                }
            }

            if (remaining != 0)
            {
                return -1;
            }

            return count;
        }
    }
}
