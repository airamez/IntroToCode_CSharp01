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
        graph.Connect("F", "E");
        graph.Connect("G", "D");
        graph.Connect("G", "E");
        graph.Connect("H", "L");
        graph.Connect("I", "F");
        graph.Connect("I", "G");
        graph.Connect("I", "K");
        graph.Connect("I", "J");
        graph.Connect("J", "F");
        graph.Connect("J", "N");
        graph.Connect("K", "J");
        graph.Connect("K", "N");
        graph.Connect("L", "O");
        graph.Connect("M", "H");
        graph.Connect("N", "E");
        graph.Connect("O", "M");
        graph.Print();
        graph.Connect("O", "A");
        graph.Connect("O", "B");
        graph.Connect("O", "C");
        graph.Connect("O", "D");
        graph.Connect("O", "E");
        Console.WriteLine("O Adjacentes");
        graph.GetAdjacents("O").ForEach(Console.WriteLine);
        graph.Print();
        graph.Disconnect("O", "A");
        graph.Disconnect("O", "B");
        graph.Disconnect("O", "C");
        graph.Disconnect("O", "D");
        graph.Disconnect("O", "E");
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

    public int EdgesCount { private set; get; }

    public MyGraph()
    {
        Nodes = new Dictionary<string, Node>();
        EdgesCount = 0;
    }

    public void Add(string data)
    {
        if (Nodes.ContainsKey(data))
        {
            throw new Exception($"There is a node with the data {data} already");
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
        var nodes = FindNodes(sourceNodeData, targetNodeData);
        nodes.Source.Connect(nodes.Target);
        EdgesCount++;
    }

    public void Disconnect(string sourceNodeData, string targetNodeData)
    {
        var nodes = FindNodes(sourceNodeData, targetNodeData);
        nodes.Source.Disconnect(nodes.Target);
        EdgesCount--;
    }

    public List<string> GetAdjacents(string data)
    {
        var node = Nodes[data];
        if (node == null)
        {
            throw new Exception($"Node not found: {data}");
        }
        var adjacents = new List<string>();
        node.Adjacents.ToList().ForEach(adj => adjacents.Add(adj.Data));
        return adjacents;
    }

    private (Node Source, Node Target) FindNodes(string sourceNodeData, string targetNodeData)
    {
        if (string.IsNullOrWhiteSpace(sourceNodeData) ||
            string.IsNullOrWhiteSpace(targetNodeData))
        {
            string msg = $"Data can't be null: [{sourceNodeData}] [{targetNodeData}]";
            throw new Exception(msg);
        }
        if (sourceNodeData == targetNodeData)
        {
            var msg = $"Connecting/Disconnecting a node to itself is not allowed: {sourceNodeData}";
            throw new Exception(msg);
        }
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
        Console.WriteLine($"Nodes: {Nodes.Count}; Edges: {EdgesCount}");
        foreach (var node in Nodes.Values.OrderBy(n => n.Data))
        {
            Console.Write($"{node} => [ ");
            foreach (var adjacent in node.Adjacents.OrderBy(n => n.Data))
            {
                Console.Write($"{adjacent} ");
            }
            Console.WriteLine("]");
        }
    }
}