namespace LeetCodeCSharp.Medium.ArrayAndStrings.L45;

/**
 * You are given a 0-indexed array of integers nums of length n. You are initially positioned at nums[0].
 * Each element nums[i] represents the maximum length of a forward jump from index i.
 * In other words, if you are at nums[i], you can jump to any nums[i + j] where:
 *
 * Return the minimum number of jumps to reach nums[n - 1]. The test cases are generated such that you can reach nums[n - 1].
 *
 * Example 1:
 * Input: nums = [2,3,1,1,4
 * Output:
 * Explanation: The minimum number of jumps to reach the last index is 2. Jump 1 step from index 0 to 1, then 3 steps to the last index.
 *
 * Example 2:
 * Input: nums = [2,3,0,1,4]
 * Output: 2
 * 
 */
// https://leetcode.com/problems/jump-game-ii/
// L45 #Greedy
public class JumpGame2
{
  private static int Jump(int[] nums) {
    if (nums.Length == 1) return 0; // If only one element, no jumps needed

    var jumps = 0; // To count the number of jumps
    var farthest = 0; // To track the furthest we can go in the next jump
    var currentEnd = 0; // To track the furthest we can go in the current jump

    for (var i = 0; i < nums.Length - 1; i++) // We don't need to jump from the last index
    { 
      farthest = Math.Max(farthest, i + nums[i]); // Find the farthest we can jump from here

      // If we have reached the end of the current jump range
      if (i == currentEnd)
      {
        jumps++;                   // Increment jumps
        currentEnd = farthest;     // Move to the farthest position we can reach

        // If currentEnd reaches or exceeds the last index, we are done
        if (currentEnd >= nums.Length - 1)
          break;
      }

    }
    
    return jumps;
  }

  [Test]
  public void Test()
  {
    var result = Jump([2,3,1,1,4]);
    Assert.That(result, Is.EqualTo(2));
  }

  /*
  Explanation with Example
  Consider nums = [2,3,1,1,4]:
  1. i = 0: farthest = max(0, 0 + 2) = 2
  2. i = 1: farthest = max(2, 1 + 3) = 4
  3. End Reached at i = 0 → Jump → end = 2
  4. i = 2: farthest = max(4, 2 + 1) = 4
  5. End Reached at i = 1 → Jump → end = 4
  We reached the last index → Answer is 2 jumps.
  */
}