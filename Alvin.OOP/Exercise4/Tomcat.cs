using System;

namespace Exercise4
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age) : base(name, age, Sex.Male)
        {
            Sound = AnimalSound.Tomcat;
        }
    }
}