namespace LeetCodeCSharp.Easy.HashMap.L350;

/**
 *
 * Given two integer arrays nums1 and nums2, return an array of their intersection.
 * Each element in the result must appear as many times as it shows
 * in both arrays and you may return the result in any order.
 *
 * Input: nums1 = [1,2,2,1], nums2 = [2,2]
 * Output: [2,2]
 *
 * Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
 * Output: [4,9]
 * Explanation: [9,4] is also accepted.
 * 
 */
// https://leetcode.com/problems/intersection-of-two-arrays-ii/
// #HashTable #L350

public class IntersectionOfTwoArray2
{
  private static int[] Intersect(int[] nums1, int[] nums2)
  {
    Dictionary<int, int> num1Map = new();
    Dictionary<int, int> num2Map = new();

    foreach (var num in nums1)
    {
      if (num1Map.TryAdd(num, 1)) continue;
      var count = num1Map[num];
      num1Map[num] = count + 1;
    }
    
    foreach (var num in nums2)
    {
      if (num2Map.TryAdd(num, 1)) continue;
      var count = num2Map[num];
      num2Map[num] = count + 1;
    }
    
    List<int> result = [];
    // foreach (var (k, num1Value) in num1Map)
    // if(num2Map.TryGetValue(k, out var num2Value))
    // {
    //   var minCount = Math.Min(num1Value, num2Value);
    foreach (var (key, value) in num1Map)
    {
      if(num2Map.ContainsKey(key))
      {
        var minCount = System.Math.Min(num1Map[key], num2Map[key]);
        while (minCount-- > 0)
        {
          result.Add(key);
        }
      }
    }
    return result.ToArray();
  }

  [Test]
  public void Test1()
  {
    var result = Intersect([4,9,5], [9,4,9,8,4]);
    Assert.That(result, Is.EqualTo(new[] {4,9}));
  }
  
  [Test]
  public void Test2()
  {
    var result = Intersect([1,2,2,1], [2,2]);
    Assert.That(result, Is.EqualTo(new[] {2,2}));
  }
}