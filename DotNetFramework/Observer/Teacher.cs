using System.Collections.Generic;
using System.Linq;

namespace Observer
{
    public class Teacher
    {
        public string Name { get; set; }
        public Teacher(string name)
        {
            _students = new List<Student>();
        }

        private List<Student> _students { get; set; }

        public void Attach(Student student)
        {
            _students.Add(student);
        }

        public void Teach()
        {
            foreach (var student in _students)
            {
                student.Listen();
            }
        }

        public bool CheckIfStudentIsListening()
        {
            return _students.All(s => s.IsListening);
        }
    }
}