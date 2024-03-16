using NUnit.Framework;
using DataStructures.LinkedList;

namespace Tests;

public class LinkedListTests
{
    [Test]
    public void AddAtHeadTest()
    {
        LinkedList linkedList = new LinkedList();
        linkedList.AddAtHead("Node 1");
        Assert.That(linkedList.Head.Data, Is.EqualTo("Node 1"));
        linkedList.AddAtHead("Node 2");
        Assert.That(linkedList.Head.Data, Is.EqualTo("Node 2"));
        linkedList.AddAtHead("Node 3");
        Assert.That(linkedList.Head.Data, Is.EqualTo("Node 3"));

        Node first = linkedList.Head;
        Node second = first.Next;
        Node third = second.Next;
        Assert.That(first.Data, Is.EqualTo("Node 3"));
        Assert.That(second.Data, Is.EqualTo("Node 2"));
        Assert.That(third.Data, Is.EqualTo("Node 1"));
    }

    [Test]
    public void CountTest()
    {
        LinkedList linkedList = new LinkedList();
        Assert.That(linkedList.Count, Is.EqualTo(0));
        linkedList.AddAtHead("Node 1");
        Assert.That(linkedList.Count, Is.EqualTo(1));
        linkedList.AddAtHead("Node 2");
        Assert.That(linkedList.Count, Is.EqualTo(2));
        linkedList.AddAtHead("Node 3");
        Assert.That(linkedList.Count, Is.EqualTo(3));
    }

    [Test]
    public void AddAtTailTest()
    {
        LinkedList linkedList = new LinkedList();
        linkedList.AddAtTail("Node 1");
        Assert.That(linkedList.Tail.Data, Is.EqualTo("Node 1"));
        linkedList.AddAtTail("Node 2");
        Assert.That(linkedList.Tail.Data, Is.EqualTo("Node 2"));
        linkedList.AddAtTail("Node 3");
        Assert.That(linkedList.Tail.Data, Is.EqualTo("Node 3"));
    }

    [Test]
    public void GetTest()
    {
        LinkedList linkedList = new LinkedList();
        linkedList.AddAtTail("Node 0");
        Assert.That(linkedList.Get(0).Data, Is.EqualTo("Node 0"));
        linkedList.AddAtTail("Node 1");
        Assert.That(linkedList.Get(1).Data, Is.EqualTo("Node 1"));
        linkedList.AddAtTail("Node 2");
        Assert.That(linkedList.Get(2).Data, Is.EqualTo("Node 2"));
    }

    [Test]
    public void AddAtPosition()
    {
        LinkedList linkedList = new LinkedList();
        linkedList.AddAt("Node 4", 0); // 4
        Assert.That(linkedList.Head.Data, Is.EqualTo("Node 4"));

        linkedList.AddAt("Node 0", 0); // 0 4
        Assert.That(linkedList.Head.Data, Is.EqualTo("Node 0"));
        Assert.That(linkedList.Tail.Data, Is.EqualTo("Node 4"));

        linkedList.AddAt("Node 1", 1); // 0 1 4
        Assert.That(linkedList.Head.Data, Is.EqualTo("Node 0"));
        Assert.That(linkedList.Tail.Data, Is.EqualTo("Node 4"));
        Assert.That(linkedList.Get(1).Data, Is.EqualTo("Node 1"));

        linkedList.AddAt("Node 2", 2); // 0 1 2 4
        Assert.That(linkedList.Head.Data, Is.EqualTo("Node 0"));
        Assert.That(linkedList.Tail.Data, Is.EqualTo("Node 4"));
        Assert.That(linkedList.Get(2).Data, Is.EqualTo("Node 2"));

        linkedList.AddAt("Node 3", 3); // 0 1 2 3 4
        Assert.That(linkedList.Head.Data, Is.EqualTo("Node 0"));
        Assert.That(linkedList.Tail.Data, Is.EqualTo("Node 4"));
        Assert.That(linkedList.Get(3).Data, Is.EqualTo("Node 3"));
    }

    [Test]
    public void DeleteAtHeadTest()
    {
        LinkedList linkedList = new LinkedList();
        linkedList.AddAtTail("Node 0");
        linkedList.AddAtTail("Node 1");
        linkedList.AddAtTail("Node 2");
        linkedList.DeleteAtHead();
        Assert.That(linkedList.Head.Data, Is.EqualTo("Node 1"));
        linkedList.DeleteAtHead();
        Assert.That(linkedList.Head.Data, Is.EqualTo("Node 2"));
    }

    [Test]
    public void DeleteAtTailTest()
    {
        LinkedList linkedList = new LinkedList();
        linkedList.AddAtTail("Node 0");
        linkedList.AddAtTail("Node 1");
        linkedList.AddAtTail("Node 2");
        linkedList.DeleteAtTail();
        Assert.That(linkedList.Tail.Data, Is.EqualTo("Node 1"));
        linkedList.DeleteAtTail();
        Assert.That(linkedList.Tail.Data, Is.EqualTo("Node 0"));
    }

    [Test]
    public void DeleteAtPositionTest()
    {
        LinkedList linkedList = new LinkedList();
        linkedList.AddAtTail("Node 0");
        linkedList.AddAtTail("Node 1");
        linkedList.AddAtTail("Node 2");
        linkedList.AddAtTail("Node 3");
        linkedList.AddAtTail("Node 4");
        linkedList.DeleteAt(0);
        Assert.That(linkedList.Head.Data, Is.EqualTo("Node 1"));
        linkedList.DeleteAt(1);
        Assert.That(linkedList.Get(1).Data, Is.EqualTo("Node 3"));
        linkedList.DeleteAt(2);
        Assert.That(linkedList.Tail.Data, Is.EqualTo("Node 3"));
    }
}
