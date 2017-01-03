namespace Exercise4
{
    public enum Sex
    {
        Male,
        Female
    }

    public enum AnimalSound
    {
        Dog,
        Frog,
        Cat,
        Kitten,
        Tomcat
    }

    public abstract class Animal
    {
        protected Animal(string name, int age, Sex sex, AnimalSound sound)
        {
            Name = name;
            Age = age;
            Sex = sex;
            Sound = sound;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public Sex Sex { get; private set; }

        public AnimalSound Sound { get; protected set; }

        public static string IdentifyBySound(AnimalSound sound)
        {
            switch (sound)
            {
                case AnimalSound.Dog:
                    return "Dog!";

                case AnimalSound.Frog:
                    return "Frog!";

                case AnimalSound.Cat:
                    return "Cat!";

                case AnimalSound.Kitten:
                    return "Kitten!";

                case AnimalSound.Tomcat:
                    return "Tomcat!";

                default:
                    return "Unknow animal";
            }
        }

        public static double CalculateAverageAge(Animal[] animals)
        {
            double sumOfAge = 0;
            foreach (var animal in animals)
            {
                sumOfAge += animal.Age;
            }

            return sumOfAge / animals.Length;
        }
    }
}