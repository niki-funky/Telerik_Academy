using System;

class MethodForName
{
    // Write a method that asks the user for his name
    // and prints “Hello, <name>” (for example, “Hello, Peter!”).
    // Write a program to test this method.

    static void Main()
    {
        MyName();
    }

    public static void MyName()
    {
        Console.WriteLine("What is your name?");
        string name = Console.ReadLine();
        Console.WriteLine("Hello, {0}!",name);
    }
}
