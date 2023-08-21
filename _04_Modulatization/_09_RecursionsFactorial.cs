using System;
using OurCompany;

public class Recursion
{
    public static void Main(string[] args)
    {
        for (int i = 0; i <= 15; i++) {
            Console.WriteLine($"{i}! = {FatRecursive(i):n0}");
        }
    }

    public static long FatRecursive (int value) {
        if (value == 0 || value == 1) {
            return 1;
        } else return value * FatRecursive(value - 1);
    }
}