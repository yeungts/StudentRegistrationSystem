using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationSystem.Models
{
    public class Course
    {
        [Required(ErrorMessage = "Course Code required")]
        public string CourseCode { get; set; }
        [Required(ErrorMessage = "Course Name required")]
        public string CourseName { get; set; }
        public List<Student> EnrollmentList { get; set; }
        [Required(ErrorMessage = "Course Credit required")]
        public int Credit { get; set; }

        public Course()
        {
            EnrollmentList = new List<Student>();
        }
    }
}
