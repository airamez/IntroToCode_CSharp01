using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingQuestions;

public class SortDoubleLinkedListApp
{
  public static void Main(string[] args)
  {
    LinkedList<int> list = Generate(100);
    Print(list);

    // Option 1: Time = O(NLog(N)); Space = O(N)
    var sorted = new LinkedList<int>(list.OrderBy(x => x));
    Print(sorted);

    // Option 2: Time = O(N); Space = in-place
    Sort(list);
    Print(sorted);
  }

  public static void Sort(LinkedList<int> list)
  {
    int[] counters = new int[3];
    foreach (var item in list)
    {
      counters[item]++;
    }
    var runner = list.First;
    for (int currentValue = 0; currentValue < 3; currentValue++)
    {
      for (int j = 0; j < counters[currentValue]; j++)
      {
        runner.Value = currentValue;
        runner = runner.Next;
      }
    }
  }

  public static LinkedList<int> Generate(int length)
  {
    Random rnd = new Random();
    LinkedList<int> list = new LinkedList<int>();
    for (int i = 0; i < length; i++)
    {
      list.AddLast(rnd.Next(3));
    }
    return list;
  }

  private static void Print<T>(LinkedList<T> list)
  {
    Console.Write("\nList: ");
    foreach (var item in list)
    {
      Console.Write($"{item} ");
    }
    Console.WriteLine();
  }
}