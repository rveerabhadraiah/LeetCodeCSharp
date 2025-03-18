namespace LeetCodeCSharp.Easy.HashMap.L205;
/**
 * Given two strings s and t, determine if they are isomorphic.
 * Two strings s and t are isomorphic if the characters in s can be replaced to get t.
 * All occurrences of a character must be replaced with another character while preserving the order of characters.
 * No two characters may map to the same character, but a character may map to itself.
 *
 * Example 1:
 * Input: s = "egg", t = "add"
 * Output: true
 * Explanation:
 * The strings s and t can be made identical by:
 * Mapping 'e' to 'a'.
 * Mapping 'g' to 'd'.
 *
 * Example 2:
 * Input: s = "foo", t = "bar"
 * Output: false
 * Explanation:
 * The strings s and t can not be made identical as 'o' needs to be mapped to both 'a' and 'r'.
 *
 * Example 3:
 * Input: s = "paper", t = "title"
 * Output: true
 */
// https://leetcode.com/problems/isomorphic-strings/description/
// #L205 #HashMap

public class IsomorphicStrings
{
  private static bool IsIsomorphic(string s, string t)
  {
    if (s.Length != t.Length)
      return false;
    
    var mapSt = new Dictionary<char, char>();
    var mapTs = new Dictionary<char, char>();
    
    for (var i = 0; i < s.Length; i++)
    {
      var sChar = s[i];
      var tChar = t[i];
      
      if(mapSt.ContainsKey(sChar) && mapSt[sChar] != tChar)
        return false;

      if (mapTs.ContainsKey(tChar) && mapTs[tChar] != sChar)
        return false;
      
      mapSt[sChar] = tChar;
      mapTs[tChar] = sChar;
    }
    
    return true;
  }

  [Test]
  public void Test1()
  {
    var isIsomorphic = IsIsomorphic("egg", "add");
    Assert.IsTrue(isIsomorphic);
  }
  
  [Test]
  public void Test2()
  {
    var isIsomorphic = IsIsomorphic("foo", "bar");
    Assert.IsFalse(isIsomorphic);
  }
  
  [Test]
  public void Test3()
  {
    var isIsomorphic = IsIsomorphic("paper", "title");
    Assert.IsTrue(isIsomorphic);
  }
}