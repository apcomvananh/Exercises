using System;

namespace Exercise4
{
    public class Cat : Animal
    {
        public Cat(string name, int age, string sex) : base(name, age, sex)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("{0}: cat sound", Name);
        }
    }
}