using System;

public class BinarySearchApp
{
    public static void Main(string[] args)
    {
        int[] input = [3, 10, 17, 22, 30, 35, 41, 53, 61, 63, 71, 85, 89, 91, 95, 99];

        Console.WriteLine(BinarySearch(input, 10));
        Console.WriteLine(BinarySearch(input, 95));
        Console.WriteLine(BinarySearch(input, 53));
        Console.WriteLine(BinarySearch(input, 22));
        Console.WriteLine(BinarySearch(input, 71));
        Console.WriteLine(BinarySearch(input, 91));
        Console.WriteLine(BinarySearch(input, 22));

        Console.WriteLine(BinarySearch(input, 1));
        Console.WriteLine(BinarySearch(input, 5));
        Console.WriteLine(BinarySearch(input, 15));
        Console.WriteLine(BinarySearch(input, 25));
        Console.WriteLine(BinarySearch(input, 62));
        Console.WriteLine(BinarySearch(input, 90));
        Console.WriteLine(BinarySearch(input, 99));
        Console.WriteLine(BinarySearch(input, 100));
    }

    public static int BinarySearch(int[] array, int target)
    {
        return -1;
    }
}