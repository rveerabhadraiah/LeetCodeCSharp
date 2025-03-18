using System.Text;

namespace LeetCodeCSharp.Easy.ArraysAndStrings.L1768;

/*
Merge the Strings Alternately

You are given two strings `word1` and `word2`. Merge the strings by adding letters in alternating order,
starting with `word1`. If a string is longer than the other, append the additional letters onto
the end of the merged string.

Return *the merged string.*

Example 1:

Input: word1 = "abc", word2 = "pqr"
Output: "apbqcr"
Explanation: The merged string will be merged as so:
word1:  a   b   c
word2:    p   q   r
merged: a p b q c r
*/
// https://leetcode.com/problems/merge-strings-alternately
// #String #L1768 #TwoPointers

public class MergeStringsAlternately
{
  private static string MergeAlternately(string word1, string word2)
  {
    var p1 = 0;
    var p2 = 0;

    var mergedStr = new StringBuilder();
    while (p1 < word1.Length && p2 < word2.Length)
    {
      mergedStr.Append($"{word1[p1]}{word2[p2]}");
      p1++;
      p2++;
    }
    
    if (p1 < word1.Length)
      mergedStr.Append(word1[p1..]);
 
    if (p2 < word2.Length)
      mergedStr.Append(word2.Substring(p2));
    
    return mergedStr.ToString();
  }

  [Test]
  public void Test1()
  {
    var result = MergeAlternately("abc", "pqr");
    Assert.That(result, Is.EqualTo(@"apbqcr"));
  }
  
  [Test]
  public void Test2()
  {
    var result = MergeAlternately("abcd", "pq");
    Assert.That(result, Is.EqualTo(@"apbqcd"));
  }
}