using System;

namespace Exercise4
{
    public class Dog : Animal
    {
        public Dog(string name, int age, string sex) : base(name, age, sex)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("{0}: Dog sound", Name);
        }
    }
}