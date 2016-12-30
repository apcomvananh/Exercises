using System.Collections.Generic;

namespace Exercise1
{
    public class School
    {
        ////Fields
        private string _name;

        private IList<Class> _classes;

        ////Contructor
        public School(string name, IList<Class> classes)
        {
            _name = name;
            _classes = classes;
        }

        ////Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public IList<Class> Classes
        {
            get { return _classes; }
            set { _classes = value; }
        }
    }
}