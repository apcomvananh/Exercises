using System.Collections.Generic;

namespace Exercise1
{
    public class School
    {
        public School(string name, IList<Class> classes)
        {
            Name = name;
            Classes = classes;
        }

        public string Name { get; private set; }

        public IList<Class> Classes { get; private set; }
    }
}