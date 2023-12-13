using System;
using System.Runtime.Serialization;

/*
String is the most common data type in Information System
C# Strings:
 - Read-only collection of sequential Char objects
 - The length of the string is stored in the property Length
 - All methods "modifying" a string, return a new string
*/

public class _02_String {
    public static void Main (string[] args) {
        /*
         * Special Characters
         * \t = tab
         * \n = new line
         * \" = "
         * \\ = \
         */
        string specialChars = "I\tlove\tCoding\nThese are double quotes: \"*\"\nThis is a backslash: \\";
        Console.WriteLine(specialChars);

        string myString = "  I love to code  ";
        Console.WriteLine($"Length: {myString.Length}");
        Console.WriteLine($"ToUpper: {myString.ToUpper()}");
        Console.WriteLine($"ToLower: {myString.ToLower()}");
        Console.WriteLine($"Substring(2, 6): {myString.Substring(2, 6)}");
        Console.WriteLine($"Substring(9): {myString.Substring(9)}");
        Console.WriteLine($"Replace('o', '0'): {myString.Replace('o', '0')}");
        Console.WriteLine($"Replace(\"love\", \"enjoy\"): {myString.Replace("love", "enjoy")}");
        Console.WriteLine($"IndexOf('o'): {myString.IndexOf('o')}");
        Console.WriteLine($"IndexOf('x'): {myString.IndexOf('x')}");
        Console.WriteLine($"LastIndexOf('o'): {myString.LastIndexOf('o')}");
        Console.WriteLine($"Contains('love'): {myString.Contains("love")}");
        Console.WriteLine($"StartsWith('I'): {myString.StartsWith("I")}");
        Console.WriteLine($"EndsWith('code'): {myString.EndsWith("code")}");
        Console.WriteLine($"Trim(): {myString.Trim()}");
        Console.WriteLine($"TrimStart('I'): {myString.TrimStart(' ')}");
        Console.WriteLine($"TrimEnd('e'): {myString.TrimEnd(' ')}");
        Console.WriteLine($"PadLeft(20, '-'): {myString.PadLeft(20, '-')}");
        Console.WriteLine($"PadRight(20, '-'): {myString.PadRight(20, '-')}");
        Console.WriteLine($"\"\".PadLeft(20,'-'): {"".PadLeft(20,'-')}");
        Console.WriteLine($"Equals(\"abc\", \"abc\"): {string.Equals("abc", "abc")}");
        Console.WriteLine($"Equals(\"abc\", \"bca\"): {string.Equals("abc", "bca")}");
        Console.WriteLine($"IsNullOrEmpty(null): {string.IsNullOrEmpty(null)}");
        Console.WriteLine($"IsNullOrEmpty(\"\"): {string.IsNullOrEmpty("")}");
        Console.WriteLine($"IsNullOrEmpty(\" \"): {string.IsNullOrEmpty(" ")}");
        Console.WriteLine($"IsNullOrWhiteSpace(null): {string.IsNullOrWhiteSpace(null)}");
        Console.WriteLine($"IsNullOrWhiteSpace(\" \"): {string.IsNullOrWhiteSpace(" ")}");
        Console.WriteLine($"IsNullOrWhiteSpace(\"\"): {string.IsNullOrWhiteSpace("")}");
        Console.WriteLine($"Insert(4, \"do \"): {myString.Insert(4, "do ")}");
        Console.WriteLine($"Remove(3, 8): {myString.Remove(3, 8)}");
        Console.WriteLine($"Clone(): {myString.Clone()}");

        // To Array
        char[] charArray = myString.ToCharArray();
        Console.WriteLine($"ToCharArray()");
        for (int i = 0; i < charArray.Length; i++)
        {
            Console.WriteLine($"charArray[{i}]: {charArray[i]}");
        }
        Console.WriteLine($"ToCharArray(2, 10): {string.Join("\n", myString.ToCharArray(2, 10))}");
 
        string str1 = "I";
        string str2 = "love";
        string str3 = "to";
        string str4 = "code";
        
        // Concat
        myString = string.Concat(str1, " ", str2, " ", str3, " ", str4);
        Console.WriteLine($"string.Concat(str1, \" \", str2, \" \", str3, \" \", str4)): {myString}");

        // Join
        myString = string.Join('_', str1, str2, str3, str4);
        Console.WriteLine($"string.Join('_', str1, str2, str3, str4)): {myString}");

        // Split
        string[] words = myString.Split('_');
        for (int i = 0; i < words.Length; i++)
        {
            Console.WriteLine($"words[{i}]: {words[i]}");
        }

        // Multiline String
        string multiLineString = @"This is the first line
This is the second line
This is the third line";
        Console.WriteLine(multiLineString);

        // Interpolation
        string firstName = "Jose";
        string lastName = "Santos";
        string email = "jose.santos@email.com";
        string phone = "+1(999)999-9999";

        string content = $"FullName: {firstName} {lastName}; Email: {email}; Phone: {phone} ";
        Console.WriteLine(content);

        // Multiline + Interpolation
        content = $@"Full Name: {firstName} {lastName}
Email: {email}
Phone: {phone}";
        Console.WriteLine(content);
    }
}