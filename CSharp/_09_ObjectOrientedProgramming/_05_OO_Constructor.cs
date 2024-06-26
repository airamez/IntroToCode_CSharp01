using System;

/*
# A constructor is a special method that is called to create (instatiated) an object.
# The name of the constructor is always the same as the name of the class.
# There is no need to declare a returning type
# A constructor can be public or private.
# A class can have multiple overloaded constructors that take different arguments.
# Constructors enable the programmer to set default values, limit instantiation, 
  and write code that is flexible and easy to read.
# It is possible to reuse constructors by add : ClassName(parameters)
# In C#, a default constructor is a constructor that is automatically generated by the compiler
  when you don’t define any constructors in a class. It is an empty constructor with no parameters
  that initializes the object’s data members to their default values.
  If you define any other constructor, the default constructor is not generated by the compiler.
 */
public class CarApp
{
  public static void Main(string[] args)
  {
    Car car1; // declaration
    car1 = new Car("AAA1", "Toyota", "SUV", "Rav4"); // instantiation
    car1.SetYear(2023);
    car1.SetColor("Silver");
    car1.Print();

    Car car2 = new Car("BBB1", "Ford", "Truck", "Tundra", 2018, "Silver");
    car2.Print();

    Car car3 = new Car("456K", "Volkswagen", "Sedan", "Passat", 2018);
    car3.Print();

    Car car4 = new Car("567K", "Volkswagen", "SUV", "Tiguan", "Blue");
    car4.Print();
  }
}



public class Car
{
  private string vim;
  private string maker;
  private string carType;
  private string model;
  private int year;
  private string color;

  // Constructors
  public Car(string vim, string maker, string carType, string model)
  {
    SetVIM(vim);
    SetMaker(maker);
    SetCarType(carType);
    SetModel(model);
  }

  public Car(string vim, string maker, string carType,
              string model, int year, string color)
              : this(vim, maker, carType, model)
  {
    SetYear(year);
    SetColor(color);
  }

  public Car(string vim, string maker, string carType,
              string model, int year)
              : this(vim, maker, carType, model)
  {
    SetYear(year);
  }

  public Car(string vim, string maker, string carType,
              string model, string color)
              : this(vim, maker, carType, model)
  {
    SetColor(color);
  }

  public void SetVIM(string value)
  {
    vim = value;
  }

  public string GetVIM()
  {
    return vim;
  }

  public void SetMaker(string value)
  {
    maker = value;
  }

  public string GetMaker()
  {
    return maker;
  }

  public void SetCarType(string value)
  {
    carType = value;
  }

  public string GetCarType()
  {
    return carType;
  }

  public void SetModel(string value)
  {
    model = value;
  }

  public string GetModel()
  {
    return model;
  }

  public void SetYear(int value)
  {
    year = value;
  }

  public int GetYear()
  {
    return year;
  }

  public void SetColor(string value)
  {
    color = value;
  }

  public string GetColor()
  {
    return color;
  }

  public void Print()
  {
    Console.Write($"VIM: {GetVIM()}; Maker: {GetMaker()}; ");
    Console.Write($"Type:{GetType()}; Model:{GetModel()}; ");
    Console.WriteLine($"Year: {GetYear()}; Color: {GetColor()}");
  }
}