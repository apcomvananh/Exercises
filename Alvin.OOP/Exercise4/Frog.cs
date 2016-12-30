using System;

namespace Exercise4
{
    public class Frog : Animal
    {
        public Frog(string name, int age, string sex) : base(name, age, sex)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("{0}: Frog sound", Name);
        }
    }
}