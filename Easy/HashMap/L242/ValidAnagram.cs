namespace LeetCodeCSharp.Easy.HashMap.L242;
/**
 * Given two strings s and t, return true if t is an anagram of s, and false otherwise.
 * Example 1:
 * Input: s = "anagram", t = "nagaram"
 * Output: true
 *
 * Example 2:
 * Input: s = "rat", t = "car"
 * Output: false
 */
// https://leetcode.com/problems/valid-anagram
// L242 #HashMap

public class ValidAnagram
{
  private static bool IsAnagram(string s, string t)
  {
    if (s.Length != t.Length)
      return false;
    
    var sMap = new Dictionary<char, int>();
    var tMap = new Dictionary<char, int>();

    foreach (var ch in s)
    {
      if (sMap.TryAdd(ch, 1)) continue;
      
      var count = sMap[ch];
      sMap[ch] = count + 1;
    }
    
    foreach (var ch in t)
    {
      if (tMap.TryAdd(ch, 1)) continue;
      
      var count = tMap[ch];
      tMap[ch] = count + 1;
    }

    foreach (var (key, value) in sMap)
    {
      if (!tMap.ContainsKey(key) || tMap[key] != value) return false;
    }

    return true; // sMap.All(x => tMap.ContainsKey(x.Key) && tMap[x.Key] == x.Value);
  }

  [Test]
  public void Test1()
  {
    var isAnagram = IsAnagram("anagram", "nagaram");
    Assert.IsTrue(isAnagram);
  }
  
  [Test]
  public void Test2()
  {
    var isAnagram = IsAnagram("rat", "car");
    Assert.IsFalse(isAnagram);
  }
  
  [Test]
  public void Test3()
  {
    var isAnagram = IsAnagram("aacc", "ccac");
    Assert.IsFalse(isAnagram);
  }
}