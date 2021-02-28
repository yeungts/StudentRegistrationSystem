using Assignment1.Models;
using Assignment1.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Assignment1.Controllers
{
    public class HomeController : Controller
    {
        private Repository repo = Repository.Instance;

        public IActionResult Index() => View();

        [HttpGet]
        public IActionResult RegForm() => View(new RegFormViewModel());

        [HttpPost]
        public IActionResult RegForm(RegFormViewModel regResponse)
        {
            if (ModelState.IsValid)
            {
                repo.Responses.Add(regResponse.Response);
                int status = repo.EnrollStudent(new Student(regResponse.Response.FirstName,
                    regResponse.Response.LastName, regResponse.Response.StudentNumber),
                    regResponse.Response.SelectedCourseCode);
                if (status == -1) return View(regResponse);
                else return View("Enrolled", regResponse.Response);
            }
            else
            {
                return View(regResponse);
            }
        }

        [HttpGet]
        public IActionResult AddCourse() => View(new AddCourseViewModel());
        [HttpPost]
        public IActionResult AddCourse(AddCourseViewModel response)
        {
            if (ModelState.IsValid)
            {
                int status = repo.AddCourse(response.Course);
                if (status == -1) return View(response);
                else return View("CourseAdded", response.Course);
            } 
            else
            {
                return View(response);
            } 
        }

        public IActionResult Students() => View(new RepoWithOneArgViewModel());
        [HttpGet]
        public IActionResult Student_details(RepoWithOneArgViewModel response) => View(new StudentDetailViewModel(repo.GetStudent(response.Data)));

        [HttpGet]
        public IActionResult Student_details_from_course_details(CourseDetailsViewModel response) => View("Student_details", new StudentDetailViewModel(repo.GetStudent(response.SID)));

        [HttpPost]
        public IActionResult Student_details(StudentDetailViewModel response) 
            => View(new StudentDetailViewModel(repo.DropAndReturnStudent(
                response.Student.StudentNumber,
                response.CourseCodeDropping)));
        public IActionResult Courses() => View(new RepoWithOneArgViewModel());
        [HttpGet]
        public IActionResult Course_details(RepoWithOneArgViewModel response) => View(new CourseDetailsViewModel(repo.GetCourse(response.Data)));
        [HttpPost]
        public IActionResult Course_details(CourseDetailsViewModel response) => View(new CourseDetailsViewModel(repo.GetCourse(response.Course.CourseCode)));
    }
}
