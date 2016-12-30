using System;

namespace Exercise4
{
    internal class Program
    {
        private static void Main()
        {
            var animals = GetAnimals();
            Console.WriteLine("Average age of animals is: {0}", CalculateAverageAge(animals));
            foreach (var animal in animals)
            {
                animal.ProduceSound();
            }

            Console.ReadLine();
        }

        private static double CalculateAverageAge(Animal[] animals)
        {
            double sumOfAge = 0;
            foreach (var animal in animals)
            {
                sumOfAge += animal.Age;
            }

            return sumOfAge / animals.Length;
        }

        private static Animal[] GetAnimals()
        {
            Animal[] animals = new Animal[10];
            animals[0] = new Dog("Hukki", 2, "Male");
            animals[1] = new Cat("Doremon", 1, "Male");
            animals[2] = new Cat("Doremi", 1, "Male");
            animals[3] = new Kitten("Aladin", 3);
            animals[4] = new Frog("Blue", 2, "Male");
            animals[5] = new Tomcat("Pen", 4);
            animals[6] = new Dog("Drinki", 5, "Male");
            animals[7] = new Kitten("Kitty", 2);
            animals[8] = new Frog("Green", 2, "Female");
            animals[9] = new Dog("Jeny", 2, "Male");
            return animals;
        }
    }
}