using System;
namespace DataStructures.BinaryTree;

public class BinaryTreeApp
{
  public static void Main(string[] args)
  {
    Node root = new Node("A");
    root.Left = new Node("B");
    root.Right = new Node("C");
    root.Left.Left = new Node("D");
    root.Left.Right = new Node("E");
    root.Right.Left = new Node("F");
    root.Right.Right = new Node("G");
    root.Left.Left.Left = new Node("H");
    root.Left.Left.Right = new Node("I");
    root.Left.Right.Left = new Node("J");
    root.Left.Right.Right = new Node("K");
    root.Right.Left.Left = new Node("L");
    root.Right.Left.Right = new Node("M");
    root.Right.Right.Left = new Node("N");
    root.Right.Right.Right = new Node("O");

    TransversalInOrder(root);
  }

  public static void TransversalInOrder(Node node)
  {
    if (node == null)
    {
      return;
    }
    TransversalInOrder(node.Left);
    Console.Write($"{node.Data} ");
    TransversalInOrder(node.Right);
  }
}

public class Node
{
  public string Data { set; get; }
  public Node Left { set; get; }
  public Node Right { set; get; }

  public Node(string data)
  {
    this.Data = data;
    Left = null;
    Right = null;
  }
}