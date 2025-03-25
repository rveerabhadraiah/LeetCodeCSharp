namespace LeetCodeCSharp.Easy.ArraysAndStrings.L1431;

/*
There are n kids with candies. You are given an integer array candies,
where each candies[i] represents the number of candies the ith kid has,
and an integer extraCandies, denoting the number of extra candies that you have.

Return a boolean array result of length n, where result[i] is true if,
after giving the ith kid all the extraCandies, they will have the greatest number
of candies among all the kids, or false otherwise.

Note that multiple kids can have the greatest number of candies.

Example 1:

Input: candies = [2,3,5,1,3], extraCandies = 3
Output: [true,true,true,false,true]

Explanation:
- If you give all extraCandies to Kid 1, they will have 2 + 3 = 5 candies,
  which is the greatest among the kids.
- If you give all extraCandies to Kid 2, they will have 3 + 3 = 6 candies,
  which is the greatest among the kids.
- If you give all extraCandies to Kid 3, they will have 5 + 3 = 8 candies,
  which is the greatest among the kids.
- If you give all extraCandies to Kid 4, they will have 1 + 3 = 4 candies,
  which is not the greatest among the kids.
- If you give all extraCandies to Kid 5, they will have 3 + 3 = 6 candies,
  which is the greatest among the kids.
*/

// https://leetcode.com/problems/kids-with-the-greatest-number-of-candies/description
// #Array #L1431
public class KidsWithGreatestNumberCandies
{
  // Solution-1
  private static IList<bool> KidsWithCandies(int[] candies, int extraCandies)
  {
    var result = new bool[candies.Length];
    for (var i = 0; i < candies.Length ; i++)
    {
      var totalCandyWithKid = candies[i] + extraCandies;
      result[i] = true;
      foreach (var candy in candies)
      {
        if (totalCandyWithKid < candy)
        {
          result[i] = false;
          break;
        }
      }
    }
    return result;
  }
  
  [Test]
  public void Test1()
  {
    var kidsWithCandies = KidsWithCandies([2,3,5,1,3], 3);
    Assert.That(kidsWithCandies, Is.EquivalentTo(new bool[] { true, true, true, false, true }));
  }
  
  [Test]
  public void Test2()
  {
    var kidsWithCandies = KidsWithCandies([4,2,1,1,2], 1);
    Assert.That(kidsWithCandies, Is.EquivalentTo(new bool[] { true, false, false, false, false }));
  }
  
  [Test]
  public void Test3()
  {
    var kidsWithCandies = KidsWithCandies([12, 1, 12], 10);
    Assert.That(kidsWithCandies, Is.EquivalentTo(new bool[] { true, false, true}));
  }
  
  // Solution-2
  private static IList<bool> KidsWithCandies_1(int[] candies, int extraCandies)
  {
    var maxCandies = 0;
    foreach (var candy in candies)
    {
      maxCandies = System.Math.Max(maxCandies, candy);
    }

    return candies.Select(candy => candy + extraCandies >= maxCandies).ToList();
  }
  
  [Test]
  public void Test4()
  {
    var kidsWithCandies = KidsWithCandies_1([2,3,5,1,3], 3);
    Assert.That(kidsWithCandies, Is.EquivalentTo(new bool[] { true, true, true, false, true }));
  }
  
  [Test]
  public void Test5()
  {
    var kidsWithCandies = KidsWithCandies_1([4,2,1,1,2], 1);
    Assert.That(kidsWithCandies, Is.EquivalentTo(new bool[] { true, false, false, false, false }));
  }
  
  [Test]
  public void Test6()
  {
    var kidsWithCandies = KidsWithCandies_1([12, 1, 12], 10);
    Assert.That(kidsWithCandies, Is.EquivalentTo(new bool[] { true, false, true}));
  }
  
}