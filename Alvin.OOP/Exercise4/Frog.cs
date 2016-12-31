using System;

namespace Exercise4
{
    public class Frog : Animal
    {
        public Frog(string name, int age, Sex sex) : base(name, age, sex, AnimalSound.Frog)
        {
        }
    }
}