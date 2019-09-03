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

            var filteredSortedCoins =
                coins.Where(coin => coin <= amount)
                .ToArray();
            Array.Sort(filteredSortedCoins);

            Stack<StackItem> stack = new Stack<StackItem>();
            foreach (var coin in filteredSortedCoins)
            {
                stack.Push(
                    new StackItem
                    {
                        Value = coin,
                        NumberOfCoins = 1
                    });
            }

            while (stack.Count > 0)
            {
                var maxItem = stack.Pop();
                if (maxItem.Value == amount)
                {
                    return maxItem.NumberOfCoins;
                }

                foreach (var coin in filteredSortedCoins)
                {
                    if (maxItem.Value + coin <= amount)
                    {
                        stack.Push(
                            new StackItem
                            {
                                Value = maxItem.Value + coin,
                                NumberOfCoins = maxItem.NumberOfCoins + 1,
                            });
                    }
                }
            }

            return -1;
        }

        private class StackItem
        {
            public int Value { get; set; }

            public int NumberOfCoins { get; set; }
        }
    }
}
