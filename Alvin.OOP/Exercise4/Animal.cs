namespace Exercise4
{
    public abstract class Animal
    {
        private string _name;
        private int _age;
        private string _sex;

        public Animal(string name, int age, string sex)
        {
            _name = name;
            _age = age;
            _sex = sex;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        public abstract void ProduceSound();
    }
}