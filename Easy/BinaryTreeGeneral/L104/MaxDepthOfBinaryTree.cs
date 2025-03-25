using LeetCodeCSharp.Common;

namespace LeetCodeCSharp.Easy.BinaryTreeGeneral.L104;
/**
 * A binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
 */
// https://leetcode.com/problems/maximum-depth-of-binary-tree/description
// #L104 #BinaryTreeGeneral
public class MaxDepthOfBinaryTree
{ 
  
  /*
   *         3               1 + max(l, r) = 1
   *       /   \             1 + max(1, 2) = 3
   *   (1)9     20(1 + 1)
   *           / \
   *       (1)15   7(1)
   */
  private static int MaxDepth(TreeNode? root)
  {
    // Base case: if the node is null, return depth of 0
    if (root == null)
      return 0;
    
    // Recursively calculate the depth of the left subtree
    var leftDepth = MaxDepth(root.Left);
    // Recursively calculate the depth of the right subtree
    var rightDepth = MaxDepth(root.Right);

    // Return the maximum depth between left and right subtrees, plus 1 for the current node
    return System.Math.Max(leftDepth, rightDepth) + 1;
  }

  [Test]
  public void Test()
  {
    var root = new TreeNode
    {
      Val = 3,
      Left = new TreeNode{Val = 9, Left = null, Right = null},
      Right = new TreeNode{Val = 20, Left = new TreeNode{Val=15, Left = null, Right = null}, Right = new TreeNode{Val=7, Left = null, Right = null}},
    };

    var maxDepth = MaxDepth(root);
    Assert.That(maxDepth, Is.EqualTo(3));
  }
}