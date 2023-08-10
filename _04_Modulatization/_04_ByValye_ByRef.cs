using System;

public class ParameterByValueByRef
{

    public static void Main(string[] args)
    {
        int a = 1;
        int b = 2;
        Console.WriteLine($"a = {a}; b = {b}");

        SwapByValue(a, b);
        Console.WriteLine($"a = {a}; b = {b}");

        SwapByRef(ref a, ref b);
        Console.WriteLine($"a = {a}; b = {b}");
    }

    public static void SwapByValue(int a, int b)
    {
        int aux = a;
        a = b;
        b = aux;
    }

    public static void SwapByRef(ref int a, ref int b)
    {
        int aux = a;
        a = b;
        b = aux;
    }
}