using System;
using OurCompany;

/*
   https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/
   - Array is a data structure to store a collection of variable of the same type
   - Usually (C#, Java, C, C++) an Array has a fixed (static) type and length, define at declaration time
   - The elements of an array are accessed by an index, from 0 (first) to array length - 1 (last)
   - The declare an array we use:
     - TYPE[]
   - The length of an array is stored in the property Length
   - It is important to check if the index accesing an array element is a valid one
 */
public class ArrayAssignment
{
    public static void Main(string[] args)
    {
        int number = 10;
        int numberCopy = number;
        Console.WriteLine($"Number: {number}, NumberCopy: {numberCopy}");

        numberCopy = 20;
        Console.WriteLine($"Number: {number}, NumberCopy: {numberCopy}");

        string[] names = {"José", "Artur", "Leia"};
        string[] namesCopy = names;

        Library.PrintArray(names, true);
        Library.PrintArray(namesCopy, true);
        
        names[0] = "Jose Maria";

        Library.PrintArray(names, true);
        Library.PrintArray(namesCopy, true);
    }
}