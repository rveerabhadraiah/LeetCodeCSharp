using LeetCodeCSharp.Common;

namespace LeetCodeCSharp.Easy.BinaryTreeGeneral.L100;

/**
 *  Given the roots of two binary trees p and q, write a function to check if they are the same or not.
 * Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.
 */
// https://leetcode.com/problems/same-tree/description
// #L100 #BinaryTreeGeneral
public class SameTree
{
  
  /**
    *      1            1
    *     / \          / \
    *    2   3        2   3
    *   /\   /\      /\   /\
    *  1  3 1  3    1  3 1  3
    *
    */
  private static bool IsSameTree(TreeNode? p, TreeNode? q)
  {
    // If both nodes are null, they're the same (empty trees are identical)
    if (p == null && q == null)
      return true;

    // If one node is null but the other isn't, they're different
    if (p == null || q == null)
      return false;
    
    // Check if current nodes have the same value
    if (p.Val != q.Val)
      return false;
    
    // Recursively check if left subtrees are the same
    // AND if right subtrees are the same
    return IsSameTree(p.Right, q.Right) && IsSameTree(p.Left, q.Left);
  }

  [Test]
  public void Test()
  {
    var tree1 = new TreeNode
    {
      Val = 1,
      Left = new TreeNode{Val = 2, Left = null, Right = null},
      Right = new TreeNode{Val = 3, Left = null, Right = null},
    };
    
    var tree2 = new TreeNode
    {
      Val = 1,
      Left = new TreeNode{Val = 2, Left = null, Right = null},
      Right = new TreeNode{Val = 3, Left = null, Right = null},
    };
    
    Assert.IsTrue(IsSameTree(tree1, tree2));
  }
}