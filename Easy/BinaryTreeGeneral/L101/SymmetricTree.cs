using LeetCodeCSharp.Common;

namespace LeetCodeCSharp.Easy.BinaryTreeGeneral.L101;

/**
 * Given the root of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center).
 */
// https://leetcode.com/problems/symmetric-tree
// L101 #BinaryTree
public class SymmetricTree
{
  public bool IsSymmetric(TreeNode? root)
  {
    // If the tree is empty, it's symmetric by definition
    if (root == null) {
      return true;
    }

    // Call helper method to compare left and right subtrees
    return IsMirror(root, root);
  }

  private static bool IsMirror(TreeNode? leftSubTree, TreeNode? rightSubTree)
  {
    // If both nodes are null, they're symmetric
    if (leftSubTree == null && rightSubTree == null) return true;
    
    // If one node is null while the other isn't, they're not symmetric
    if (leftSubTree == null || rightSubTree == null) return false;
    
    // Check three conditions for symmetry:
    // 1. Current node values must be the same
    if (leftSubTree.Val != rightSubTree.Val) return false;
    
    // 2. Left subtree's left must mirror right subtree's right
    // 3. Left subtree's right must mirror right subtree's left
    return IsMirror(leftSubTree.Left, rightSubTree.Right) && IsMirror(leftSubTree.Right, rightSubTree.Left);
  }
}