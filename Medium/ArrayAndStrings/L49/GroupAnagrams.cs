namespace LeetCodeCSharp.Medium.ArrayAndStrings.L49;

/**
 * Given an array of strings strs, group the anagrams together. You can return the answer in any order.
 * Example 1:
 * Input: strs = ["eat","tea","tan","ate","nat","bat"]
 * Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
 *
 * Explanation:
 * - There is no string in strs that can be rearranged to form "bat".
 * - The strings "nat" and "tan" are anagrams as they can be rearranged to form each other.
 * - The strings "ate", "eat", and "tea" are anagrams as they can be rearranged to form each other.
 */
// https://leetcode.com/problems/group-anagrams
// #L49 #HashMap
public class GroupAnagrams
{
  private static IList<IList<string>> GroupAnagramsSol(string[] strings)
  {
    if (strings.Length == 0)
      return new List<IList<string>>();
    
    var groupAnagrams = new Dictionary<string, IList<string>>();
    foreach (var str in strings)
    {
      var charArray = str.ToCharArray();
      Array.Sort(charArray);
      var sortedAnagram = new string(charArray);
      
      if (groupAnagrams.ContainsKey(sortedAnagram))
      {
        groupAnagrams[sortedAnagram].Add(str);
      }
      else
      {
        groupAnagrams.Add(sortedAnagram, [str]);
      }
    }
    
    return groupAnagrams.Values.ToList();
  }
  
  [Test]
  public void Test()
  {
    var result = GroupAnagramsSol(["eat","tea","tan","ate","nat","bat"]);
    Assert.That(result.Count, Is.EqualTo(3));
  }
}