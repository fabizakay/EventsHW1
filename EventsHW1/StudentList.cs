using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsHW1
{
    public class StudentList
    {

        public event EventHandler FivePrcDiscount;
        public List<Student> Students { get; set; }

        public StudentList()
        {
            Students = new List<Student>();
        }
        public void AddStudent(Student s)
        {
            Students.Add(s);
            if (Students.Count % 5 == 0)
                OnFiveStudentJoined();
        }

        public void RemoveStudent(Student s)
        {
            Students.Remove(s);
        }


        private void OnFiveStudentJoined()
        {
            FivePrcDiscount?.Invoke(this, new EventArgs());
        }
        

    public class Student
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }
    }
}
}
