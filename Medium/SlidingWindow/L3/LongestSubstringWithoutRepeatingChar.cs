namespace LeetCodeCSharp.Medium.SlidingWindow.L3;


/*
Given a string s, find the length of the longest
substring without duplicate characters.

Example 1:

Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.

Example 2:

Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.

Example 3:

Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a
subsequence and not a substring.
*/

// https://leetcode.com/problems/longest-substring-without-repeating-characters/description/
// #HashSet #SlidingWindow #L3
public class LongestSubstringWithoutRepeatingChar
{
  private static int Solution(string str)
  {
    var left = 0;
    var right = 0;
    var winSize = 0;

    HashSet<char> hashSet = new();
    while (right < str.Length)
    {
      var ch = str[right];
      if (hashSet.Add(ch)) //if (!hashSet.Contains(ch))
      {
        right++;
        winSize = Math.Max(winSize, hashSet.Count);
      }
      else
      {
        hashSet.Remove(str[left]);
        left++;
      }
    }
    return winSize;
  }

  [Test]
  public void Test1()
  {
    var solution = Solution("pwwkew");
    Assert.That(solution, Is.EqualTo(3));
  }
  
  [Test]
  public void Test2()
  {
    var solution = Solution("abcabcbb");
    Assert.That(solution, Is.EqualTo(3));
  }
  
  [Test]
  public void Test3()
  {
    var solution = Solution("bbbbb");
    Assert.That(solution, Is.EqualTo(1));
  }
}