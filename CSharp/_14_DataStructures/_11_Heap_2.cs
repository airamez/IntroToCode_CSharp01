using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Heap;

public class MyHeapApp
{
    public static void Main(string[] args)
    {
        int[] data = { 5, 70, 4, 2, 30, 11, 81, 7, 84, 15, 75, 85, 28, 90, 80 };
        var myHeap = new MyHeap(data);
        myHeap.Print();
    }
}

public class MyHeap
{
    private List<int> Data;

    public MyHeap(int[] data = null)
    {
        if (data == null)
        {
            Data = new List<int>();
        }
        else
        {
            Data = data.ToList();
            Heapify();
        }
    }


    private void Heapify()
    {
        /*
            Heapify up each node
            On every swap heapify down        
        */
        for (int i = Data.Count - 1; i >= 0; i--)
        {
            Heapify(i);
        }
    }

    private void Heapify(int index)
    {
        var childrenIndexes = GetChildrenIndexes(index);
        int greaterIndex = index;
        if (childrenIndexes.Left < Data.Count && Data[childrenIndexes.Left] > Data[greaterIndex])
        {
            greaterIndex = childrenIndexes.Left;
        }
        if (childrenIndexes.Right < Data.Count && Data[childrenIndexes.Right] > Data[greaterIndex])
        {
            greaterIndex = childrenIndexes.Right;
        }
        if (index != greaterIndex)
        { // We found a greater chield value
            Swap(index, greaterIndex);
            Heapify(greaterIndex);
        }
    }

    private void Swap(int left, int right)
    {
        int aux = Data[left];
        Data[left] = Data[right];
        Data[right] = aux;
    }

    private (int Left, int Right) GetChildrenIndexes(int index)
    {
        return (index * 2 + 1, index * 2 + 2);
    }

    public void Add(int value)
    {
        /*
            Add leaf and check-heap up
        */
        throw new NotImplementedException();
    }

    public int Pop()
    {
        /*
            Save root value to return
            Set root to -infinite
            Heapify down
            Remove the node with -infinite
          */
        throw new NotImplementedException();
    }

    public void Print()
    {
        Console.WriteLine();
        foreach (int value in Data)
        {
            Console.Write($"{value} ");
        }
        Console.WriteLine();
    }
}