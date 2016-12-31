using System;

namespace Exercise4
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age) : base(name, age, Sex.Female)
        {
            Sound = AnimalSound.Kitten;
        }
    }
}