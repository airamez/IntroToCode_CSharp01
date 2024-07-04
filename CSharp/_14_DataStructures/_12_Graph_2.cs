using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;


namespace DataStructures.Graph;

public class MyGraphApp
{
    public static void Main(string[] args)
    {
        MyGraph graph = new MyGraph();
        foreach (var letter in "ABCDEFGHIJKLMNO")
        {
            graph.Add(letter.ToString());
        }
        graph.Connect("A", "B");
        graph.Connect("A", "C");
        graph.Connect("B", "C");
        graph.Connect("B", "E");
        graph.Connect("C", "B");
        graph.Connect("D", "A");
        graph.Connect("D", "G");
        graph.Connect("E", "B");
        graph.Connect("E", "J");
        graph.Connect("F", "G");
        graph.Connect("F", "I");
        graph.Connect("G", "D");
        graph.Connect("G", "E");
        graph.Connect("H", "L");
        graph.Connect("I", "G");
        graph.Connect("J", "F");
        graph.Connect("J", "N");
        graph.Connect("K", "J");
        graph.Connect("K", "N");
        graph.Connect("L", "O");
        graph.Connect("M", "H");
        graph.Connect("O", "M");
        graph.Print();
    }
}

public class Node
{
    public string Data { private set; get; }
    public HashSet<Node> Adjacents { private set; get; }

    public Node(string data)
    {
        Data = data;
        Adjacents = new HashSet<Node>();
    }

    public void Connect(Node node)
    {
        Adjacents.Add(node);
    }

    public void Disconnect(Node node)
    {
        Adjacents.Remove(node);
    }

    public override bool Equals(object other)
    {
        Node otherNode = other as Node;
        return otherNode == null ? false : otherNode.Data.Equals(Data);
    }

    public override int GetHashCode()
    {
        return Data.GetHashCode();
    }

    public override string ToString()
    {
        return Data;
    }
}

public class MyGraph
{
    private Dictionary<string, Node> Nodes;

    public MyGraph()
    {
        Nodes = new Dictionary<string, Node>();
    }

    public void Add(string data)
    {
        if (Nodes.ContainsKey(data))
        {
            throw new Exception("$There is a node with the data {data} already");
        }
        var newNode = new Node(data);
        Nodes.Add(newNode.Data, newNode);
    }

    public bool Remove(string data)
    {
        Node nodeToRemove = Nodes[data];
        if (nodeToRemove != null)
        {
            foreach (Node node in Nodes.Values)
            {
                node.Disconnect(nodeToRemove);
            }
        }
        return Nodes.Remove(data);
    }

    public void Connect(string sourceNodeData, string targetNodeData)
    {
        if (string.IsNullOrWhiteSpace(sourceNodeData) ||
            string.IsNullOrWhiteSpace(targetNodeData))
        {
            string msg = $"Data can't be null";
            throw new Exception(msg);
        }
        if (sourceNodeData == targetNodeData)
        {
            var msg = $"Connecting a node to itself is not allowed: {sourceNodeData}";
            throw new Exception(msg);
        }
        var nodes = FindNodes(sourceNodeData, targetNodeData);
        nodes.Source.Connect(nodes.Target);
    }

    public void Disconnect(string sourceNodeData, string targetNodeData)
    {
        var nodes = FindNodes(sourceNodeData, targetNodeData);
        nodes.Source.Disconnect(nodes.Target);
    }

    private (Node Source, Node Target) FindNodes(string sourceNodeData, string targetNodeData)
    {
        var sourceNode = Nodes[sourceNodeData];
        var targetNode = Nodes[targetNodeData];
        if (sourceNode == null)
        {
            throw new Exception($"Source node not found: {sourceNodeData}");
        }
        if (targetNode == null)
        {
            throw new Exception($"Target node not found: {targetNodeData}");
        }
        return (sourceNode, targetNode);
    }

    public void Print()
    {
        Console.WriteLine();
        foreach (var node in Nodes.Values.OrderBy(n => n.Data))
        {
            Console.Write($"{node} => [ ");
            foreach (var adjacent in node.Adjacents)
            {
                Console.Write($"{adjacent} ");
            }
            Console.WriteLine("]");
        }
    }
}