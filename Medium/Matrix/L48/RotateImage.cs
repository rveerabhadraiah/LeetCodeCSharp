namespace LeetCodeCSharp.Medium.Matrix.L48;
/**
 * You are given an n x n 2D matrix representing an image, rotate the image by 90 degrees (clockwise).
 * You have to rotate the image in-place, which means you have to modify the input 2D matrix directly.
 * DO NOT allocate another 2D matrix and do the rotation.
 *
 * Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
 * Output: [[7,4,1],[8,5,2],[9,6,3]]
 * 
 */
// https://leetcode.com/problems/rotate-image
// #L48 #Matrix
public class RotateImage
{
  private static void Rotate(int[][] matrix) 
  {
    var matrixLen = matrix.Length;

    // Step 1: Transpose the matrix (swap rows with columns)
    for (var row = 0; row < matrixLen; row++)
    {
      for (var col = row; col < matrixLen; col++)
      {
        (matrix[row][col], matrix[col][row]) = (matrix[col][row], matrix[row][col]);
      }
    }

    // Step 2: Reverse each row
    for (var row = 0; row < matrixLen; row++)
    {
      // The reason we only loop through half the row (j < n / 2) is to avoid "double swapping".
      // If we went through the entire row, we would swap each element twice, effectively returning to the original arrangement.
      // By stopping at the midpoint, we ensure each pair of elements is swapped exactly once
      for (var col = 0; col < matrixLen / 2; col++)
      {
        (matrix[row][col], matrix[row][(matrixLen - 1) - col]) = (matrix[row][(matrixLen - 1) - col], matrix[row][col]);
      }
    }
  }

  [Test]
  public void Test()
  {
    int[][] image = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
    Rotate(image);

    int[][] result = [[7, 4, 1], [8, 5, 2], [9, 6, 3]];
    Assert.That(image, Is.EqualTo(result));
  }
}