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
}