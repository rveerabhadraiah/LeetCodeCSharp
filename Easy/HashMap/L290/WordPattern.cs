namespace LeetCodeCSharp.Easy.HashMap.L290;

/**
 * Given a pattern and a string s, find if s follows the same pattern.
 * Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in s. Specifically:
 *
 * - Each letter in pattern maps to exactly one unique word in s.
 * - Each unique word in s maps to exactly one letter in pattern.
 * - No two letters map to the same word, and no two words map to the same letter.
 *
 * Example 1:
 * Input: pattern = "abba", s = "dog cat cat dog"
 * Output: true
 * Explanation:
 * The bijection can be established as:
 * a' maps to "dog".
 * 'b' maps to "cat".
 *
 * Example 2:
 * Input: pattern = "abba", s = "dog cat cat fish"
 * Output: false
 *
 * Example 3:
 * Input: pattern = "aaaa", s = "dog cat cat dog"
 * Output: false
 */
// https://leetcode.com/problems/word-pattern
// L290 #HashMap
public class WordPattern
{
  private static bool WordPattern_Sol(string pattern, string s)
  {
    var words = s.Split(" ");
    if (words.Length != pattern.Length) return false;
    
    var patToWordMap = new Dictionary<char, string>();
    var wordToPatMap = new Dictionary<string, char>();

    for (var i = 0; i < pattern.Length; i++)
    {
      string word = words[i];
      char pat = pattern[i];

      if (patToWordMap.ContainsKey(pat) && patToWordMap[pat] != word) return false;
      if (wordToPatMap.ContainsKey(word) && wordToPatMap[word] != pat) return false;
      
      patToWordMap[pat] = word;
      wordToPatMap[word] = pat;
    }
    
    return true;
  }

  [Test]
  public void Test1()
  {
    var wordPatternSol = WordPattern_Sol("abba", "dog cat cat dog");
    Assert.IsTrue(wordPatternSol);
  }
  
  [Test]
  public void Test2()
  {
    var wordPatternSol = WordPattern_Sol("abba", "dog cat cat fish");
    Assert.IsFalse(wordPatternSol);
  }
  
  [Test]
  public void Test3()
  {
    var wordPatternSol = WordPattern_Sol("aaaa", "dog cat cat dog");
    Assert.IsFalse(wordPatternSol);
  }
}