namespace LeetCodeCSharp.Medium.HashMap.L128;
/*
 * Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.
 * You must write an algorithm that runs in O(n) time.
 * Example 1:4
 * Input: nums = [100,4,200,1,3,2]
 * Output: 4
 * Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.
 */
// https://leetcode.com/problems/longest-consecutive-sequence/description
// #L128 #HashMap
public class LongestConsecutiveSequence
{
  private static int LongestConsecutive(int[] nums)
  {
    // Handle empty input
    if (nums.Length == 0)
    {
      return 0;
    }

    // Convert the array to a HashSet for O(1) lookups
    var numSet = new HashSet<int>(nums);

    var maxLength = 0;

    // Iterate through each number in the HashSet
    foreach (var num in numSet)
    {
      // Only start counting sequences from the smallest number in the sequence
      // If num-1 exists, this num is not the start of a sequence
      if (!numSet.Contains(num - 1))
      {
        // This number is the start of a sequence
        var currentNum = num;
        var currentStreak = 1;

        // Count how long this sequence is
        while (numSet.Contains(currentNum + 1))
        {
          currentNum++;
          currentStreak++;
        }
        // Update the max length if this sequence is longer
        maxLength = Math.Max(maxLength, currentStreak);
      }
    }

    return maxLength;
  }
  
  [Test]
  public void Test1()
  {
    var result = LongestConsecutive([100, 4, 200, 1, 3, 2]);
    Assert.That(result, Is.EqualTo(4));
  }

  [Test]
  public void Test2()
  {
    var result = LongestConsecutive([0, 3, 7, 2, 5, 8, 4, 6, 0, 1]);
    Assert.That(result, Is.EqualTo(9));
  }

  [Test]
  public void Test3()
  {
    var result = LongestConsecutive([1, 0, 1, 2]);
    Assert.That(result, Is.EqualTo(3));
  }

  [Test]
  public void Test4()
  {
    var result = LongestConsecutive([0, -1]);
    Assert.That(result, Is.EqualTo(2));
  }

  [Test]
  public void Test5()
  {
    var result = LongestConsecutive([1, 0, -1]);
    Assert.That(result, Is.EqualTo(3));
  }
}