using NUnit.Framework;
using DataStructures.DoubleLinkedList;

namespace Tests;

public class DoubleLinkedListTests
{
    [Test]
    public void AddAtHeadTest()
    {
        var list = new DoubleLinkedList();
        Assert.That(list.Count, Is.EqualTo(0));
        Assert.That(list.Head, Is.Null);
        Assert.That(list.Tail, Is.Null);

        string NodeZeroValue = "Node 0";
        list.AddAtHead(NodeZeroValue);
        Assert.That(list.Count, Is.EqualTo(1));
        Assert.That(list.Head.Data, Is.EqualTo(NodeZeroValue));
        Assert.That(list.Tail.Data, Is.EqualTo(NodeZeroValue));

        string NodeOneValue = "Node 1";
        list.AddAtHead(NodeOneValue);
        Assert.That(list.Count, Is.EqualTo(2));
        Assert.That(list.Head.Data, Is.EqualTo(NodeOneValue));
        Assert.That(list.Tail.Data, Is.EqualTo(NodeZeroValue));

        string NodeTwoValue = "Node 2";
        list.AddAtHead(NodeTwoValue);
        Assert.That(list.Count, Is.EqualTo(3));
        Assert.That(list.Head.Data, Is.EqualTo(NodeTwoValue));
        Assert.That(list.Tail.Data, Is.EqualTo(NodeZeroValue));
        Assert.That(list.Head.Next.Data, Is.EqualTo(NodeOneValue));

        string NodeThreeValue = "Node 3";
        list.AddAtHead(NodeThreeValue);
        Assert.That(list.Count, Is.EqualTo(4));
        Assert.That(list.Head.Data, Is.EqualTo(NodeThreeValue));
        Assert.That(list.Head.Next.Data, Is.EqualTo(NodeTwoValue));
        Assert.That(list.Head.Next.Next.Data, Is.EqualTo(NodeOneValue));
    }

    [Test]
    public void AddAtTailtest()
    {
        var list = new DoubleLinkedList();
        Assert.That(list.Count, Is.EqualTo(0));
        Assert.That(list.Head, Is.Null);
        Assert.That(list.Tail, Is.Null);

        string nodeZeroValue = "Node 0";
        string nodeOneValue = "Node 1";
        string nodeTwoValue = "Node 2";
        string nodeThreeValue = "Node 3";

        list.AddAtTail(nodeZeroValue);
        Assert.That(list.Count, Is.EqualTo(1));
        Assert.That(list.Head.Data, Is.EqualTo(nodeZeroValue));
        Assert.That(list.Tail.Data, Is.EqualTo(nodeZeroValue));
        Assert.That(list.Head, Is.SameAs(list.Tail));

        list.AddAtTail(nodeOneValue);
        Assert.That(list.Count, Is.EqualTo(2));
        Assert.That(list.Head.Data, Is.EqualTo(nodeZeroValue));
        Assert.That(list.Tail.Data, Is.EqualTo(nodeOneValue));
        Assert.That(list.Tail.Previous.Data, Is.EqualTo(nodeZeroValue));
        Assert.That(list.Tail.Previous, Is.SameAs(list.Head));

        list.AddAtTail(nodeTwoValue);
        Assert.That(list.Count, Is.EqualTo(3));
        Assert.That(list.Head.Data, Is.EqualTo(nodeZeroValue));
        Assert.That(list.Tail.Data, Is.EqualTo(nodeTwoValue));
        Assert.That(list.Tail.Previous.Data, Is.EqualTo(nodeOneValue));

        list.AddAtTail(nodeThreeValue);
        Assert.That(list.Count, Is.EqualTo(4));
        Assert.That(list.Head.Data, Is.EqualTo(nodeZeroValue));
        Assert.That(list.Tail.Data, Is.EqualTo(nodeThreeValue));
        Assert.That(list.Tail.Previous.Data, Is.EqualTo(nodeTwoValue));
    }

    [Test]
    public void GetAtIndexOutOfRangeTest()
    {
        var list = new DoubleLinkedList();
        Assert.Throws<IndexOutOfRangeException>(() => list.GetAtIndex(-1));
        Assert.Throws<IndexOutOfRangeException>(() => list.GetAtIndex(7));
        Assert.Throws<IndexOutOfRangeException>(() => list.GetAtIndex(8));
    }

    [Test]
    public void GetAtIndexHeadTest()
    {
        var list = new DoubleLinkedList();
        for (int i = 0; i < 7; i++)
        {
            list.AddAtTail($"Node {i}");
        }
        Assert.That(list.GetAtIndex(0).Data, Is.EqualTo($"Node 0"));
    }

    [Test]
    public void GetAtIndexTailTest()
    {
        var list = new DoubleLinkedList();
        for (int i = 0; i < 7; i++)
        {
            list.AddAtTail($"Node {i}");
        }
        Assert.That(list.GetAtIndex(list.Count - 1).Data, Is.EqualTo($"Node 6"));
    }

    [Test]
    public void GetAtIndexTest()
    {
        var list = new DoubleLinkedList();
        for (int i = 0; i < 100; i++)
        {
            list.AddAtTail($"Node {i}");
        }
        for (int i = 0; i < 100; i++)
        {
            Assert.That(list.GetAtIndex(i).Data, Is.EqualTo($"Node {i}"));
        }
    }
}