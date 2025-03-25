namespace LeetCodeCSharp.Easy.BinarySearch.L35;

/*
 * Given a sorted array of distinct integers and a target value, return the index if the target is found.
 * If not, return the index where it would be if it were inserted in order.
 * You must write an algorithm with O(log n) runtime complexity.
 *
 * Example 1:
 * Input: nums = [1,3,5,6], target = 5
 * Output: 2
 *
 * Example 2:
 * Input: nums = [1,3,5,6], target = 2
 * Output: 1
 *
 * Example 3:
 * Input: nums = [1,3,5,6], target = 7
 * Output: 4
 */
// https://leetcode.com/problems/search-insert-position
// #L35 #BinarySearch #TwoPointers
public class SearchInsertPosition
{
  private static int SearchInsert(int[] nums, int target)
  {
    // Initialize left and right pointers to the start and end of the array
    var left = 0;
    var right = nums.Length - 1;

    // Continue searching while left pointer doesn't cross right pointer
    while (left <= right)
    {
      // Calculate the middle index
      // The safe method always gives the correct midpoint while preventing potential overflow.
      // left = 2
      // right = 7
      // Unsafe: (right-left)/2  = (7-2)/2 = 5/2 = 2
      // Safe:   left + (right-left)/2 
      //  = 2 + (7-2)/2 
      //    = 2 + 5/2 
      //      = 2 + 2 
      //        = 4  ✓
      var mid = left + (right - left) / 2;

      // If target is found, return its index
      if (nums[mid] == target)
      {
        return mid;
      }

      // If target is greater than middle element, search right half
      if (target > nums[mid])
      {
        left = mid + 1;
      }
      // If target is less than middle element, search left half
      else
      {
        right = mid - 1;
      }
    }

    // If target not found, return the index where it should be inserted
    return left;
  }


  [Test]
  public void Test()
  {
    var position = SearchInsert([1,3,5,6], 5);
    Assert.That(position, Is.EqualTo(2));
  }
}