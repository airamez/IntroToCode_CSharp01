using System;
/*
# The sealed keyword is used to prevent a class from being inherited
   by other classes.
# When applied to a class, the sealed modifier prevents other classes
  from inheriting from it.
# A sealed class cannot have a derived class.
# You can also use the sealed modifier on a method or property that 
  overrides a virtual method or property in a base class. 
  This enables you to allow classes to derive from your class and 
  prevent them from overriding specific virtual methods or properties.
# When you define new methods or properties in a class, you can prevent
  deriving classes from overriding them by not declaring them as virtual.
# It is an error to use the abstract modifier with a sealed class, because
  an abstract class must be inherited by a class that provides an 
  implementation of the abstract methods or properties.
 */

 public class SealedApp {
    public static void Main (string[] args) {

    }
 }