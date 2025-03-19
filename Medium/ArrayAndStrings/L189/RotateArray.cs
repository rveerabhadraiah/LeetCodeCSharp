namespace LeetCodeCSharp.Medium.ArrayAndStrings.L189;

/**
 * Given an integer array nums, rotate the array to the right by k steps, where k is non-negative.
 * Example 1:
 * Input: nums = [1,2,3,4,5,6,7], k = 3
 * Output: [5,6,7,1,2,3,4]
 * Explanation:
 * rotate 1 steps to the right: [7,1,2,3,4,5,6]
 * rotate 2 steps to the right: [6,7,1,2,3,4,5]
 * rotate 3 steps to the right: [5,6,7,1,2,3,4]
 *
 * Example 2:
 * Input: nums = [-1,-100,3,99], k = 2
 * Output: [3,99,-1,-100]
 * Explanation:
 * rotate 1 steps to the right: [99,-1,-100,3]
 * rotate 2 steps to the right: [3,99,-1,-100]
 */
// https://leetcode.com/problems/rotate-array/description/
//  #L189
public class RotateArray
{
  private int[] Rotate(int[] nums, int k)
  {
    // nums of array can be less or greater than k
    k = k % nums.Length;
    
    Reverse(nums, 0, nums.Length - 1);
    Reverse(nums, 0, k - 1);
    Reverse(nums, k, nums.Length - 1);

    return nums;
  }

  private int[] Reverse(int[] num, int i, int j)
  {
    while (i < j)
    {
      (num[i], num[j]) = (num[j], num[i]);
      i++;
      j--;
    }

    return num;
  }

  
  [Test]
  public void Test1()
  {
    var rotate = Rotate([1,2,3,4,5,6,7], 3);
    Assert.That(rotate, Is.EqualTo(new[] {5,6,7,1,2,3,4}));
  }
  
  [Test]
  public void Test2()
  {
    var rotate = Rotate([-1,-100,3,99], 2);
    Assert.That(rotate, Is.EqualTo(new[] {3,99,-1,-100}));
  }
  
  [Test]
  public void Test3()
  {
    var rotate = Rotate([-1], 2);
    Assert.That(rotate, Is.EqualTo(new[] {-1}));
  }
}