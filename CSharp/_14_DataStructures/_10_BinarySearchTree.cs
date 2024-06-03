using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
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