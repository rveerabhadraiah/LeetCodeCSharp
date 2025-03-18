using LeetCodeCSharp.Common;

namespace LeetCodeCSharp.Easy.LinkedList.L206;

/**
 * #LinkedList #Recursion
 * 
 * Given the head of a singly linked list, reverse the list, and return the reversed list.
 *
 * Input:  1 -> 2 -> 3 -> 4 -> 5
 * output: 5 -> 4 -> 3 -> 2 -> 1
 *
 */
// https://leetcode.com/problems/reverse-linked-list/
// https://github.com/MisterBooo/LeetCodeAnimation/blob/master/0206-Reverse-Linked-List/Animation/Animation.gif
// #LinkedList

public class ReverseLinkedList
{
  private static ListNode? ReverseList(ListNode? head)
  {
    if (head == null) return head;
    
    ListNode? prev = null;
    ListNode? curr = head;
    
    while (curr != null)
    {
      ListNode? next = curr.Next;

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
    var third = new ListNode(3, null);
    var fourth = new ListNode(4, null);
    var fifth = new ListNode(5, null);
    
    head.Next = second;
    second.Next = third;
    third.Next = fourth;
    fourth.Next = fifth;

    var reverseList = ReverseList(head);
    
    Assert.That(reverseList?.Val, Is.EqualTo(5));
    Assert.That(reverseList?.Next?.Val, Is.EqualTo(4));
    Assert.That(reverseList.Next?.Next?.Val, Is.EqualTo(3));
    Assert.That(reverseList?.Next?.Next?.Next?.Val, Is.EqualTo(2));
    Assert.That(reverseList?.Next?.Next?.Next?.Next?.Val, Is.EqualTo(1));
  }
}