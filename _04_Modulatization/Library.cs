using System;

namespace OurCompany;
public class Library
{
    public static int ReadInteger(string prompt = "Number", string signal = ":")
    {
        Console.Write($"{prompt}{signal} ");
        return Convert.ToInt32(Console.ReadLine());
    }

    public static void RepeatChar(char content, int times)
    {
        for (int i = 1; i <= times; i++)
        {
            Console.Write(content);
        }
    }

    public static void IntDivision(int dividend, int divisor,
                                   out int quocient, out int remainder)
    {
        quocient = dividend / divisor;
        remainder = dividend % divisor;
    }

    public static void PrintArray(int[] array, bool inline = false)
    {
        if (inline) {
            // Open Bracket
            Console.Write("[");
            // All elements but the last one
            for (int i = 0; i < array.Length - 1; i++)
            {
                Console.Write($"{array[i]}, ");
            }
            // Last element and the close bracket
            Console.WriteLine($"{array[array.Length - 1]}]");
        } else {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"[{i} = {array[i]}]");
            }
        }
    }
}