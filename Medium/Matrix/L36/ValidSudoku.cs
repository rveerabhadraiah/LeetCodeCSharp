namespace LeetCodeCSharp.Medium.Matrix.L36;

// https://leetcode.com/problems/valid-sudoku/
// #L36 #Matrix #HashMap
public class ValidSudoku
{
  private static bool IsValidSudoku(char[][] board)
  {
    // Use HashSets to track seen digits
    var visited = new HashSet<string>();
    
    for (var row = 0; row < board.Length; row++)
    {
      for (var col = 0; col < board[row].Length; col++)
      {
        var currentDigit = board[row][col];
        // Skip empty cells
        if (currentDigit.Equals('.')) continue;

        var boxRow = row / 3;
        var boxCol = col / 3;
        
        // Try to add each constraint to the HashSet
        // If any returns false, means we found a duplicate
        if (!visited.Add($"{currentDigit} in row {row}") 
            || !visited.Add($"{currentDigit} in col {col}")
            || !visited.Add($"{currentDigit} in box {boxRow} - {boxCol}"))
        {
          return false;
        }
      }
    }
    // If we get here, no duplicates were found
    return true;
  }

  [Test]
  public void Test()
  {
    var isValidSudoku = IsValidSudoku([
      ['5', '3', '.', '.', '7', '.', '.', '.', '.'], 
      ['6', '.', '.', '1', '9', '5', '.', '.', '.'],
      ['.', '9', '8', '.', '.', '.', '.', '6', '.'], 
      ['8', '.', '.', '.', '6', '.', '.', '.', '3'],
      ['4', '.', '.', '8', '.', '3', '.', '.', '1'],
      ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
      ['.', '6', '.', '.', '.', '.', '2', '8', '.'], 
      ['.', '.', '.', '4', '1', '9', '.', '.', '5'],
      ['.', '.', '.', '.', '8', '.', '.', '7', '9']
    ]);
    
    Assert.That(isValidSudoku, Is.True);
  }
}