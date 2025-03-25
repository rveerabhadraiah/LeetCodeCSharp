namespace LeetCodeCSharp.Easy.Math.L9;

/**
 * Given an integer x, return true if x is a palindrome, and false otherwise.
 *
 * Example 1:
 * Input: x = 121
 * Output: true
 *
 * Explanation: 121 reads as 121 from left to right and from right to left.
 */
// https://leetcode.com/problems/palindrome-number
// #L9 #Math
public class PalindromeNumber
{
  private static bool IsPalindrome(int x)
  {
    // Negative numbers are not palindromes
    if(x < 0) return false;
    
    // Store the original number for final comparison
    var actual = x;
    // Variable to build the reversed number
    var rev = 0;
    
    // Continue until all digits are processed
    while (x != 0)
    {
      // Extract the last digit (remainder when divided by 10)
      var rem = x % 10;
      // Remove the last digit from the original number
      x = x / 10;
      // Build the reversed number digit by digit
      rev = rev * 10 + rem;
    }
    
    // Check if the reversed number matches the original
    return actual == rev;
  }


  [Test]
  public void Test1()
  {
    var isPalindrome = IsPalindrome(121);
    Assert.IsTrue(isPalindrome);
  }
}