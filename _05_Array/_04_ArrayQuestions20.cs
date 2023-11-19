using System;
using System.Linq;
using System.Reflection;
using OurCompany;

/*
 * 20. Implement a routine to indicate if an array of integers has two values that sum 
       to a provided value: bool HasSum(array, sum)
 */
public class ArrayQuestion20
{
    public static void Main(string[] args)
    {
        int[] array = {7, 3, 8, 5, 2, 0, 4, 1, -2};
        Console.WriteLine(HasSum(array, 5)); // true
        Console.WriteLine(HasSum(array, 8)); // true
        Console.WriteLine(HasSum(array, 7)); // true
        Console.WriteLine(HasSum(array, 3)); // true
        Console.WriteLine(HasSum(array, 0)); // true
        Console.WriteLine(HasSum(array, 6)); // true
        Console.WriteLine(HasSum(array, -6) == false); // false
        Console.WriteLine(HasSum(array, 20) == false); // false
    }

    public static bool HasSum(int[] array, int sum) {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] + array[j] == sum) {
                    return true;
                }
            }
        }
        return false;
    }
}
