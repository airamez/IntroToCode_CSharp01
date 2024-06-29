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
    public MyHeap(int[] data)
    {
    }

    public void Add(int value)
    {
        throw new NotImplementedException();
    }

    public int Pop()
    {
        throw new NotImplementedException();
    }

    public void Heapify()
    {
        throw new NotImplementedException();
    }

    public void Print()
    {
        throw new NotImplementedException();
    }
}