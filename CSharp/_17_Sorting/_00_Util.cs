using System;

namespace Sorting;

public class Util
{
    public static int[] GeneratedSortedArray(int length, int minValue, int maxValue)
    {
        Random random = new Random();
        var array = new int[length];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(minValue, maxValue);
        }

        return array;
    }

    public static void PrintArray(int[] array)
    {
        Console.Write("[");
        for (int i = 0; i < array.Length - 1; i++)
        {
            Console.Write($"{array[i]},");
        }
        Console.WriteLine($"{array[array.Length - 1]}]");
    }
}