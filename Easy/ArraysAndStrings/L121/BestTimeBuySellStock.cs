namespace LeetCodeCSharp.Easy.ArraysAndStrings.L121;

/**
 * Day:             1 2 3 4 5 6
 * Input: prices = [7,1,5,3,6,4]
 * Output: 5
 * Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
 * Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.
 *
 *
 * You are given an array prices where prices[i] is the price of a given stock on the ith day.
 *
 * You want to maximize your profit by choosing a single day to buy one stock and choosing a
 * different day in the future to sell that stock.
 *
 * Return the maximum profit you can achieve from this transaction.
 * If you cannot achieve any profit, return 0.
 *
 *
 */
// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
// #DynamicProgramming #L121

public class BestTimeBuySellStock
{
  private int Solution(int [] prices)
  {
    var buyValue = int.MaxValue;
    var maxProfit = 0;

    foreach (var price in prices)
    {
      if (price < buyValue)
      {
        buyValue = price;
      }
      else if (price - buyValue > maxProfit)
      {
        maxProfit = price - buyValue;
      }
    }
    return maxProfit;
  }
  
  [Test]
  public void Test1()
  {
    var solution = Solution([7,1,5,3,6,4]);
    Assert.That(solution, Is.EqualTo(5));
  }
}