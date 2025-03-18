namespace LeetCodeCSharp.Easy.HashMap.L136;


/**
 * Given a non-empty array of integers nums, `every element appears twice` except for one.
 * Find that single one.
 *
 * You must implement a solution with a linear runtime complexity and use only constant extra space.
 *
 * Input: nums = [2,2,1]
 * Output: 1
 *
 * Input: nums = [4,1,2,1,2]
 * Output: 4
 * <p>
 * Input: nums = [1]
 * Output: 1
 *
 */
// https://leetcode.com/problems/single-number/
// #Dictionary #L136
public class SingleNumber
{
  private static int Solution(int[] nums)
  {
    Dictionary<int, int> dic = new();
    foreach (var num in nums)
    {
      if (dic.TryAdd(num, 1)) continue;
      var count = dic[num];
      dic[num] = count + 1;
      
      // if (dic.ContainsKey(num))
      // {
      //   var count = dic[num];
      //   dic[num] = count + 1;
      //   continue;
      // }
      
      // dic[num] = 1;
    }

    return dic.FirstOrDefault(d => d.Value == 1).Key;
  }

  [Test]
  public void Test1()
  {
    var solution = Solution([1, 1, 4, 2, 2]);
    Assert.That(solution, Is.EqualTo(4));
  }
}