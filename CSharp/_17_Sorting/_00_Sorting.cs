using System;
using System.Diagnostics;
using DataStructures.Heap;
using Exceptions;

namespace Sorting;

public class SortingApp
{
    const int LENGTH = 100;
    const int MIN = 0;
    const int MAX = 1000;

    public static void Main(string[] args)
    {
        var stopwatch = new Stopwatch();

        var input = GeneratedSortedArray(LENGTH, MIN, MAX);
        Console.WriteLine($"Is Sorted Input: {IsSorted(input)}");

        Console.WriteLine("Bubble Sort");
        stopwatch.Start();
        var bubbleArray = (int[])input.Clone();
        BubbleSort(bubbleArray);
        Console.WriteLine($"Execution time: {stopwatch.Elapsed}");
        Console.WriteLine($"Is Sorted: {IsSorted(bubbleArray)}");
        //PrintArray(bubbleArray);

        Console.WriteLine("Selection Sort");
        stopwatch.Restart();
        var selectionArray = (int[])input.Clone();
        SelecionSort((int[])input.Clone());
        Console.WriteLine($"Execution time: {stopwatch.Elapsed}");
        Console.WriteLine($"Is Sorted: {IsSorted(selectionArray)}");
        //PrintArray(selectionArray);

        Console.WriteLine("Insertion Sort");
        stopwatch.Restart();
        var insertionArray = (int[])input.Clone();
        InsertionSort(insertionArray);
        Console.WriteLine($"Execution time: {stopwatch.Elapsed}");
        Console.WriteLine($"Is Sorted: {IsSorted(insertionArray)}");
        //PrintArray(insertionArray);

        Console.WriteLine("Quick Sort");
        stopwatch.Restart();
        var quickArray = (int[])input.Clone();
        QuickSort(quickArray);
        Console.WriteLine($"Execution time: {stopwatch.Elapsed}");
        Console.WriteLine($"Is Sorted: {IsSorted(quickArray)}");
        //PrintArray(quickArray);

        Console.WriteLine("Merge Sort");
        stopwatch.Restart();
        var mergeArray = (int[])input.Clone();
        MergeSort(mergeArray);
        Console.WriteLine($"Execution time: {stopwatch.Elapsed}");
        Console.WriteLine($"Is Sorted: {IsSorted(mergeArray)}");
        //PrintArray(mergeArray);

        Console.WriteLine("Heap Sort");
        stopwatch.Restart();
        var heapArray = (int[])input.Clone();
        HeapSort(heapArray);
        Console.WriteLine($"Execution time: {stopwatch.Elapsed}");
        Console.WriteLine($"Is Sorted: {IsSorted(heapArray)}");
        //PrintArray(heapArray);
    }

    public static void BubbleSort(int[] array)
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
    }

    public static void SelecionSort(int[] array)
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
    }

    public static void InsertionSort(int[] array)
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
    }

    public static void MergeSort(int[] array)
    {
        MergeSort(array, 0, array.Length - 1);
    }

    private static void MergeSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;
            MergeSort(array, left, middle);
            MergeSort(array, middle + 1, right);
            Merge(array, left, middle, right);
        }
    }

    public static void Merge(int[] array, int left, int middle, int right)
    {
        int leftArrayLength = middle - left + 1;
        int rightArrayLenght = right - middle;

        int[] leftArray = new int[leftArrayLength];
        int[] rightArray = new int[rightArrayLenght];

        Array.Copy(array, left, leftArray, 0, leftArrayLength);
        Array.Copy(array, middle + 1, rightArray, 0, rightArrayLenght);

        int leftIndex = 0;
        int rightIndex = 0;
        int mergedIndex = left;

        while (leftIndex < leftArrayLength && rightIndex < rightArrayLenght)
        {
            if (leftArray[leftIndex] <= rightArray[rightIndex])
            {
                array[mergedIndex] = leftArray[leftIndex];
                leftIndex++;
            }
            else
            {
                array[mergedIndex] = rightArray[rightIndex];
                rightIndex++;
            }
            mergedIndex++;
        }
        while (leftIndex < leftArrayLength)
        {
            array[mergedIndex++] = leftArray[leftIndex++];
        }
        while (rightIndex < rightArrayLenght)
        {
            array[mergedIndex++] = rightArray[rightIndex++];
        }
    }

    public static void QuickSort(int[] array)
    {
        Quick_Sort(array, 0, array.Length - 1);
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

    public static void HeapSort(int[] array)
    {
        MyHeap myHeap = new MyHeap(array);
        int i = array.Length - 1;
        while (myHeap.Count > 0)
        {
            array[i] = myHeap.Pop();
            i--;
        }
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