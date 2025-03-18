using LeetCodeCSharp.Common;

namespace LeetCodeCSharp.Easy.LinkedList.L141;

/**
 *
 * Input: head = [3, 2, 0, -4], pos = 1
 *                   |______|
 * Output: true
 * Explanation: There is a cycle in the linked list,
 * where the tail connects to the 1st node (0-indexed).
 *
 * Given head, the head of a linked list, determine if the linked list has a cycle in it.
 * There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer.
 * Internally, pos is used to denote the index of the node that tail's next pointer is connected to.
 *
 * Note that pos is not passed as a parameter.
 */

// https://www.youtube.com/watch?v=6OrZ4wAy4uE
// https://leetcode.com/problems/linked-list-cycle/description/
// https://github.com/MisterBooo/LeetCodeAnimation/blob/master/0141-Linked-List-Cycle/Animation/Animation.gif
// #LinkedList #L141 #TwoPointers
public class LinkedListCycle
{
  private static bool HasCycle(ListNode? head)
  {
    if (head == null) return false;
    
    var slow = head;
    var fast = head.Next;

    while (slow != fast)
    {
      if (fast?.Next == null) return false;
      // if (fast == null || fast.Next == null) return false;
      
      slow = slow?.Next;
      fast = fast.Next.Next;
    }

    return true;
  }


  [Test]
  public void Test1()
  {
    var head = new ListNode(3, null);
    var second = new ListNode(2, null);
    var third = new ListNode(0, null);
    var fourth = new ListNode(1, null);
    
    head.Next = second;
    second.Next = third;
    third.Next = fourth;
    fourth.Next = second;
    
    var hasCycle = HasCycle(head);
    
    Assert.True(hasCycle);
  }
  
  [Test]
  public void Test2()
  {
    Assert.False(HasCycle(null));
  }
}