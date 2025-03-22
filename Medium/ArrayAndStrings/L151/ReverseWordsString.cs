using System.Text.RegularExpressions;

namespace LeetCodeCSharp.Medium.ArrayAndStrings.L151;

/*
 * Given an input string s, reverse the order of the words.
 * A word is defined as a sequence of non-space characters. The words in s will be separated by at least one space.
 * Return a string of the words in reverse order concatenated by a single space.4
 * Note that s may contain leading or trailing spaces or multiple spaces between two words.
 * The returned string should only have a single space separating the words. Do not include any extra spaces.
 *
 * Example 1:
 * Input: s = "the sky is blue"
 * Output: "blue is sky the"
 */
// https://leetcode.com/problems/reverse-words-in-a-string/
// L151 #String
public class ReverseWordsString
{
  private string ReverseWords(string s)
  {
    // var str = Regex.Replace(s, @"\s+", " ").Trim();
    var strings = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    var left = 0;
    var right = strings.Length - 1;

    while (left < right)
    {
      (strings[left], strings[right]) = (strings[right], strings[left]);
      left++;
      right--;
    }
    
    return string.Join(" ", strings);;
  }

  [Test]
  public void Test1()
  {
    var result = ReverseWords(" the sky   is   blue  ");
    Assert.That(result, Is.EqualTo("blue is sky the"));
  }
  
  [Test]
  public void Test2()
  {
    var result = ReverseWords(" a good   example");
    Assert.That(result, Is.EqualTo("example good a"));
  }
  
}