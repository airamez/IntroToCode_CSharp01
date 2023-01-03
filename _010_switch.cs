/*
    https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements

    Syntax:
    switch(expression) 
    {
    case x:
        if x equals to expression
        break;
    case y:
        if y equals to expression
        break;
    case z:
        if z equals to expression
        break;
    default:
        if no match
        break;
    }
 */
using System;
class SWITCH
{
    public static void Main(string[] args)
    {
       /*
        * Get the Day of the week description from the number
        * 1 = Sunday
        * 2 = Monday
        * 3 = Tuesday
        * 4 = Wednesday
        * 5 = Thursday
        * 6 = Friday
        * 7 = Saturday
        * Obs: Print if it is an invalid number as well.
        */
        int day = Convert.ToInt32(Console.ReadLine());
    }
}