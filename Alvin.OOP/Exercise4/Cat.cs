using System;

namespace Exercise4
{
    public class Cat : Animal
    {
        public Cat(string name, int age, Sex sex) : base(name, age, sex, AnimalSound.Cat)
        {
        }
    }
}