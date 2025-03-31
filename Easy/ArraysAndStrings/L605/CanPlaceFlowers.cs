namespace LeetCodeCSharp.Easy.ArraysAndStrings.L605;

/**
 * You have a long flowerbed in which some of the plots are planted, and some are not. However,
 * flowers cannot be planted in adjacent plots.
 *
 * Given an integer array flowerbed containing 0's and 1's, where 0 means empty and 1 means not empty,
 * and an integer n, return true if n new flowers can be planted in the flowerbed without violating
 * the no-adjacent-flowers rule and false otherwise.
 *
 * Example 1:
 * Input: flowerbed = [1,0,0,0,1], n = 1 // number of flowers to plan
 * Output: true
 * Example 2:
 * Input: flowerbed = [1,0,0,0,1], n = 2
 * Output: false
 * 
 * Edge Case Example 3:
 * Input: flowerbed = [0,0,1], n = 1 // we can place pot at index 0 => [1,0,1]
 * Output: true
 *
 * Edge CaseExample 4:
 * Input: flowerbed = [0,0, 0], n = 2 // we can place pot at index 0 & 2 => [1,0,1]
 * Output: true
 *
 * tip: create a new array with 0 (empty) at index 0 and index n+1
 * 
 */
// https://leetcode.com/problems/can-place-flowers/description
// https://www.youtube.com/watch?v=ZGxqqjljpUI
// #Array #L605

public class CanPlaceFlowers
{
  private static bool CanPlaceFlowersSol(int[] flowerbed, int n)
  {
    var newFlowerBed = new int[flowerbed.Length + 2];
    for (var i = 0; i < flowerbed.Length; i++)
    {
      newFlowerBed[i + 1] = flowerbed[i];
    }

    const int empty = 0;
    var noOfFlowersPlanted = n;
    for (var i = 1; i < newFlowerBed.Length-1; i++)
    {
      if (noOfFlowersPlanted == 0) return true;
      if (newFlowerBed[i] == empty && (newFlowerBed[i - 1] == empty && newFlowerBed[i + 1] == empty) )
      {
        newFlowerBed[i] = 1;
        noOfFlowersPlanted--;
      }
    }
    
    return noOfFlowersPlanted == 0;
  }


  [Test]
  public void Test1()
  {
    var canPlaceFlowers = CanPlaceFlowersSol([1,0,0,0,1], 1);
    Assert.IsTrue(canPlaceFlowers);
  }
  
  [Test]
  public void Test2()
  {
    var canPlaceFlowers = CanPlaceFlowersSol([1,0,0,0,1], 2);
    Assert.IsFalse(canPlaceFlowers);
  }
  
  [Test]
  public void Test3()
  {
    var canPlaceFlowers = CanPlaceFlowersSol([0,0,0], 2);
    Assert.IsTrue(canPlaceFlowers);
  }
  
  [Test]
  public void Test4()
  {
    var canPlaceFlowers = CanPlaceFlowersSol([0,0,1], 1);
    Assert.IsTrue(canPlaceFlowers);
  }
  
  [Test]
  public void Test5()
  {
    var canPlaceFlowers = CanPlaceFlowersSol([0,0,1], 2);
    Assert.IsFalse(canPlaceFlowers);
  }
  
  [Test]
  public void Test6()
  {
    var canPlaceFlowers = CanPlaceFlowersSol([1,0], 1);
    Assert.IsFalse(canPlaceFlowers);
  }
  
  [Test]
  public void Test7()
  {
    var canPlaceFlowers = CanPlaceFlowersSol([0,0,1,0,0], 1);
    Assert.IsTrue(canPlaceFlowers);
  }
  
  [Test]
  public void Test8()
  {
    var canPlaceFlowers = CanPlaceFlowersSol([1,0,1,0,1,0,1],0);
    Assert.IsTrue(canPlaceFlowers);
  }
}