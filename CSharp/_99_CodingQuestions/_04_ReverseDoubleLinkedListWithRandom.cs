using System;
using System.Collections.Generic;
using System.Net.Http;
using DataStructures.DoubleLinkedList;

namespace CodingQuestions;

public class ReverseListWithRandom
{
  public static void Main(string[] args)
  {

    var head = new Node("A");
    head.Next = new Node("B");
    head.Next.Next = new Node("C");
    head.Next.Next.Next = new Node("D");
    head.Next.Next.Next.Next = new Node("E");

    head.Previous = head.Next;
    head.Next.Previous = head.Next.Next;
    head.Next.Next.Previous = null;
    head.Next.Next.Next.Previous = head.Next.Next.Next.Next;
    head.Next.Next.Next.Next.Previous = head.Next.Next.Next;

    Print(head);

    // Basic reversing
    Node newHead = null;
    Node leftRunner = head;
    Node rightRunner = head.Next;

    var references = new Dictionary<Node, Node>();

    while (rightRunner != null)
    {
      if (leftRunner.Previous != null)
      {
        references.Add(leftRunner.Previous, leftRunner);
      }
      if (newHead == null)
      {
        newHead = leftRunner;
        newHead.Next = null;
      }
      else
      {
        leftRunner.Next = newHead;
        newHead = leftRunner;
      }
      leftRunner = rightRunner;
      rightRunner = rightRunner.Next;
    }
    references.Add(leftRunner.Previous, leftRunner);
    leftRunner.Next = newHead;
    newHead = leftRunner;

    Print(newHead);

    // Reversing the previous references
    var runner = newHead;
    while (runner != null)
    {
      if (references.ContainsKey(runner))
      {
        runner.Previous = references[runner];
      }
      else
      {
        runner.Previous = null;
      }
      runner = runner.Next;
    }
    Print(newHead);
  }

  private static void Print(Node runner)
  {
    Console.WriteLine("Printing:");
    while (runner != null)
    {
      Console.WriteLine($"[Data: {runner.Data}; Previous: {(runner.Previous == null ? "null" : runner.Previous.Data)}]");
      runner = runner.Next;
    }
  }
}