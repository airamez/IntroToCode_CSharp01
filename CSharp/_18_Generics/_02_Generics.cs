using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace Generics;

public class GenericsApp
{
    public static void Main(string[] args)
    {
        var intNonGeneric = new MyNonGenericList(3);
        intNonGeneric.Add(1);
        intNonGeneric.Add(5);
        intNonGeneric.Add(10);
        Console.WriteLine($"{intNonGeneric.Get(0)}, {intNonGeneric.Get(1)}, {intNonGeneric.Get(2)}");


        var strNonGeneric = new MyGenericList<string>(3);
        strNonGeneric.Add("José");
        strNonGeneric.Add("Leila");
        strNonGeneric.Add("Artur");
        Console.WriteLine($"{strNonGeneric.Get(0)}, {strNonGeneric.Get(1)}, {strNonGeneric.Get(2)}");

        var intGeneric = new MyGenericList<int>(3);
        intGeneric.Add(1);
        intGeneric.Add(5);
        intGeneric.Add(10);
        Console.WriteLine($"{intGeneric.Get(0)}, {intGeneric.Get(1)}, {intGeneric.Get(2)}");

        var strGeneric = new MyGenericList<string>(3);
        strGeneric.Add("José");
        strGeneric.Add("Leila");
        strGeneric.Add("Artur");
        Console.WriteLine($"{strGeneric.Get(0)}, {strGeneric.Get(1)}, {strGeneric.Get(2)}");

        // Problem with Non Generic
        int n1 = (int)intNonGeneric.Get(0); // Must cast to int
        string s1 = (string)strNonGeneric.Get(0); // Must cast to string
        intNonGeneric.Add("Not an integer");
        // show the problem in a better way

        // Advantage of Generic
        int n2 = intGeneric.Get(1); // No cast need
        string s2 = strGeneric.Get(1); // No cast need

        // Example of a Generic Method
        Console.WriteLine($"n1: {n1}; n2: {n2}");
        Swap(ref n1, ref n2);
        Console.WriteLine($"n1: {n1}; n2: {n2}");

        Console.WriteLine($"s1: {s1}; s2: {s2}");
        Swap(ref s1, ref s2);
        Console.WriteLine($"s1: {s1}; s2: {s2}");

    }

    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }
}

public class MyNonGenericList
{
    private object[] data;
    private int index;

    public MyNonGenericList(int length)
    {
        data = new object[length];
        index = 0;
    }

    public void Add(object input)
    {
        data[index++] = input;
    }

    public object Get(int index)
    {
        return data[index];
    }
}

public class MyGenericList<T>
{

    private T[] data;
    private int index;

    public MyGenericList(int length)
    {
        data = new T[length];
        index = 0;
    }

    public void Add(T input)
    {
        data[index++] = input;
    }

    public T Get(int index)
    {
        return data[index];
    }

}