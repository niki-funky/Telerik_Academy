using System;
using System.Linq;

namespace Person
{
    // 04. Create a class Person with two fields – name and age. Age can be left unspecified 
    // (may contain null value. Override ToString() to display the information of a person
    // and if age is not specified – to say so. Write a program to test this functionality.

    class Program
    {
        static void Main(string[] args)
        {
            //test
            Person person1 = new Person("Pesho");
            Person person2 = new Person("Gosho", 23);

            //print
            Console.WriteLine(person1);
            Console.WriteLine(person2);
        }
    }
}
