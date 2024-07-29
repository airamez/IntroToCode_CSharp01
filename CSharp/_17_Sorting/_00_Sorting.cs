using System;
using System.Diagnostics;
using Exceptions;

namespace Sorting;

public class SortingApp
{
    const int LENGTH = 50;
    const int MIN = 0;
    const int MAX = 100;

    public static void Main(string[] args)
    {
        var stopwatch = new Stopwatch();

        var input = GeneratedSortedArray(LENGTH, MIN, MAX);
        Console.WriteLine($"Is Sorted Input: {IsSorted(input)}");


        stopwatch.Start();
        var sortedBubble = Bubble((int[])input.Clone());
        Console.WriteLine($"\nBubble Sort Execution time: {stopwatch.Elapsed}");
        Console.WriteLine($"Is Sorted: {IsSorted(sortedBubble)}");
        PrintArray(sortedBubble);

        Console.WriteLine();

        stopwatch.Restart();
        var sortedSelection = Selecion((int[])input.Clone());
        Console.WriteLine($"\nSelection Sort Execution time: {stopwatch.Elapsed}");
        Console.WriteLine($"Is Sorted: {IsSorted(sortedSelection)}");
        PrintArray(sortedSelection);

        stopwatch.Restart();
        var sortedInsertion = Insertion((int[])input.Clone());
        Console.WriteLine($"\nInsertion Sorte Execution time: {stopwatch.Elapsed}");
        Console.WriteLine($"Is Sorted: {IsSorted(sortedInsertion)}");
        PrintArray(sortedInsertion);

        stopwatch.Restart();
        var sortedMerge = Merge((int[])input.Clone());
        Console.WriteLine($"\nMerge Execution time: {stopwatch.Elapsed}");
        Console.WriteLine($"Is Sorted: {IsSorted(sortedMerge)}");
        PrintArray(sortedMerge);

        stopwatch.Restart();
        var sortedQuick = Quick((int[])input.Clone());
        Console.WriteLine($"\nQuick Sort Execution time: {stopwatch.Elapsed}");
        Console.WriteLine($"Is Sorted: {IsSorted(sortedQuick)}");
        PrintArray(sortedQuick);

        stopwatch.Restart();
        var sortedHeap = Heap((int[])input.Clone());
        Console.WriteLine($"\nHeap Sort Execution time: {stopwatch.Elapsed}");
        Console.WriteLine($"Is Sorted: {IsSorted(sortedHeap)}");
        PrintArray(sortedHeap);
    }

    public static int[] Bubble(int[] array)
    {
        int limit = array.Length - 1;
        while (true)
        {
            bool swapped = false;
            for (int i = 0; i < limit; i++)
            {
                if (array[i] > array[i + 1])
                {
                    Swap(array, i, i + 1);
                    swapped = true;
                }
            }
            limit--;
            if (!swapped)
            {
                break;
            }
        }
        return array;
    }

    public static int[] Selecion(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[minIndex])
                    minIndex = j;
            }
            Swap(array, i, minIndex);
        }
        return array;
    }

    public static int[] Insertion(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int current = array[i];
            int j = i - 1;
            while (j >= 0 && current < array[j])
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = current;
        }
        return array;
    }

    public static int[] Merge(int[] array)
    {
        return array;
    }

    public static int[] Quick(int[] array)
    {
        Quick_Sort(array, 0, array.Length - 1);
        return array;
    }

    private static void Quick_Sort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(array, left, right);
            Quick_Sort(array, left, pivot - 1);
            Quick_Sort(array, pivot + 1, right);
        }
    }

    private static int Partition(int[] array, int left, int right)
    {
        int pivot = array[right];
        int i = left - 1;
        for (int j = left; j < right; j++)
        {
            if (array[j] < pivot)
            {
                i++;
                Swap(array, i, j);
            }
        }
        Swap(array, i + 1, right);
        return i + 1;
    }

    public static int[] Heap(int[] array)
    {
        return array;
    }

    public static void Swap(int[] array, int left, int right)
    {
        int aux = array[left];
        array[left] = array[right];
        array[right] = aux;
    }

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

    public static bool IsSorted(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] > array[i + 1])
            {
                return false;
            }
        }
        return true;
    }
}