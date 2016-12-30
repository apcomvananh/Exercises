using System.Collections.Generic;

namespace Exercise1
{
    public class Teacher : People
    {
        ////Fields
        private IList<Discipline> _disciplines;

        ////Contructor
        public Teacher(string name, IList<Discipline> disciplines) : base(name)
        {
            _disciplines = disciplines;
        }

        ////Properties
        public IList<Discipline> Disciplines
        {
            get { return _disciplines; }
            set { _disciplines = value; }
        }
    }
}