namespace Exercise1
{
    public class Discipline
    {
        ////Fields
        private string _name;

        private int _numberOfLectures;
        private int _numberOfExercises;

        ////Contructor
        public Discipline(string name, int numberOfLectures, int numberOfExercises)
        {
            _name = name;
            _numberOfLectures = numberOfLectures;
            _numberOfExercises = numberOfExercises;
        }

        ////Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int NumberOfLectures
        {
            get { return _numberOfLectures; }
            set { _numberOfLectures = value; }
        }

        public int NumberOfExercises
        {
            get { return _numberOfExercises; }
            set { _numberOfExercises = value; }
        }
    }
}