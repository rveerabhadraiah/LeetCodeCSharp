namespace LeetCodeCSharp.Easy.HashMap.L349;


/**
 * 
 * Given two integer arrays nums1 and nums2, return an array of their intersection.
 * Each element in the result must be unique & you may return the result in any order.
 *
 * Input: nums1 = [1,2,2,1], nums2 = [2,2]
 * Output: [2]
 * Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
 * Output: [9,4]
 * Explanation: [4,9] is also accepted.
 *
 */

// https://leetcode.com/problems/intersection-of-two-arrays/
// #HashTable #L349

public class IntersectionOfTwoArray
{
  private static int[] Solution(int[] nums1, int[] nums2)
  {
    HashSet<int> num1Set = new(nums1);
    HashSet<int> num2Set = new(nums2);

    List<int> result = new();
    foreach (var num1 in num2Set)
    {
      if (num1Set.Contains(num1))
      {
        result.Add(num1);
      }
    }
    
    return result.ToArray();
  }
  
  [Test]
  public void Test1()
  {
    var solution = Solution([1,2,2,1], [2,2]);
    int[] expected = [2];
    Assert.That(solution, Is.EquivalentTo(expected));
  }
  
  [Test]
  public void Test2()
  {
    var solution = Solution([4,9,5], [9,4,9,8,4]);
    int[] expected = [9,4];
    Assert.That(solution, Is.EquivalentTo(expected));
  }
}