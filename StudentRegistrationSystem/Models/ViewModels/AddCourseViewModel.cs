namespace StudentRegistrationSystem.Models.ViewModels
{
    public class AddCourseViewModel : RepoViewModel
    {
        public Course Course { get; set; }

        public AddCourseViewModel()
        {
            Course = new Course();
        }
    }
}
