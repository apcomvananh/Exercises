using System.Collections.Generic;

namespace Exercise1
{
    public class Class
    {
        ////Fields
        private string _classId;

        private IList<Teacher> _teachers;
        private IList<Student> _students;

        ////Contructor
        public Class(string classId, IList<Teacher> teachers, IList<Student> students)
        {
            _classId = classId;
            _teachers = teachers;
            _students = students;
        }

        ////Properties
        public string ClassId
        {
            get { return _classId; }
            set { _classId = value; }
        }

        public IList<Teacher> Teachers
        {
            get { return _teachers; }
            set { _teachers = value; }
        }

        public IList<Student> Students
        {
            get { return _students; }
            set { _students = value; }
        }
    }
}