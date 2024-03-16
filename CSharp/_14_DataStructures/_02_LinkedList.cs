using System;

namespace Datastructures.LinkedList;

public class LinkedListApp
{
    public static void Main(string[] args)
    {

    }
}


/// <summary>
/// Represents a node in a linked list.
/// </summary>
public class Node
{
    /// <summary>
    /// Gets or sets the data stored in the node.
    /// </summary>
    public string Data { set; get; }

    /// <summary>
    /// Gets or sets the reference to the next node in the linked list.
    /// </summary>
    public Node Next { set; get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Node"/> class with the specified data.
    /// </summary>
    /// <param name="data">The data to be stored in the node.</param>
    public Node(string data)
    {
        Data = data;
        Next = null;
    }
}

/// <summary>
/// Represents a singly linked list data structure.
/// </summary>
public class LinkedList
{
    /// <summary>
    /// Gets the head node of the linked list.
    /// </summary>
    public Node Head { get; private set; }

    /// <summary>
    /// Gets the tail node of the linked list.
    /// </summary>
    public Node Tail { get; private set; }

    /// <summary>
    /// Gets the number of nodes in the linked list.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LinkedList"/> class.
    /// </summary>
    public LinkedList()
    {
        Head = null;
        Tail = null;
    }

    /// <summary>
    /// Adds a new node with the specified data at the head of the linked list.
    /// </summary>
    /// <param name="data">The data to be added.</param>
    public void AddAtHead(string data)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Adds a new node with the specified data at the tail of the linked list.
    /// </summary>
    /// <param name="data">The data to be added.</param>
    /// <exception cref="System.IndexOutOfRangeException"></exception>
    public void AddAtTail(string data)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Adds a new node with the specified data at the specified position in the linked list.
    /// Raise exception if the position is out of range.
    /// </summary>
    /// <param name="data">The data to be added.</param>
    /// <param name="position">The position at which to add the node.</param>
    /// <exception cref="System.IndexOutOfRangeException"></exception>

    public void AddAt(string data, int position)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the node at the specified position in the linked list.
    /// </summary>
    /// <param name="position">The position of the node to retrieve.</param>
    /// <returns>The node at the specified position.</returns>
    public Node Get(int position)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes the node at the head of the linked list.
    /// </summary>
    public void DeleteAtHead()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes the node at the tail of the linked list.
    /// </summary>
    public void DeleteAtTail()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes the node at the specified position in the linked list.
    /// Raise exception if the position is out of range.
    /// </summary>
    /// <param name="position">The position of the node to delete.</param>
    /// <exception cref="System.IndexOutOfRangeException"></exception>
    public void DeleteAt(int position)
    {
        throw new NotImplementedException();
    }
}