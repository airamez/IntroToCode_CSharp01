using System;
using System.Collections.Generic;

namespace DataStructures.Graph.Weighted;

public class WeightedGraphApp
{
    public static void Main(string[] args)
    {
        MyWeightedGraph graph = new MyWeightedGraph();
        graph.Add("A");
        graph.Add("B");
        graph.Add("C");
        graph.Add("D");
        graph.Add("E");
        graph.Add("F");
        graph.Connect("A", "B", 10);
        graph.Connect("A", "C", 8);
        graph.Connect("A", "D", 15);
        graph.Connect("B", "D", 7);
        graph.Connect("C", "D", 5);
        graph.Connect("C", "E", 10);
        graph.Connect("D", "E", 1);
        graph.Connect("D", "F", 3);
        graph.Connect("E", "F", 2);
        graph.Print();
        Console.WriteLine($"[A=>B]: {graph.GetShortetsDistance("A", "B")}");
        Console.WriteLine($"[A=>C]: {graph.GetShortetsDistance("A", "C")}");
        Console.WriteLine($"[A=>D]: {graph.GetShortetsDistance("A", "D")}");
        Console.WriteLine($"[A=>E]: {graph.GetShortetsDistance("A", "E")}");
        Console.WriteLine($"[A=>F]: {graph.GetShortetsDistance("A", "F")}");

        Console.WriteLine($"[B=>B]: {graph.GetShortetsDistance("B", "B")}");
        Console.WriteLine($"[B=>D]: {graph.GetShortetsDistance("B", "D")}");
        Console.WriteLine($"[B=>E]: {graph.GetShortetsDistance("B", "E")}");
        Console.WriteLine($"[B=>F]: {graph.GetShortetsDistance("B", "F")}");

        Console.WriteLine($"[D=>E]: {graph.GetShortetsDistance("D", "E")}");
        Console.WriteLine($"[D=>F]: {graph.GetShortetsDistance("D", "F")}");

        try
        {
            Console.WriteLine($"[F=>A]: {graph.GetShortetsDistance("F", "A")}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

public class Edge
{
    public int Weight { set; get; }
    public Node Adjacent { set; get; }

    public Edge(Node adjacent, int weight)
    {
        Weight = weight;
        Adjacent = adjacent;
    }
}

public class Node : IComparable
{
    public string Data { set; get; }
    public List<Edge> Edges { private set; get; }

    public Node(string data)
    {
        Data = data;
        Edges = new List<Edge>();
    }

    public int CompareTo(object obj)
    {
        var other = obj as Node;
        if (other == null)
        {
            return -1;
        }
        else
        {
            return Data.CompareTo(other.Data);
        }
    }
}

public class MyWeightedGraph
{
    public Dictionary<string, Node> Nodes;

    public MyWeightedGraph()
    {
        Nodes = new Dictionary<string, Node>();
    }

    public void Add(string value)
    {
        if (Nodes.ContainsKey(value))
        {
            throw new Exception($"Value already exist in the grap: {value}");
        }
        Nodes[value] = new Node(value);
    }

    public void Connect(string sourceValue, string targetValue, int weight)
    {
        var source = GetNode(sourceValue);
        var target = GetNode(targetValue);
        source.Edges.Add(new Edge(target, weight));
    }

    private Node GetNode(string value)
    {
        var node = Nodes[value];
        if (node == null)
        {
            throw new Exception($"No node found with the data: {value}");
        }
        return node;
    }

    public void Print()
    {
        foreach (var node in Nodes.Values)
        {
            Console.Write($"{node.Data}: ");
            foreach (var edge in node.Edges)
            {
                Console.Write($"[{edge.Weight}=>{edge.Adjacent.Data}] ");
            }
            Console.WriteLine();
        }
    }

    public int GetShortetsDistance(string sourceValue, string targetValue)
    {
        var visited = new HashSet<Node>();
        var source = GetNode(sourceValue);
        var target = GetNode(targetValue);
        var weightTable = new Dictionary<Node, int>();
        foreach (var node in Nodes.Values)
        {
            weightTable[node] = int.MaxValue;
        }
        weightTable[source] = 0;
        var toVisit = new PriorityQueue<Node, int>();
        toVisit.Enqueue(source, 0);
        while (toVisit.Count > 0)
        {
            var current = toVisit.Dequeue();
            if (visited.Contains(current))
            {
                continue;
            }
            visited.Add(current);
            var currentWeight = weightTable[current];
            foreach (var edge in current.Edges)
            {
                int weightFromTable = weightTable[edge.Adjacent];
                int candidateWeight = Math.Min(weightFromTable, currentWeight + edge.Weight);
                weightTable[edge.Adjacent] = candidateWeight;
                if (!visited.Contains(edge.Adjacent))
                {
                    toVisit.Enqueue(edge.Adjacent, weightTable[edge.Adjacent]);
                }
            }
        }
        if (weightTable[target].Equals(int.MaxValue))
        {
            string msg = $"Node ({targetValue}) is not reachable from Source ({sourceValue})";
            throw new Exception(msg);
        }
        return weightTable[target];
    }
}