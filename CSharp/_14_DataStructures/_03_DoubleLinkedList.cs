using System;

namespace DataStructures.DoubleLinkedList;

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
}