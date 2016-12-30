namespace Exercise1
{
    public class Student : People
    {
        public Student(string name, int classNumber)
            : base(name)
        {
            ClassNumber = classNumber;
        }

        public int ClassNumber { get; private set; }
    }
}