namespace Exercise1
{
    public class Student : People
    {
        ////Fields
        private int _classNumber;

        ////Contructor
        public Student(string name, int classNumber) : base(name)
        {
            _classNumber = classNumber;
        }

        ////Properties
        public int ClassNumber
        {
            get { return _classNumber; }
            set { _classNumber = value; }
        }
    }
}