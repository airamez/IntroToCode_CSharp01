using System;
using OurCompany;

/*
 * The recursions definition is very siple: A routine can call itself
 * - Direct recursion is when a routine call itself directly
 * - Undirect recursions is when a routine call other routine and
 *   in some point the initial routine is called again
 * - Concepts:
 *   - Every recursion must have a stop condition
 *     - Usually called: base case or base condition
 *   - While the stop condition is not reached the function
 *     execution is stacked
 *   - Many data-structures and advanced agororithm use recursion
 */

public class RecursionIntro
{
    public static void Main(string[] args)
    {
        CountingReverse(10);
        Console.WriteLine();
        Counting(10);
    }

    public static void CountingReverse (int number) {
        Console.Write($"{number}, ");
        if (number == 1) {
            return;
        }
        CountingReverse(number - 1);
    }

    public static void Counting (int number) {
        if (number == 0) {
            return;
        }
        Counting(number - 1);
        Console.Write($"{number}, ");
    }
}