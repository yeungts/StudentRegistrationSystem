namespace StudentRegistrationSystem.Models.ViewModels
{
    public class StudentDetailViewModel : RepoViewModel
    {
        public Student Student { get; set; }
        public string CourseCodeDropping { get; set; }

        public StudentDetailViewModel() { }
        public StudentDetailViewModel(Student student)
        {
            Student = student;
        }
    }
}
