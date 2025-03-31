namespace LeetCodeCSharp.Easy.ArraysAndStrings.L26;

/**
 * Given an integer array nums `sorted in non-decreasing order`
 * remove the duplicates in-place such that each unique element appears only once.
 *
 * The relative order of the elements should be kept the same. Then `return the number of unique elements in nums`.
 * 
 * Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.
 * 
 * Example 1:
 * Input: nums = [1,1,2]
 * Output: 2, nums = [1,2,_]
 * Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
 * It does not matter what you leave beyond the returned k (hence they are underscores).
 *
 * Example 2:
 * Input: nums = [0,0,1,1,1,2,2,3,3,4]
 * Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
 * Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
 * It does not matter what you leave beyond the returned k (hence they are underscores).
 */
// https://leetcode.com/problems/remove-duplicates-from-sorted-array
// #Array #L26 #TwoPointers
// https://www.youtube.com/watch?v=DEJAZBq0FDA
public class RemoveDuplicatesSortedArray
{
  private  static int RemoveDuplicates(int[] nums)
  {
    // no shift is required for index 0
    var left = 1;
    var right = 1;

    while (right < nums.Length)
    {
      if (nums[right] != nums[right-1])
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
    var result = RemoveDuplicates([0,0,1,1,1,2,2,3,3,4]);
    Assert.That(result, Is.EqualTo(5));
  }
}