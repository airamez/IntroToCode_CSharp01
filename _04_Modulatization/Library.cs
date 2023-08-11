using System;

namespace OurCompany;
public class Library {
    public static int ReadInteger(string prompt, string signal)
    {
        Console.Write($"{prompt} {signal} ");
        return Convert.ToInt32(Console.ReadLine());
    }

    public static void RepeatChar(char content, int times){
        for (int i = 1; i <= times; i++)
        {
            Console.Write(content);
        }
    }
}