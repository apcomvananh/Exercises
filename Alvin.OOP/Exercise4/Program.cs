using System;

namespace Exercise4
{
    internal class Program
    {
        private static void Main()
        {
            Dog[] dogs = new Dog[] { new Dog("Johnny", 5, Sex.Male), new Dog("Pencho", 4, Sex.Male), new Dog("Ivan", 3, Sex.Male) };
            Frog[] frogs = new Frog[] { new Frog("johnny", 5, Sex.Male), new Frog("boris", 7, Sex.Male), new Frog("galina", 3, Sex.Male) };
            Cat[] cats = new Cat[] { new Cat("kika", 1, Sex.Female), new Cat("Boris", 2, Sex.Male), new Cat("Tiger", 3, Sex.Male) };
            Kitten[] kittens = new Kitten[] { new Kitten("mimi", 3), new Kitten("krisi", 1), new Kitten("penka", 6) };
            Tomcat[] tomcats = new Tomcat[] { new Tomcat("pesho", 3), new Tomcat("boiko", 1), new Tomcat("borko", 6) };

            Console.WriteLine("Average age of dogs is {0} years", Animal.CalculateAverageAge(dogs));
            Console.WriteLine("Average age of frogs is {0} years", Animal.CalculateAverageAge(frogs));
            Console.WriteLine("Average age of cats is {0} years", Animal.CalculateAverageAge(cats));
            Console.WriteLine("Average age of kittens is {0} years", Animal.CalculateAverageAge(kittens));
            Console.WriteLine("Average age of tomcats is {0} years", Animal.CalculateAverageAge(tomcats));

            var tom = new Tomcat("Tom", 4);
            Console.WriteLine("{0} is {1}", tom.Name, Animal.IdentifyBySound(tom.Sound));

            Console.ReadLine();
        }
    }
}