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
namespace DataStructures.BinarySearchTree;

public class BinarySearchTreeApp
{
  public static void Main(string[] args)
  {
    var bst = new BST();
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
    throw new NotImplementedException();
  }

  public void Remove(int value)
  {
    throw new NotImplementedException();
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