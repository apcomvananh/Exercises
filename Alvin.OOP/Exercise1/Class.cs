using System.Collections.Generic;

namespace Exercise1
{
    public class Class
    {
        public Class(string classId, IList<Teacher> teachers, IList<Student> students)
        {
            ClassId = classId;
            Teachers = teachers;
            Students = students;
        }

        public string ClassId { get; private set; }

        public IList<Teacher> Teachers { get; private set; }

        public IList<Student> Students { get; private set; }
    }
}