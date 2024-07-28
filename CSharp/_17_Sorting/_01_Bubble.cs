using System;

namespace Sorting.Bubble;

public class BubbleSortApp
{
    public static void Main(string[] args)
    {
        var array = Util.GeneratedSortedArray(20, 1, 100);
        Util.PrintArray(array);
    }
}