using System.Text.RegularExpressions;

namespace LeetCodeCSharp.Easy.ArraysAndStrings.L125;

/**
 * A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all
 * non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.
 *
 * Given a string s, return true if it is a palindrome, or false otherwise.
 * Example 1:
 * Input: s = "A man, a plan, a canal: Panama"
 * Output: true
 * Explanation: "amanaplanacanalpanama" is a palindrome.
 *
 * Example 2:
 * Input: s = "race a car"
 * Output: false
 * Explanation: "raceacar" is not a palindrome.
 *
 * Example 3:
 * Input: s = " "
 * Output: true
 * Explanation: s is an empty string "" after removing non-alphanumeric characters.
 * Since an empty string reads the same forward and backward, it is a palindrome.
 */
// https://leetcode.com/problems/valid-palindrome/
// #L125 #TwoPointers
public class ValidPalindrome
{
  private static bool IsPalindrome(string s)
  {
    // also we can use char.IsLetter() || char.IsDigit() to avoid regex
    var strAlphabets = Regex.Replace(s, @"[^a-zA-Z0-9]", "").ToLower();
    var left = 0;
    var right = strAlphabets.Length - 1;
    
    while (left <= right)
    {
      if (strAlphabets[left] != strAlphabets[right])
        return false;
      
      left++;
      right--;
    }

    return true;
  }

  [Test]
  public void Test1()
  {
    var isPalindrome = IsPalindrome("A man, a plan, a canal: Panama");
    Assert.IsTrue(isPalindrome);
  }
  
  [Test]
  public void Test2()
  {
    var isPalindrome = IsPalindrome("race a car");
    Assert.IsFalse(isPalindrome);
  }
  
  [Test]
  public void Test3()
  {
    var isPalindrome = IsPalindrome(" ");
    Assert.IsTrue(isPalindrome);
  }
  
  [Test]
  public void Test4()
  {
    var isPalindrome = IsPalindrome("0P");
    Assert.False(isPalindrome);
  }
}