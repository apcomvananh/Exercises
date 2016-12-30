using System.Collections.Generic;

namespace Exercise1
{
    public class Teacher : People
    {
        public Teacher(string name, IList<Discipline> disciplines)
            : base(name)
        {
            Disciplines = disciplines;
        }

        public IList<Discipline> Disciplines { get; private set; }
    }
}