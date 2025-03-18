using LeetCodeCSharp.Common;

namespace LeetCodeCSharp.Medium.LinkedList.L2;

/**
 *
 *  You are given two non-empty linked lists representing two non-negative integers.
 *  The digits are stored in reverse order, and each of their nodes contains a single digit.
 *  Add the two numbers and return the sum as a linked list.
 *
 * Input: l1 = [2,4,3], l2 = [5,6,4] ,note: input are stored in "reverse order"
 * Output: [7,0,8]
 *
 * 5 -> 6 -> 4
 * 2 -> 4 -> 3 -> 3
 * -------------------
 * 7 -> 0 -> 8 -> 3
 *
 */

// https://leetcode.com/problems/add-two-numbers
// https://github.com/MisterBooo/LeetCodeAnimation/blob/master/0002-Add-Two-Numbers/Animation/Animation.gif
// LinkedList #L2 #Recursion
public class AddTwoNumbers
{
  private static ListNode? Solution(ListNode? l1, ListNode? l2)
  {
    var carry = 0;
    ListNode dummy = new(0, null);
    ListNode current = dummy;

    while (l1 != null || l2 != null)
    {
      var x = l1?.Val ?? 0;
      var y = l2?.Val ?? 0;

      var sum = carry + x + y;
      carry = sum / 10;
      var rem = sum % 10;
      
      current.Next = new(rem, null);
      current = current.Next;

      l1 = l1?.Next;
      l2 = l2?.Next;
    }

    if (carry > 0)
    {
      current.Next = new ListNode(carry, null);
    }

    return dummy.Next;
  }

  [Test]
  public void Test1()
  {
    ListNode l1 = new ListNode(2, new ListNode(4, new ListNode(3, null)));
    ListNode l2 = new ListNode(5, new ListNode(6, new ListNode(4, null)));
    Solution(l1, l2);
  }
  
  [Test]
  public void Test2()
  {
    // 942 + 964 = 1906
    ListNode l1 = new ListNode(2, new ListNode(4, new ListNode(9, null)));
    ListNode l2 = new ListNode(5, new ListNode(6, new ListNode(9, null)));
    Solution(l1, l2);
  }
}