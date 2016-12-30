using System;

namespace Exercise4
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age) : base(name, age, "Female")
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("{0}: Kitten sound", Name);
        }
    }
}