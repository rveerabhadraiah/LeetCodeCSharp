namespace LeetCodeCSharp.Medium.ArrayAndStrings.L80;

/**
 *
 * Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.
 * 
 * Example 1:
 * Input: nums = [1,1,1,2,2,3]
 * Output: 5, nums = [1,1,2,2,3,_]
 * Explanation: Your function should return k = 5, with the first five elements of nums being 1, 1, 2, 2 and 3 respectively.
 * It does not matter what you leave beyond the returned k (hence they are underscores).
 *
 * Example 2:
 * Input: nums = [0,0,1,1,1,1,2,3,3]
 * Output: 7, nums = [0,0,1,1,2,3,3,_,_]
 * Explanation: Your function should return k = 7, with the first seven elements of nums being 0, 0, 1, 1, 2, 3 and 3 respectively.
 * It does not matter what you leave beyond the returned k (hence they are underscores).
 */
// https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/
// https://www.youtube.com/watch?v=ycAq8iqh0TI
// #TwoPointers #L80
public class RemoveDuplicatesSortedArray2
{
  private static int RemoveDuplicates(int[] nums)
  {
    var left = 0;
    var right = 0;

    while (right < nums.Length)
    {
      var count = 1;
      while (right + 1 < nums.Length && nums[right] == nums[right + 1])
      {
        right++;
        count++;
      }
      for (var i = 0; i < Math.Min(2,count); i++)
      {
       nums[left] = nums[right];
       left++;
      }
      
      right++;
    }

    return left;
  }
    
  [Test]
  public void Test1()
  {
    var result = RemoveDuplicates([0,0,1,1,1,1,2,3,3]);
    Assert.That(result, Is.EqualTo(7));
  }
}