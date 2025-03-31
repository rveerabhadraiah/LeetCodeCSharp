namespace LeetCodeCSharp.Easy.HashMap.L1;
/*
Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
You may assume that each input would have exactly one solution, and you may not use the same element twice.
You can return the answer in any order.

Example 1:

Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

Example 2:

Input: nums = [3,2,4], target = 6
Output: [1,2]

Example 3:

Input: nums = [3,3], target = 6
Output: [0,1]
*/
// https://leetcode.com/problems/two-sum/description/
// https://github.com/MisterBooo/LeetCodeAnimation/blob/master/0001-Two-Sum/Animation/Animation.gif
// #HashMap #Array #L1
public class TwoSum
{
  private static int[] Solution(int[] nums, int target)
  {
    Dictionary<int, int> dic = new();

    for (var index = 0; index < nums.Length; index++)
    {
      var num = nums[index];
      var complement = target - num;
      
      if (dic.TryGetValue(complement, out var i))
        return [i, index];
      
      // if (dic.ContainsKey(complement))
      //   return [dic[complement], index];

      dic.Add(num, index);
    }
    return [];
  }

  [Test]
  public void Test1()
  {
    var solution = Solution([2, 7, 11, 15], 9);

    var expected = new[]{0,1};
    Assert.That(solution, Is.EquivalentTo(expected));
  }
}