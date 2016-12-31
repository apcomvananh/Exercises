using System;

namespace Exercise4
{
    public class Dog : Animal
    {
        public Dog(string name, int age, Sex sex) : base(name, age, sex, AnimalSound.Dog)
        {
        }
    }
}