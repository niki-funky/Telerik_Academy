using System;
using System.Linq;

namespace Animals
{
    //03. Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and 
    // define useful constructors and methods. Dogs, frogs and 
    // cats are Animals. All animals can produce sound (specified
    // by the ISound interface). Kittens and tomcats are cats. 
    // All animals are described by age, name and sex. Kittens 
    // can be only female and tomcats can be only male. Each animal
    // produces a specific sound. Create arrays of different kinds
    // of animals and calculate the average age of each kind of 
    // animal using a static method (you may use LINQ).

    class Program
    {
        static void Main(string[] args)
        {
            //test 
            Cat cat = new Cat(3, "Catty1", Sex.female);
            Console.WriteLine(cat.Name + " : " + cat.Age + " : " + cat.Sex);
            cat.MakeSound();
            Console.WriteLine();

            //make array of different kinds of animals
            Animal[] animals = {
                              new Kitten(2,"Kitty1"),
                              new Kitten(3,"Kitty2"),
                              new Tomcat(5,"Tommy1"),
                              new Tomcat(4,"Tommy2"),
                              new Frog(1,"Frog1",Sex.female),
                              new Frog(2,"Frog2",Sex.male),
                              new Frog(1,"Frog3",Sex.female),
                              new Cat(2,"",Sex.male),
                              cat,
                              new Cat(2,"Catty2",Sex.male),
                              new Dog(4,"Doggy1",Sex.male),
                              new Dog(6,"Doggy2",Sex.male)};

            // using LINQ to calculate the average age of each  
            // kind of animal in the array
            var averageAge = animals.GroupBy(x => x.GetType().Name)
                .Select(x => new
                {
                    Name = x.Key,
                    Average = x.Average(a => a.Age)
                })
                .ToList();

            foreach (var item in averageAge)
            {
                Console.WriteLine(String.Format("{0,-10}{1,2:0.0}",item.Name + " : ", item.Average));
            }
        }
    }
}
