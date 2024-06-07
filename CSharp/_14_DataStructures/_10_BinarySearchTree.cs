/*
# Binary Search Tree (BST)
  # Definition:
    * A Binary Search Tree is a binary tree data structure where for all nodes: 
      * The left subtree’s keys are less than the node’s key, and
      * The right subtree’s keys are greater than the node’s key.
      * These properties apply recursively for all nodes in the tree.
  # Usage: 
    * BSTs are commonly used in computer science for efficient searching and sorting of data.
      They allow for fast lookup, addition, and removal of items, and can be used to implement
      dynamic sets and lookup tables.
    * OBS: A BST can be unbalanced and provide poor performance like a list
*/
using System;
using System.Collections.Generic;
using System.Linq;
namespace DataStructures.BinarySearchTree;

public class BinarySearchTreeApp
{
  public static void Main(string[] args)
  {
    var testData = new List<int> { 50, 25, 12, 35, 75, 65, 90, 85, 100, 47, 5, 6, 40, 49, 4, 89 };
    var bst = InitBST(testData);

    bst.RemoveRecursive(500);
    PrintByLevel(bst);

    bst.RemoveRecursive(4);
    PrintByLevel(bst);

    bst = InitBST(testData);
    bst.RemoveRecursive(49);
    PrintByLevel(bst);

    bst = InitBST(testData);
    bst.RemoveRecursive(12);
    PrintByLevel(bst);

    bst = InitBST(testData);
    bst.RemoveRecursive(25);
    PrintByLevel(bst);

    bst = InitBST(testData);
    bst.RemoveRecursive(50);
    PrintByLevel(bst);

    // Not initing any more

    bst.RemoveRecursive(12);
    PrintByLevel(bst);

    bst.RemoveRecursive(89);
    PrintByLevel(bst);

    bst.RemoveRecursive(5);
    PrintByLevel(bst);

    bst.RemoveRecursive(35);
    PrintByLevel(bst);

    bst.RemoveRecursive(75);
    PrintByLevel(bst);

    bst.RemoveRecursive(100);
    PrintByLevel(bst);

    bst.RemoveRecursive(65);
    PrintByLevel(bst);

    bst.RemoveRecursive(85);
    PrintByLevel(bst);

    bst.RemoveRecursive(25);
    PrintByLevel(bst);
  }

  private static BST InitBST(List<int> data)
  {
    Console.Clear();
    var bst = new BST();
    foreach (var value in data)
    {
      bst.Add(value);
    }
    PrintByLevel(bst);
    return bst;
  }

  private static void PrintByLevel(BST bst)
  {
    var allLevels = bst.TraversePerLevel();
    Console.WriteLine("".PadLeft(50, '-'));
    Console.WriteLine($"Count: {bst.Count}");
    for (int level = 0; level < allLevels.Count; level++)
    {
      Console.Write($"Level {level}: ");
      foreach (var value in allLevels[level])
      {
        Console.Write($"{value} ");
      }
      Console.WriteLine();
    }
  }

}

public class BST
{
  Node root { set; get; }

  public int Count { private set; get; }

  public BST()
  {
    Count = 0;
    root = null;
  }

  public void Add(int value)
  {
    if (root == null)
    {
      root = new Node(value);
      Count = 1;
    }
    else
    {
      Add(root, value);
    }
  }

  private void Add(Node node, int value)
  {
    if (node.Data != value)
    {
      if (value < node.Data)
      {
        if (node.Left == null)
        {
          node.Left = new Node(value);
          Count++;
        }
        else
        {
          Add(node.Left, value);
        }
      }
      else
      {
        if (node.Right == null)
        {
          node.Right = new Node(value);
          Count++;
        }
        else
        {
          Add(node.Right, value);
        }
      }
    }
  }

  public bool Exists(int value)
  {
    return Exists(root, value);
  }

  private bool Exists(Node node, int value)
  {
    if (node == null)
    {
      return false;
    }

    if (node.Data == value)
    {
      return true;
    }

    if (value < node.Data)
    {
      return Exists(node.Left, value);
    }
    else
    {
      return Exists(node.Right, value);
    }
  }

  public List<int> TraverseInOrder()
  {
    var result = new List<int>();
    TraverseInOrder(root, result);
    return result;
  }

  private void TraverseInOrder(Node node, List<int> result)
  {
    if (node != null)
    {
      TraverseInOrder(node.Left, result);
      result.Add(node.Data);
      TraverseInOrder(node.Right, result);
    }
  }

  public List<int> TraversePreOrder()
  {
    var result = new List<int>();
    TraversePreOrder(root, result);
    return result;
  }

  private void TraversePreOrder(Node node, List<int> result)
  {
    if (node != null)
    {
      result.Add(node.Data);
      TraversePreOrder(node.Left, result);
      TraversePreOrder(node.Right, result);
    }
  }

  public List<int> TraversePostOrder()
  {
    var result = new List<int>();
    TraversePostOrder(root, result);
    return result;

  }

  private void TraversePostOrder(Node node, List<int> result)
  {
    if (node != null)
    {
      TraversePostOrder(node.Left, result);
      TraversePostOrder(node.Right, result);
      result.Add(node.Data);
    }
  }

  public List<List<int>> TraversePerLevel()
  {
    var result = new List<List<int>>();
    TraversePerLevel(root, result);
    return result;
  }

  public void TraversePerLevel(Node root, List<List<int>> result)
  {
    if (root == null)
    {
      return;
    }
    result.Add(new List<int>());
    var currentLevel = new Queue<Node>();
    var nextLevel = new Queue<Node>();
    currentLevel.Enqueue(root);
    while (currentLevel.Count > 0)
    {
      var node = currentLevel.Dequeue();
      result.Last().Add(node.Data);
      if (node.Left != null)
      {
        nextLevel.Enqueue(node.Left);
      }
      if (node.Right != null)
      {
        nextLevel.Enqueue(node.Right);
      }
      if (currentLevel.Count == 0 && nextLevel.Count > 0)
      {
        result.Add(new List<int>());
        currentLevel = nextLevel;
        nextLevel = new Queue<Node>();
      }
    }
  }

  public void RemoveRecursive(int value)
  {
    if (RemoveRecursive(root, value) != null)
    {
      Count--;
    }
  }

  private Node RemoveRecursive(Node node, int value)
  {
    if (node == null)
    {
      return null;
    }
    if (value < node.Data)
    {
      node.Left = RemoveRecursive(node.Left, value);
    }
    else if (value > node.Data)
    {
      node.Right = RemoveRecursive(node.Right, value);
    }
    else
    {
      if (node.Left == null)
      {
        return node.Right;
      }
      else if (node.Right == null)
      {
        return node.Left;
      }
      node.Data = GetSuccessor(node.Right);
      node.Right = RemoveRecursive(node.Right, node.Data);
    }
    return node;
  }

  public void RemoveNonRecursive(int value)
  {
    Remove(root, value);
  }

  private void Remove(Node node, int value)
  {
    if (node == null)
    {
      return;
    }

    Node target = node;
    Node parent = node;
    bool isTargetLeftChild = true; // flag to indicate if the target is on left o right

    while (target.Data != value)
    {
      parent = target; // set parent to current because we will move current one level down
      if (value < target.Data)  // Move left
      {
        target = target.Left;
        isTargetLeftChild = true;
      }
      else // Move right
      {
        target = target.Right;
        isTargetLeftChild = false;
      }
      if (target == null) // Value not found
        return;
    }

    // Case 1: leaf
    if (target.Left == null && target.Right == null)
    {
      Count--;
      if (target == root) // Checking removing root
        root = null;
      else if (isTargetLeftChild) // Set the parent left to null
        parent.Left = null;
      else // set the partent right to null
        parent.Right = null;
    }
    // Case 2: One child
    else if (target.Right == null) // Has a subtree on Left
    {
      Count--;
      if (target == root) // If removing root
        root = target.Left;
      else if (isTargetLeftChild) // If the target node is on left of its parent
        parent.Left = target.Left;
      else // If the target node is on the right of its parent
        parent.Right = target.Left;
    }
    else if (target.Left == null) // Has a subtree on Right
    {
      Count--;
      if (target == root) // If removing root
        root = target.Right;
      else if (isTargetLeftChild) // If the target node is on the left of its parent
        parent.Left = target.Right;
      else // If atrget node is on the right of its parent
        parent.Right = target.Right;
    }
    // Case 3: Both children
    else
    {
      var successor = GetSuccessor(target); // Find the node to replace the target one
      Remove(target, successor);
      target.Data = successor;
    }
  }

  private int GetSuccessor(Node target)
  {
    Node successor = target;
    Node current = target.Right; // runner
    while (current != null)
    {
      successor = current;
      current = current.Left; // move left
    }
    return successor.Data;
  }
}

public class Node
{
  public int Data { set; get; }
  public Node Left { set; get; }
  public Node Right { set; get; }

  public Node(int data)
  {
    Data = data;
    Left = null;
    Right = null;
  }
}