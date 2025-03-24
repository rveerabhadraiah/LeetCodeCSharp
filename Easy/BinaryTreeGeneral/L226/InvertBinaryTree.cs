using LeetCodeCSharp.Common;

namespace LeetCodeCSharp.Easy.BinaryTreeGeneral.L226;


// https://leetcode.com/problems/invert-binary-tree
// #L226 #BinaryTreeGeneral
public class InvertBinaryTree
{
  
  /**
    *    2        2 
    *   / \  =>  / \
    *  1   3    3   1
   */
  private static TreeNode? InvertTree(TreeNode? root) 
  {
    // Base case: if the tree is empty or we've reached a leaf node's child (null)
    if (root == null) return null;

    // Swap the left and right children
    (root.Left, root.Right) = (root.Right, root.Left);

    // Recursively invert the left and right subtrees
    InvertTree(root.Left);
    
    // Recursively invert the right subtree
    InvertTree(root.Right);

    // Return the inverted tree
    return root;
  }

  [Test]
  public void Test()
  {
    var root = new TreeNode
    {
      Val = 1, Left = new TreeNode{Val=2, Left=null, Right=null}, Right = new TreeNode{Val=3, Left=null, Right=null}
    };
    var invertTree = InvertTree(root);
  }
}