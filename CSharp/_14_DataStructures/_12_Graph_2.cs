using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Channels;
using NUnit.Framework.Constraints;


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

        // GetPathDFS
        PrintGetPathDFS(graph, "A", "B");
        PrintGetPathDFS(graph, "A", "C");
        PrintGetPathDFS(graph, "A", "E");
        PrintGetPathDFS(graph, "A", "I");
        PrintGetPathDFS(graph, "A", "J");
        PrintGetPathDFS(graph, "A", "L");
        PrintGetPathDFS(graph, "A", "N");
        PrintGetPathDFS(graph, "J", "I");
        PrintGetPathDFS(graph, "J", "K");
        PrintGetPathDFS(graph, "K", "B");
        PrintGetPathDFS(graph, "K", "I");
        PrintGetPathDFS(graph, "K", "H");
        PrintGetPathDFS(graph, "K", "C");

        PrintGetPathDFS(graph, "O", "C");
        PrintGetPathDFS(graph, "O", "A");

        // GetPathBFS
        Console.WriteLine();
        PrintGetPathBFS(graph, "A", "B");
        PrintGetPathBFS(graph, "A", "C");
        PrintGetPathBFS(graph, "A", "E");
        PrintGetPathBFS(graph, "A", "I");
        PrintGetPathBFS(graph, "A", "J");
        PrintGetPathBFS(graph, "A", "L");
        PrintGetPathBFS(graph, "A", "N");
        PrintGetPathBFS(graph, "J", "I");
        PrintGetPathBFS(graph, "J", "K");
        PrintGetPathBFS(graph, "K", "B");
        PrintGetPathBFS(graph, "K", "I");
        PrintGetPathBFS(graph, "K", "H");
        PrintGetPathBFS(graph, "K", "C");

        PrintGetPathBFS(graph, "O", "C");
        PrintGetPathBFS(graph, "O", "A");

        // Has Cycle
        Console.WriteLine("Has cycle");
        Console.WriteLine($"All: {graph.HasCycle()}");
        foreach (var letter in "ABCDEFGHIJKLMNO")
        {
            Console.WriteLine($"{letter}: {graph.HasCycle(letter.ToString())}");
        }
    }

    private static void PrintGetPathDFS(MyGraph graph, string source, string target)
    {
        Console.Write($"GetPathDFS {source} to {target}: ");
        List<Node> path = graph.GetPathDFS(source, target);
        if (path.Count == 0)
        {
            Console.Write("No path");
        }
        else
        {
            path.ForEach(n => Console.Write($"{n.Data} "));
        }
        Console.WriteLine();
    }

    private static void PrintGetPathBFS(MyGraph graph, string source, string target)
    {
        List<Node> path;
        Console.Write($"GetPathBFS {source} to {target}: ");
        path = graph.GetPathBFS(source, target);
        if (path.Count == 0)
        {
            Console.Write("No path");
        }
        else
        {
            path.ForEach(n => Console.Write($"{n.Data} "));
        }
        Console.WriteLine();
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
        var visited = new HashSet<Node>();
        var nodes = FindNodes(sourceData, targetData);
        return HasPathDFS(nodes.Source, nodes.Target, visited);
    }

    private bool HasPathDFS(Node current, Node target, HashSet<Node> visited)
    {
        if (current.Data.Equals(target.Data))
        {
            return true;
        }
        visited.Add(current);
        foreach (var adjacent in current.Adjacents.OrderBy(n => n.Data))
        {
            if (!visited.Contains(adjacent)) // if not visited
            {
                if (HasPathDFS(adjacent, target, visited))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool HasPathBFS(string sourceData, string targetData)
    {
        var visited = new HashSet<Node>();
        var nodes = FindNodes(sourceData, targetData);
        var toVisit = new Queue<Node>();
        toVisit.Enqueue(nodes.Source);
        while (toVisit.Count > 0)
        {
            var current = toVisit.Dequeue();
            if (current.Data.Equals(nodes.Target.Data))
            {
                return true;
            }
            visited.Add(current);
            foreach (var adjacent in current.Adjacents.OrderBy(n => n.Data))
            {
                if (!visited.Contains(adjacent))
                {
                    toVisit.Enqueue(adjacent);
                }
            }
        }
        return false;
    }

    public List<Node> GetPathDFS(string sourceData, string targetData)
    {
        var visited = new HashSet<Node>();
        var path = new List<Node>();
        var nodes = FindNodes(sourceData, targetData);
        GetPathDFS(nodes.Source, nodes.Target, visited, path);
        return path;
    }

    private bool GetPathDFS(Node current, Node target, HashSet<Node> visited, List<Node> path)
    {
        if (current.Data.Equals(target.Data))
        {
            path.Insert(0, current);
            return true;
        }
        visited.Add(current);
        foreach (var adjacent in current.Adjacents.OrderBy(n => n.Data))
        {
            if (!visited.Contains(adjacent)) // if not visited
            {
                if (GetPathDFS(adjacent, target, visited, path))
                {
                    path.Insert(0, current);
                    return true;
                }
            }
        }
        return false;
    }

    public List<Node> GetPathBFS(string sourceData, string targetData)
    {
        var visitingOrder = new Dictionary<Node, Node>();
        var visited = new HashSet<Node>();
        var nodes = FindNodes(sourceData, targetData);
        var toVisit = new Queue<Node>();
        toVisit.Enqueue(nodes.Source);
        visitingOrder[nodes.Source] = null;
        bool foundTarget = false;
        while (toVisit.Count > 0)
        {
            var current = toVisit.Dequeue();
            if (current.Data.Equals(nodes.Target.Data))
            {
                foundTarget = true;
                break;
            }
            visited.Add(current);
            foreach (var adjacent in current.Adjacents.OrderBy(n => n.Data))
            {
                if (!visited.Contains(adjacent))
                {
                    toVisit.Enqueue(adjacent);
                    visitingOrder[adjacent] = current;
                }
            }
        }
        var path = new List<Node>();
        if (foundTarget)
        {
            BuildPath(visitingOrder, nodes, path);
        }
        return path;
    }

    private static void BuildPath(Dictionary<Node, Node> visitingOrder, (Node Source, Node Target) nodes, List<Node> path)
    {
        var runner = nodes.Target;
        while (runner != null)
        {
            path.Insert(0, runner);
            runner = visitingOrder[runner];
        }
    }


    public bool HasCycle(string startingAt)
    {
        var node = Nodes[startingAt];
        if (node == null)
        {
            throw new Exception("Value not found in the Graph");
        }
        var visited = new HashSet<Node>();
        var visiting = new HashSet<Node>();
        return HasCycle(node, visited, visiting);
    }

    public bool HasCycle()
    {
        var visited = new HashSet<Node>();
        var visiting = new HashSet<Node>();
        foreach (var node in Nodes.Values)
        {
            if (HasCycle(node, visited, visiting))
            {
                return true;
            }
        }
        return false;
    }

    private bool HasCycle(Node node, HashSet<Node> visited, HashSet<Node> visiting)
    {
        if (visiting.Contains(node))
        {
            return true;
        }
        if (!visited.Contains(node))
        {
            visited.Add(node);
            visiting.Add(node);
            foreach (var adjacent in node.Adjacents)
            {
                if (HasCycle(adjacent, visited, visiting))
                {
                    return true;
                }
            }
            // This is the trick; The recursion will remove the current from visiting
            // after visiting all its adjacents
            visiting.Remove(node);
        }
        return false;
    }
}