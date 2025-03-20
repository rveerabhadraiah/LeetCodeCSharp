namespace LeetCodeCSharp.Medium.ArrayAndStrings.L55;

/**
 * You are given an integer array nums. You are initially positioned at the array's first index,
 * and each element in the array represents your maximum jump length at that position.
 * Return true if you can reach the last index, or false otherwise.
 *
 * Example 1:
 * Input: nums = [2,3,1,1,4]
 * Output: true
 * Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.
 *
 * Example 2:
 * Input: nums = [3,2,1,0,4]
 * Output: false
 * Explanation: You will always arrive at index 3 no matter what. Its maximum jump length is 0, which makes it impossible to reach the last index.
 */
// https://leetcode.com/problems/jump-game/description
// #L55 #Greedy
// https://www.youtube.com/watch?v=Yan0cv2cLy8
public class JumpGame
{
  private static bool CanJump(int[] nums)
  {
    var lastPos = nums.Length - 1;
    //We start from the second last element (nums.Length - 2)
    //because we want to check if we can reach the last position from any of the previous positions.
    for (var i = nums.Length-2; i >=0; i--)
    {
      // i + nums[i] represents the farthest index you can reach from the current index i.
      if (i + nums[i] >= lastPos)
      {
        lastPos = i;
      }
    }
  
    return lastPos == 0;
  }
  
  // traverse from forward
  // private static bool CanJump(int[] nums)
  // {
  //   int maxReach = 0;
  //   for (int i = 0; i < nums.Length; i++)
  //   {
  //     if (i > maxReach) return false;
  //     maxReach = Math.Max(maxReach, i + nums[i]);
  //   }
  //   return maxReach >= nums.Length - 1;
  // }

  [Test]
  public void Test1()
  {
    var result = CanJump([2, 3, 1, 1, 4]);
    Assert.That(result, Is.True);
  }
  
  [Test]
  public void Test2()
  {
    var result = CanJump([3, 2, 1, 0, 4]);
    Assert.That(result, Is.False);
  }
  
}