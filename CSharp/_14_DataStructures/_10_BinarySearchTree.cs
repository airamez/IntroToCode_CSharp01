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

  public BST()
  {
    root = null;
  }

  public void Add(int value)
  {
    throw new NotImplementedException();
  }

  public bool Exists(int value)
  {
    throw new NotImplementedException();
  }

  public List<int> TraverseInOrder()
  {
    throw new NotImplementedException();
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