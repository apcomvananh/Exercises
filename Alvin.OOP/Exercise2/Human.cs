namespace Exercise2
{
    public abstract class Human
    {
        ////Fields
        private string _firstName;

        private string _lastName;

        ////Contructor
        protected Human(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        ////Properties
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
    }
}