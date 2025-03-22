using System.Text;

namespace LeetCodeCSharp.Medium.ArrayAndStrings.L6;

/*
The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this
: (you may want to display this pattern in a fixed font for better legibility)

P   A   H   N
A P L S I I G
Y   I   R
And then read line by line: "PAHNAPLSIIGYIR"
Write the code that will take a string and make this conversion given a number of rows:
string convert(string s, int numRows);
 

Example 1:

Input: s = "PAYPALISHIRING", numRows = 3
Output: "PAHNAPLSIIGYIR"
Example 2:

Input: s = "PAYPALISHIRING", numRows = 4
Output: "PINALSIGYAHRPI"
Explanation:
P     I    N
A   L S  I G
Y A   H R
P     I
Example 3:

Input: s = "A", numRows = 1
Output: "A"
*/
//  https://leetcode.com/problems/zigzag-conversion
// #L6 #String
public class ZigZagConversion
{
  private static string Convert(string s, int numRows)
  {
    // Handle edge cases
    if (numRows == 1 || numRows >= s.Length)
      return s;
   
    // Initialize rows as a list of StringBuilder objects
    var rows = new List<StringBuilder>();
    for (var i = 0; i < numRows; i++)
    {
      rows.Add(new StringBuilder());
    }

    // Variables to track current direction and row
    var index = 0;
    var step = 1; // 1 means moving down, -1 means moving up
    
    // Iterate through each character in the string
    foreach (var c in s)
    {
      // Add the current character to the appropriate row
      rows[index].Append(c);

      // Change direction if we reach the top or bottom row
      if (index == 0)
      {
        step = 1; // Change direction to moving down
      }
      else if (index == numRows - 1)
      {
        step = -1;  // Change direction to moving up
      }
      
      // Move to the next row based on current direction
      index += step;
    }

    // Combine all rows to get the final result
    var result = new StringBuilder();
    foreach (var row in rows)
    {
      result.Append(row);
    }
    
    return result.ToString();
  }

  [Test]
  public void Test1()
  {
    var result = Convert("PAYPALISHIRING", 3);
    Assert.That(result, Is.EqualTo("PAHNAPLSIIGYIR"));
  }
  
  [Test]
  public void Test2()
  {
    var result = Convert("PAYPALISHIRING", 4);
    Assert.That(result, Is.EqualTo("PINALSIGYAHRPI"));
  }
  
}