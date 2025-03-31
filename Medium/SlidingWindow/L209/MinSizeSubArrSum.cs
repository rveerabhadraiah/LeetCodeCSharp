namespace LeetCodeCSharp.Medium.SlidingWindow.L209;

/**
 * Given an array of positive integers nums and a positive integer target, return the minimal length of a subarray
 * whose sum is greater than or equal to target. If there is no such subarray, return 0 instead.
 *
 * Example 1:
 * Input: target = 7, nums = [2,3,1,2,4,3]
 * Output: 2
 * Explanation: The subarray [4,3] has the minimal length under the problem constraint.
 */
// https://leetcode.com/problems/minimum-size-subarray-sum
// #L209 #SlidingWindow
public class MinSizeSubArrSum
{
  private static int MinSubArrayLen(int target, int[] nums)
  {
    var n = nums.Length;
    var left = 0;
    var sum = 0;
    var minLength = int.MaxValue;
        
    for (var right = 0; right < n; right++) {
      // Add the current element to the sum
      sum += nums[right];
            
      // While our sum is greater than or equal to the target
      // try to minimize the window by moving the left pointer
      while (sum >= target) {
        minLength = Math.Min(minLength, right - left + 1);
        sum -= nums[left];
        left++;
      }
    }
        
    // Return 0 if no valid subarray is found
    return minLength == int.MaxValue ? 0 : minLength;
  }

  [Test]
  public void Test()
  {
    var result = MinSubArrayLen(7, [2,3,1,2,4,3]);
    Assert.That(result, Is.EqualTo(2));
  }
  
  [Test]
  public void Test2()
  {
    var result = MinSubArrayLen(4, [1,4,4]);
    Assert.That(result, Is.EqualTo(1));
  }
}