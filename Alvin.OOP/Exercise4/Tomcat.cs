using System;

namespace Exercise4
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age) : base(name, age, "Male")
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("{0}: Tomcat sound", Name);
        }
    }
}