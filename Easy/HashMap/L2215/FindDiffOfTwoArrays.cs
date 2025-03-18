using System.Collections.Immutable;

namespace LeetCodeCSharp.Easy.HashMap.L2215;

/**
 * Given two 0-indexed integer arrays nums1 and nums2, return a list answer of size 2 where:
 * answer[0] is a list of all distinct integers in nums1 which are not present in nums2.
 * answer[1] is a list of all distinct integers in nums2 which are not present in nums1.
 * Note that the integers in the lists may be returned in any order.
 *
 * Example 1:
 * Input: nums1 = [1,2,3], nums2 = [2,4,6]
 * Output: [[1,3],[4,6]]
 * Explanation:
 * For nums1, nums1[1] = 2 is present at index 0 of nums2, whereas nums1[0] = 1 and nums1[2] = 3 are not present in nums2. Therefore, answer[0] = [1,3].
 * For nums2, nums2[0] = 2 is present at index 1 of nums1, whereas nums2[1] = 4 and nums2[2] = 6 are not present in nums2. Therefore, answer[1] = [4,6].
 *
 * Example 2:
 * Input: nums1 = [1,2,3,3], nums2 = [1,1,2,2]
 * Output: [[3],[]]
 * Explanation:
 * For nums1, nums1[2] and nums1[3] are not present in nums2. Since nums1[2] == nums1[3], their value is only included once and answer[0] = [3].
 * Every integer in nums2 is present in nums1. Therefore, answer[1] = [].
 */
// https://leetcode.com/problems/find-the-difference-of-two-arrays/description/
// #HashTable #L2215
public class FindDiffOfTwoArrays
{
  private static IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
  {
    var nums1Set = new HashSet<int>(nums1);
    var nums2Set = new HashSet<int>(nums2);
    
    List<IList<int>> difference = [new List<int>(), new List<int>()];

    foreach (var num in nums1Set)
    {
      if (!nums2Set.Contains(num)) difference[0].Add(num);
    }

    foreach (var num in nums2Set)
    {
      if (!nums1Set.Contains(num)) difference[1].Add(num);
    }
    
    return difference;
  }

  [Test]
  public void Test1()
  {
    var findDifference = FindDifference([1,2,3], [2,4,6]);
    Assert.That(findDifference[0], Is.EquivalentTo(new List<int>() {1,3}));
    Assert.That(findDifference[1], Is.EquivalentTo(new List<int>() {4,6}));
  }
  
  [Test]
  public void Test2()
  {
    var findDifference = FindDifference([1,2,3,3], [1,1,2,2]);
    Assert.That(findDifference[0], Is.EquivalentTo(new List<int>() {1,3}));
    Assert.That(findDifference[1], Is.EquivalentTo(new List<int>() {4,6}));
  }
  
}