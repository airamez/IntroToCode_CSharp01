// https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.keyvaluepair?view=net-8.0

using System;
using System.Collections.Generic;

namespace Collections.KeyValuePair;

public class KeyValuePairApp
{
  public static void Main(string[] args)
  {
    var monday = new KeyValuePair<int, string>(1, "Monday");
    var key = monday.Key;
    var value = monday.Value;
    Console.WriteLine($"{key}:{value}");

    var month = new KeyValuePair<string, string>("DEC", "December");
    Console.WriteLine($"{month.Key} = {month.Value}");
  }
}