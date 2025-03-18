using LeetCodeCSharp.Common;

namespace LeetCodeCSharp.Easy.LinkedList.L234;

/**
 *
 *
 * https://www.youtube.com/watch?v=wk4QsvwQwdQ
 * https://www.youtube.com/watch?v=yOzXms1J6Nk
 * 
 * Given the head of a singly linked list, return true if it is a palindrome
 * or false otherwise.
 *
 * Input = 1 -> 2 -> 2 -> 1
 *
 * Explanation:
 * traverse till mid-point
 * reverse from mid-point to n-1
 * Result
 *  right 1 -> 2
 *  left  1 -> 2
 * using two pointers compare
 * 
 */
// https://leetcode.com/problems/palindrome-linked-list/
// https://github.com/MisterBooo/LeetCodeAnimation/blob/master/0234-isPalindrome/Animation/solved01.gif
// https://github.com/MisterBooo/LeetCodeAnimation/blob/master/0234-isPalindrome/Animation/solved02.gif = midpoint
// #LinkedList #TwoPointers 

public class PalindromeLinkedList
{
  private static bool IsPalindrome(ListNode? head)
  {
    var left = head;
    var right = head;
    
    // find midpoint
    while (right?.Next != null)
    {
      right = right?.Next?.Next;
      left = left?.Next;
    }

    // reverse from mid to n-1
    var mid = Reverse(left); 
    left = head; // start from first

    while (mid != null)
    {
      if (left?.Val != mid.Val) return false;
      
      left = left?.Next;
      mid = mid?.Next;
    }
    
    return true;
  }

  private static ListNode? Reverse(ListNode? list)
  {
    if (list == null) return list;
    
    ListNode? prev = null;
    var curr = list;
    
    while (curr != null)
    {
      var next = curr.Next;
      
      curr.Next = prev;
      prev = curr;
      curr = next;
    }
    return prev;
  }


  [Test]
  public void Test1()
  {
    var head = new ListNode(1, null);
    var second = new ListNode(2, null);
    var third = new ListNode(2, null);
    var fourth = new ListNode(1, null);

    head.Next = second;
    second.Next = third;
    third.Next = fourth;

    var result = IsPalindrome(head);
  }
  
}