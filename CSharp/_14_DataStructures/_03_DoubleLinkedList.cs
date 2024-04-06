using System;
using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace DataStructures.DoubleLinkedList;

public class DoubleLinkedListApp
{
    public static void Main(string[] args)
    {
        PerformanceTest();
        // DoubleLinkedList list = new DoubleLinkedList();
        // for (int i = 0; i < 100; i++)
        // {
        //     list.AddAtTail($"Node {i}");
        // }
        // Node nodeAt2 = list.GetAtIndex(2);
        // Node nodeAt50 = list.GetAtIndex(50);
        // Node nodeAt90 = list.GetAtIndex(90);
        // Node nodeAt98 = list.GetAtIndex(98);
    }

    private static void PerformanceTest()
    {
        const int LIMIT = 1000000;
        DoubleLinkedList list = new DoubleLinkedList();
        Random random = new Random();
        for (int i = 0; i < LIMIT; i++)
        {
            list.AddAtTail($"Value: {random.Next(LIMIT)}");
        }
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 0; i < 10000; i++)
        {
            Node node = list.GetAtIndex(random.Next(LIMIT));
            if (i % 1000 == 0)
            {
                Console.Write(".");
            }
        }
        stopwatch.Stop();
        Console.WriteLine($"\nElapsedMilliseconds: {stopwatch.ElapsedMilliseconds}");

        stopwatch.Restart();
        list.GetAtIndex(list.Count - 5);
        stopwatch.Stop();
        Console.WriteLine($"ElapsedMilliseconds: {stopwatch.ElapsedMilliseconds}");
    }
}

public class Node
{
    public string Data { get; set; }
    public Node Previous { get; set; }
    public Node Next { get; set; }

    public Node(string data)
    {
        Data = data;
        Previous = null;
        Next = null;
    }

    public override string ToString()
    {
        return $"[Data: {Data}]";
    }
}

public class DoubleLinkedList
{
    public Node Head { get; private set; }
    public Node Tail { get; private set; }

    public int Count { get; private set; }

    public DoubleLinkedList()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }

    public void AddAtHead(string data)
    {
        var newNode = new Node(data);
        if (Count == 0)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            newNode.Next = Head;
            Head.Previous = newNode;
            Head = newNode;
        }
        Count++;
    }

    public void AddAtTail(string data)
    {
        if (Count == 0)
        {
            AddAtHead(data);
        }
        else
        {
            var newNode = new Node(data);
            Count++;
            Tail.Next = newNode;
            newNode.Previous = Tail;
            Tail = newNode;
        }
    }

    /*
    Get at Index
    Check index boundary: > 0 && < Count
    If index == 0 return Head
    If index = Count – 1 return Tail
    Else
    loop moving a runner to the index position
    Check if index is smaller o greater than half of Count, so we decide to start from head and move to the end or start from tail and move to the begin
    */
    public Node GetAtIndex(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException();
        }
        if (index == 0)
        {
            return Head;
        }
        if (index == Count - 1)
        {
            return Tail;
        }

        Node runner;
        if (index < Count / 2)
        {
            runner = Head;
            for (int i = 0; i < index; i++)
            {
                runner = runner.Next;
            }
        }
        else
        {
            runner = Tail;
            for (int i = Count - 1; i > index; i--)
            {
                runner = runner.Previous;
            }
        }
        return runner;
    }
}