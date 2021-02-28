namespace Assignment1.Models.ViewModels
{
    public class CourseDetailsViewModel : RepoViewModel
    {
        public Course Course{ get; set; }
        public string SID { get; set; }

        public CourseDetailsViewModel() { }
        public CourseDetailsViewModel(Course course) { Course = course; }
    }
}
