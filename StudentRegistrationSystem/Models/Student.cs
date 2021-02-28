using System.Collections.Generic;

namespace StudentRegistrationSystem.Models
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Course> Courses { get; set; }
        public string StudentNumber { get; set; }

        public Student ()
        {
            Courses = new List<Course>();
        }

        public Student (string firstName, string lastName, string studentNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Courses = new List<Course>();
            StudentNumber = studentNumber;
        }
    }
}
