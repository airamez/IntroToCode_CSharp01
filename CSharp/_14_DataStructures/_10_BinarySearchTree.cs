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
    root = null;
  }

  public void Add(int value)
  {
    if (root == null)
    {
      root = new Node(value);
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
    throw new NotImplementedException();
  }

  public List<int> TraverseInOrder()
  {
    var result = new List<int>();
    TraverseInOrder(root, result);
    return result;
  }

  private void TraverseInOrder(Node node, List<int> result)
  {
    if (node == null)
    {
      return;
    }
    TraverseInOrder(node.Left, result);
    result.Add(node.Data);
    TraverseInOrder(node.Right, result);
  }

  public List<int> TraversePreOrder()
  {
    throw new NotImplementedException();
  }

  public List<int> TraversePostOrder()
  {
    throw new NotImplementedException();
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