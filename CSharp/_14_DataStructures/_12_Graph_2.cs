using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Channels;


namespace DataStructures.Graph;

public class MyGraphApp
{
    public static void Main(string[] args)
    {
        MyGraph graph = new MyGraph();
        "ABCDEFGHIJKLMNO".ToList().ForEach(letter => graph.Add(letter.ToString()));
        graph.Print();

        graph.Connect("A", "B");
        graph.Connect("A", "C");
        graph.Connect("A", "D");
        graph.Connect("A", "E");
        graph.Connect("B", "D");
        graph.Connect("B", "F");
        graph.Connect("D", "C");
        graph.Connect("E", "B");
        graph.Connect("E", "D");
        graph.Connect("F", "G");
        graph.Connect("F", "E");
        graph.Connect("G", "H");
        graph.Connect("H", "K");
        graph.Connect("I", "H");
        graph.Connect("J", "B");
        graph.Connect("J", "F");
        graph.Connect("J", "I");
        graph.Connect("K", "J");
        graph.Connect("L", "M");
        graph.Connect("M", "D");
        graph.Connect("M", "O");
        graph.Connect("N", "L");
        graph.Connect("O", "N");
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

        // HasPathDFS
        Console.WriteLine($"HasPath[A to B]: {graph.HasPathDFS("A", "B")}");
        Console.WriteLine($"HasPath[A to C]: {graph.HasPathDFS("A", "C")}");
        Console.WriteLine($"HasPath[A to E]: {graph.HasPathDFS("A", "E")}");
        Console.WriteLine($"HasPath[A to I]: {graph.HasPathDFS("A", "I")}");
        Console.WriteLine($"HasPath[A to J]: {graph.HasPathDFS("A", "J")}");

        Console.WriteLine($"HasPath[A to L]: {graph.HasPathDFS("A", "L")}");
        Console.WriteLine($"HasPath[A to N]: {graph.HasPathDFS("A", "N")}");

        Console.WriteLine($"HasPath[O to C]: {graph.HasPathDFS("O", "C")}");
        Console.WriteLine($"HasPath[O to A]: {graph.HasPathDFS("O", "A")}");

        Console.WriteLine();

        // HasPathBFS
        Console.WriteLine($"HasPath[A to B]: {graph.HasPathBFS("A", "B")}");
        Console.WriteLine($"HasPath[A to C]: {graph.HasPathBFS("A", "C")}");
        Console.WriteLine($"HasPath[A to E]: {graph.HasPathBFS("A", "E")}");
        Console.WriteLine($"HasPath[A to I]: {graph.HasPathBFS("A", "I")}");
        Console.WriteLine($"HasPath[A to J]: {graph.HasPathBFS("A", "J")}");

        Console.WriteLine($"HasPath[A to L]: {graph.HasPathBFS("A", "L")}");
        Console.WriteLine($"HasPath[A to N]: {graph.HasPathBFS("A", "N")}");

        Console.WriteLine($"HasPath[O to C]: {graph.HasPathBFS("O", "C")}");
        Console.WriteLine($"HasPath[O to A]: {graph.HasPathBFS("O", "A")}");
    }
}

public enum VisitingStatus
{
    NOT_VISITED,
    VISITING,
    VISITED
}

public class Node
{
    public string Data { private set; get; }

    public HashSet<Node> Adjacents { private set; get; }

    public VisitingStatus VisitingStatus { set; get; }

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

    public List<Node> GetAdjacents(string data)
    {
        var node = Nodes[data];
        if (node == null)
        {
            throw new Exception($"Node not found: {data}");
        }
        return node.Adjacents.OrderBy(n => node.Data).ToList();
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

    public bool HasPathDFS(string sourceData, string targetData)
    {
        Nodes.Values.ToList().ForEach(n => n.VisitingStatus = VisitingStatus.NOT_VISITED);
        var nodes = FindNodes(sourceData, targetData);
        return HasPathDFS(nodes.Source, nodes.Target);
    }

    private bool HasPathDFS(Node current, Node target)
    {
        current.VisitingStatus = VisitingStatus.VISITED;
        if (current.Data.Equals(target.Data))
        {
            return true;
        }
        foreach (var node in current.Adjacents)
        {
            if (node.VisitingStatus == VisitingStatus.NOT_VISITED)
            {
                if (HasPathDFS(node, target))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool HasPathBFS(string sourceData, string targetData)
    {
        Nodes.Values.ToList().ForEach(n => n.VisitingStatus = VisitingStatus.NOT_VISITED);
        var nodes = FindNodes(sourceData, targetData);
        var toVisit = new Queue<Node>();
        toVisit.Enqueue(nodes.Source);
        while (toVisit.Count > 0)
        {
            var node = toVisit.Dequeue();
            if (node.VisitingStatus == VisitingStatus.NOT_VISITED)
            {
                node.VisitingStatus = VisitingStatus.VISITED;
                if (node.Data.Equals(nodes.Target.Data))
                {
                    return true;
                }
                foreach (var adjacent in node.Adjacents)
                {
                    toVisit.Enqueue(adjacent);
                }
            }
        }
        return false;
    }
}