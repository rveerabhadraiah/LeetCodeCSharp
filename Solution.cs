namespace LeetCodeCSharp;

public class Solution
{
  private static void NoPrefix(List<string> words)
  {

    for(int i=0; i<words.Count-1; i++)
    {
      for(int j=0; j<words.Count-1; j++)
      {
        if(i == j)continue;
        if(words[j].StartsWith(words[i]))
        {
          Console.WriteLine("BAD SET");
          Console.WriteLine(words[j]);
          return;
        }
          
      }
        
    }
      
    Console.WriteLine("GOOD SET");
      
  }

  [Test]
  public void Test()
  {
    NoPrefix(new List<string>(){"abcd", "bcd", "abcde", "bcde"});
  }
}