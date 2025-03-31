namespace LeetCodeCSharp.Easy.HashMap.L219;

/**
 * Given an integer array nums and an integer k, return true if there are two distinct indices i and j in the array
 * such that nums[i] == nums[j] and abs(i - j) <= k.
 *
 * Example 1:
 * Input: nums = [1,2,3,1], k = 3
 * Output: true
 * We have the value 1 at index 0 and also at index 3
 * The distance between these indices is |0 - 3| = 3
 * Since 3 ≤ 3, it satisfies our condition
 *
 * Example 2:
 * Input: nums = [1,0,1,1], k = 1
 * Output: true
 *We have the value 1 at indices 0, 2, and 3
 * Looking at positions 2 and 3, the value is 1 at both positions
 * The distance between these indices is |2 - 3| = 1
 * Since 1 ≤ 1, it satisfies our condition
 *
 * Example 3:
 * Input: nums = [1,2,3,1,2,3], k = 2
 * Output: false
 * In this example, we have:
 * The value 1 appears at indices 0 and 3
 * The distance between these indices is |0 - 3| = 3, which is greater than k = 2
 * The value 2 appears at indices 1 and 4
 * The distance between these indices is |1 - 4| = 3, which is greater than k = 2
 * The value 3 appears at indices 2 and 5
 * The distance between these indices is |2 - 5| = 3, which is greater than k = 2
 * Since all the duplicate values have a distance greater than k = 2 between them, the output is false.
 *
 */
// https://leetcode.com/problems/contains-duplicate-ii
// https://www.youtube.com/watch?v=ypn0aZ0nrL4
// L219 #HashMap #SlidingWindow
public class ContainsDuplicate2
{
  private static bool ContainsNearbyDuplicate(int[] nums, int k)
  {
    // Dictionary to store the last seen index of each number
    var lastIndex = new Dictionary<int, int>();

    // Loop through the array
    for (var i = 0; i < nums.Length; i++)
    {
      // If the number has appeared before
      if (lastIndex.ContainsKey(nums[i]))
      {
        // Check if the difference between the current index and the previous index is <= k
        if (i - lastIndex[nums[i]] <= k)
        {
          return true; // Found a pair that satisfies the condition
        }
      }

      // Update the last seen index of the current number
      lastIndex[nums[i]] = i;
    }

    // No such pair found, return false
    return false;
  }

  [Test]
  public void Test1()
  {
    var containsNearbyDuplicate = ContainsNearbyDuplicate([1, 2, 3, 1], 3);
    Assert.IsTrue(containsNearbyDuplicate);
  }

  [Test]
  public void Test2()
  {
    var containsNearbyDuplicate = ContainsNearbyDuplicate([1, 0, 1, 1], 1);
    Assert.IsTrue(containsNearbyDuplicate);
  }

  [Test]
  public void Test3()
  {
    var containsNearbyDuplicate = ContainsNearbyDuplicate([1, 2, 3, 1, 2, 3], 2);
    Assert.IsFalse(containsNearbyDuplicate);
  }
}