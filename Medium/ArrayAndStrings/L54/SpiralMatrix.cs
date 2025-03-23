namespace LeetCodeCSharp.Medium.ArrayAndStrings.L54;

/**
 * Given an m x n matrix, return all elements of the matrix in spiral order.
 *
 * Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
 * Output: [1,2,3,6,9,8,7,4,5]
 *
 * Input: matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
 * Output: [1,2,3,4,8,12,11,10,9,5,6,7]
 */
// https://leetcode.com/problems/spiral-matrix
// #L54 #Matrix #Simulation
public class SpiralMatrix
{
  private static IList<int> SpiralOrder(int[][] matrix)
  {
    // Check if matrix is empty
    if (matrix.Length == 0 || matrix[0].Length == 0)
    {
      return new List<int>();
    }

    var result = new List<int>();

    // Define boundaries
    var top = 0;
    var bottom = matrix.Length - 1;
    var left = 0;
    var right = matrix[0].Length - 1;

    // Direction of traversal (0: right, 1: down, 2: left, 3: up)
    int direction = 0;

    while (top <= bottom && left <= right)
    {
      if (direction == 0)
      {
        // Move right
        for (var i = left; i <= right; i++)
        {
          result.Add(matrix[top][i]);
        }

        top++;
      }
      else if (direction == 1)
      {
        // Move down
        for (var i = top; i <= bottom; i++)
        {
          result.Add(matrix[i][right]);
        }

        right--;
      }
      else if (direction == 2)
      {
        // Move left
        for (var i = right; i >= left; i--)
        {
          result.Add(matrix[bottom][i]);
        }

        bottom--;
      }
      else
      {
        // Move up
        for (var i = bottom; i >= top; i--)
        {
          result.Add(matrix[i][left]);
        }

        left++;
      }

      // Change direction
      direction = (direction + 1) % 4;
    }

    return result;
  }

  [Test]
  public void Test1()
  {
    int[][] matrix = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
    var result = SpiralOrder(matrix);
    Assert.That(result, Is.EqualTo(new[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 }));
  }

  [Test]
  public void Test2()
  {
    int[][] matrix = [[1, 2, 3, 4], [5, 6, 7, 8], [9, 10, 11, 12]];
    var result = SpiralOrder(matrix);
    Assert.That(result, Is.EqualTo(new[] { 1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7 }));
  }

  [Test]
  public void Test3()
  {
    int[][] matrix = [[2, 3]];
    var result = SpiralOrder(matrix);
    Assert.That(result, Is.EqualTo(new[] { 2, 3 }));
  }

  [Test]
  public void Test4()
  {
    int[][] matrix = [[7], [9], [6]];
    var result = SpiralOrder(matrix);
    Assert.That(result, Is.EqualTo(new[] { 7, 9, 6 }));
  }

  [Test]
  public void Test5()
  {
    int[][] matrix = [[2, 5, 8], [4, 0, -1]];
    var result = SpiralOrder(matrix);
    Assert.That(result, Is.EqualTo(new[] { 2, 5, 8, -1, 0, 4 }));
  }
}