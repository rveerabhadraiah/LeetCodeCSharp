namespace LeetCodeCSharp.Easy.ArraysAndStrings.L282;

/**
 *
 * Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.
 * Note that you must do this in-place without making a copy of the array.
 *
 * Input: nums = [0,1,0,3,12]
 * Output: [1,3,12,0,0]
 *
 */

// https://leetcode.com/problems/move-zeroes/
// #L282 #TwoPointers
public class MoveZeroes
{
  private static int[] MoveZeroesSol(int[] nums)
  {
    var left = 0;
    var right = 0;

    while (right < nums.Length)
    {
      if (nums[right] != 0)
      {
        (nums[left], nums[right]) = (nums[right], nums[left]);
        left++;
      }
      right++;
    }
    
    return nums;
  }
  
  // public static void MoveZeroesSol2(int[] nums) 
  // {
  //   var left = 0;
  //   var right = 0;
  //
  //   while (right < nums.Length)
  //   {
  //     if (nums[left] == 0 && nums[right] == 0)
  //     {
  //       right++;
  //     }
  //     else
  //     {
  //       (nums[left], nums[right]) = (nums[right], nums[left]);
  //       left++;
  //       right++;
  //     }
  //   }
  // }

  [Test]
  public void Test1()
  {
    var result = MoveZeroesSol([0, 1, 0, 3, 12]);
    Assert.That(result, Is.EqualTo(new[] {1,3,12,0,0})); 
  }
  
  [Test]
  public void Test2()
  {
    var result = MoveZeroesSol([0]);
    Assert.That(result, Is.EqualTo(new[] {0})); 
  }
}