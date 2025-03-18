using LeetCodeCSharp.Common;

namespace LeetCodeCSharp.Easy.LinkedList.L876;

/**
 * 
 * Given the head of a singly linked list, return the middle node of the linked list.
 * If there are two middle nodes, return the second middle node.
 *
 *
 * Input: head = [1,2,3,4,5]
 * Output: [3,4,5]
 * Explanation: The middle node of the list is node 3.
 *
 * Input: head = [1,2,3,4,5,6]
 * Output: [4,5,6]
 * Explanation: Since the list has two middle nodes with values 3 and 4,
 * we return the second one.
 *
 */
// https://leetcode.com/problems/middle-of-the-linked-list/
// #LinkedList #TwoPointers
public class MiddleOfLinkedList
{
  private static ListNode? MiddleNode(ListNode? head)
  {
    if (head == null) return head;
    
    var slow = head;
    var fast = head;

    // while (fast != null && fast.Next != null)
    while (fast?.Next != null)
    {
      slow = slow?.Next;
      fast = fast.Next.Next;
    }

    return slow;
  }

  [Test]
  public void Test1()
  {
    var head = new ListNode(1, null);
    var first = new ListNode(2, null);
    var second = new ListNode(3, null);
    var third = new ListNode(4, null);
    var fourth = new ListNode(5, null);
    
    head.Next = first;
    first.Next = second;
    second.Next = third;
    third.Next = fourth;
    
    var middleNode = MiddleNode(head);
    Assert.That(middleNode?.Val, Is.EqualTo(3));
  }
  
}