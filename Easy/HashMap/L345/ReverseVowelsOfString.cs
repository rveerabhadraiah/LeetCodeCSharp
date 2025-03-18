using System.Text;

namespace LeetCodeCSharp.Easy.HashMap.L345;

/*
Reverse Vowels of a String

Given a string `s`, reverse only all the vowels in the string and return it.
The vowels are `'a'`, `'e'`, `'i'`, `'o'`, and `'u'`, and they can appear in both lower and upper cases, more than once.

Example 1:
Input: s = "IceCreAm"
Output: "AceCreIm"
Explanation:
The vowels in `s` are `['I', 'e', 'e', 'A']`. On reversing the vowels, s becomes `"AceCreIm"`.

Example 2:
Input: s = "leetcode"
Output: "leotcede"

Constraints:
- 1 <= s.length <= 335
- s consists of printable ASCII characters
*/
// https://leetcode.com/problems/reverse-vowels-of-a-string
// #TwoPointers #L345 #String #HashSet

public class ReverseVowelsOfString
{
  private static string ReverseVowels(string s)
  {
    var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
    var left = 0;
    var right = s.Length - 1;

    var result = new StringBuilder(s);
    while (left < right)
    {
      if (vowels.Contains(s[left]) && vowels.Contains(s[right]))
      {
        (result[left], result[right]) = (result[right], result[left]);
        left++;
        right--;
      }
      else
      {
        if (!vowels.Contains(s[left]))
          left++;

        if (!vowels.Contains(s[right])) 
          right--;
      }
    }
    return result.ToString();
  }

  [Test]
    public void Test1()
    {
      var result = ReverseVowels("IceCreAm");
      Assert.That(result, Is.EqualTo("AceCreIm"));
    }

    [Test]
    public void Test2()
    {
      var result = ReverseVowels("leetcode");
      Assert.That(result, Is.EqualTo("leotcede"));
    }
  }