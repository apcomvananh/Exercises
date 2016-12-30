namespace Exercise4
{
    public abstract class Animal
    {
        public Animal(string name, int age, string sex)
        {
            Name = name;
            Age = age;
            Sex = sex;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Sex { get; private set; }

        public abstract void ProduceSound();
    }
}