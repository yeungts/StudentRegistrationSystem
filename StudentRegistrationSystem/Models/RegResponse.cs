using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationSystem.Models
{
    public class RegResponse
    {
        [Required(ErrorMessage = "First Name required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Course required")]
        public string SelectedCourseCode { get; set; }

        [Required(ErrorMessage = "Student Number required")]
        public string StudentNumber { get; set; }
    }
}
