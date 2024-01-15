using System;
namespace OurCompany.LearnCoding.OOP.TheObjectClass; 
/*
# The object class is the root of the C# class hierarchy.
  It is the base class for all types in C#, including 
  value types and reference types.
# The object class is defined in the System namespace.
# It provides a set of methods and properties that are 
  common to all objects.
# It defines the following methods which can be overridden by derived classes:
  # Equals
  # GetHashCode
  # ToString methods
# It also defines the GetType method, which returns the type
  of the current instance.
# Class Content:
  # Explain the code
  # Run the code and review the results
  # Un-comment the ToString from MyClass
  # Run the code and review the results
*/
public class ThObjectClass {
    public static void Main (string[] args) {
        object[] objects = new object[8];
        objects[0] = new object();
        objects[1] = "Jose Santos";
        objects[2] = 5;
        objects[3] = 10.45;
        objects[4] = true;
        objects[5] = false;
        objects[6] = '#';
        objects[7] = new MyClass("Jose", "Santos");

        for (int i = 0; i < objects.Length; i++)
        {
            Console.WriteLine($"Type:{objects[i].GetType()}; ToString(): {objects[i]}");
        }
    }
}


public class MyClass  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public MyClass (string firstName, string lastName) {
        FirstName = firstName;
        LastName = lastName;
    }

    // public override string ToString()
    // {
    //     return $"{FirstName} {LastName}";
    // }
}
