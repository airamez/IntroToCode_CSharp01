using System;
using System.IO;

namespace UnitTesting;

public class TextFileProcessing_1
{
  public static void Main(string[] args)
  {
    string filePath = "CSharp/_12_UnitTesting/InputFile.txt";
    StreamReader reader = null;
    try
    {
      int number;
      int sum = 0;
      int count = 0;
      reader = new StreamReader(filePath);
      while (!reader.EndOfStream)
      {
        try
        {
          number = Convert.ToInt32(reader.ReadLine());
          count++;
          sum += number;
          Console.WriteLine($"{count}: {number}");
        }
        catch (FormatException ex)
        {
          Console.WriteLine(ex.Message);
        }
      }
      decimal average = sum / (decimal)count;
      Console.WriteLine($"Sum: {sum}");
      Console.WriteLine($"Average: {average}");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"An unexpected error occurred: {ex.Message}");
    }
    finally
    {
      if (reader != null)
      {
        reader.Close();
      }
    }
  }
}