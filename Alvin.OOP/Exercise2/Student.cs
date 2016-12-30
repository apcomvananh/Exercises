namespace Exercise2
{
    public class Student : Human
    {
        ////Fields
        private int _grade;

        ////Contructor
        public Student(string firstName, string lastName, int grade) : base(firstName, lastName)
        {
            _grade = grade;
        }

        ////Properties
        public int Grade
        {
            get { return _grade; }
            set { _grade = value; }
        }
    }
}