/*
https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.stack-1?view=net-8.0
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections;

public class StackApp
{
  public static void Main(string[] args)
  {
    var stack = new Stack<string>();
    stack.Push("First");
    stack.Push("Second");
    stack.Push("Third");
    stack.Push("Fourth");
    Console.WriteLine(stack.Peek());
    while (stack.Count > 0)
    {
      Console.WriteLine(stack.Pop());
    }
  }
}