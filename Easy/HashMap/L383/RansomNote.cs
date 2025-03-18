namespace LeetCodeCSharp.Easy.HashMap.L383;

/*
 * Given two strings ransomNote and magazine, return true if ransomNote can be constructed by using the letters
 * from magazine and false otherwise.
 *
 * Each letter in magazine can only be used once in ransomNote.
 *
 * Example 1:
 * Input: ransomNote = "a", magazine = "b"
 * Output: false
 * Example 2:
 * Input: ransomNote = "aa", magazine = "ab"
 * Output: false
 * Example 3:
 * Input: ransomNote = "aa", magazine = "aab"
 * Output: true
 */

// https://leetcode.com/problems/ransom-note/description
// #HashMap #L383
public class RansomNote
{
  private static bool CanConstruct(string ransomNote, string magazine)
  {
    var magMap = new Dictionary<char, int>();
    foreach (var c in magazine)
    {
      if (magMap.TryAdd(c, 1)) continue;

      var count = magMap[c];
      magMap[c] = count + 1;
    }

    var ransomMap = new Dictionary<char, int>();
    foreach (var c in ransomNote)
    {
      if (ransomMap.TryAdd(c, 1)) continue;

      var count = ransomMap[c];
      ransomMap[c] = count + 1;
    }
    
    foreach (var (key, value) in ransomMap)
    {
      if(!magMap.ContainsKey(key) || magMap[key] < value) return false;
    }

    return true;
  }

  [Test]
  public void Test1()
  {
    var canConstruct = CanConstruct("aa", "aab");
    Assert.IsTrue(canConstruct);
  }
  
  [Test]
  public void Test2()
  {
    var canConstruct = CanConstruct("a", "b");
    Assert.IsFalse(false);
  }
  
  [Test]
  public void Test3()
  {
    var canConstruct = CanConstruct("aa", "ab");
    Assert.False(canConstruct);
  }
}