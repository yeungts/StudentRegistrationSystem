using System.Collections.Generic;
namespace Assignment1.Models
{
    public sealed class Repository
    {
        private static Repository instance = null;
        private static readonly object threadLock = new object();

        Repository() { initCourses(); }

        public static Repository Instance { get
            {
                lock (threadLock)
                {
                    if (instance == null)
                    {
                        instance = new Repository();
                    }
                    return instance;
                }
            }
        }

        public List<Student> Students { get; set; } = null;
        public List<Course> Courses { get; set; } = null;

        public List<RegResponse> Responses { get; set; } = new List<RegResponse>();
        public string ErrorMessage { get; set; } = "";

        public void initCourses()
        {
            if (Courses == null)
            {
                Courses = new List<Course> {
                    new Course { CourseName = "Java 1", CourseCode = "PROG 10082", EnrollmentList = new List<Student>(), Credit = 6 },
                    new Course { CourseName = "Java 2", CourseCode = "PROG 24178", EnrollmentList = new List<Student>(), Credit = 6 },
                    new Course { CourseName = "Web Development", CourseCode = "SYST 10049", EnrollmentList = new List<Student>(), Credit = 3 },
                    new Course { CourseName = "Computer Math Fundamentals", CourseCode = "MATH 18584", EnrollmentList = new List<Student>(), Credit = 4 }
                };
            }
        }

        public int EnrollStudent(Student student, string courseCode)
        {
            ErrorMessage = "";
            int indexExistStudent = -1;

            if (Students != null)
            {
                // check if student exist in the student list
                foreach (var studentInList in Students)
                {
                    if (studentInList.StudentNumber.Equals(student.StudentNumber))
                    {
                        if (studentInList.FirstName.Equals(student.FirstName) && studentInList.LastName.Equals(student.LastName))
                        {
                            indexExistStudent = Students.IndexOf(studentInList);
                            student = studentInList;
                            break;
                        }
                        else
                        {
                            ErrorMessage = "Error: SID #" + studentInList.StudentNumber + " belongs to " + studentInList.FirstName + ", " + studentInList.LastName +
                                ". But user entered " + student.FirstName + ", " + student.LastName + " instead.";
                            return -1;
                        }
                    }
                }
            }
            else Students = new List<Student>();

            // check if a student has already enrolled into a course 
            if (indexExistStudent != -1)
            {
                foreach (var enrolledCourse in student.Courses)
                {
                    if (enrolledCourse.CourseCode.Equals(courseCode))
                    {
                        ErrorMessage = "Error: SID #" + student.StudentNumber + ", " + student.FirstName + ", " + student.LastName +
                               " has already enrolled in " + courseCode + ".";
                        return -1;
                    }
                }
            }

            if (Courses != null)
            {
                // adding selected course into student's course list
                foreach (var course in Courses)
                {
                    if (course.CourseCode.Equals(courseCode))
                    {
                        student.Courses.Add(course);
                        course.EnrollmentList.Add(student);
                        break;
                    }
                }
            }
            else 
            {
                ErrorMessage = "There are no courses avaliable at the moment";
                return -1;
            }
            

            // adding the student if the student does not exist in the list
            if (indexExistStudent == -1) Students.Add(student);

            return 0;
        }

        public Student DropAndReturnStudent(string sid, string courseCode)
        {
            ErrorMessage = "";
            foreach (var student in Students)
            {
                if (sid.Equals(student.StudentNumber))
                {
                    foreach (var course in student.Courses)
                    {
                        if (course.CourseCode.Equals(courseCode))
                        {
                            course.EnrollmentList.Remove(student);
                            student.Courses.Remove(course);
                            return student;
                        }
                    }
                    // Code shouldnt gets here but just in case
                    ErrorMessage = "Error: SID# " + sid + " is not enrolled in " + courseCode + ".";
                    return null;
                }
            }
            // Code should be impossable to get here but just in case
            ErrorMessage = "Error: Student associated to SID# " + sid + " not found";
            return null;
        }

        public Student GetStudent(string sid)
        {
            foreach (var student in Students)
            {
                if (sid.Equals(student.StudentNumber)) return student;
            }
            return null;
        }

        public int AddCourse(Course course)
        {
            ErrorMessage = "";

            if (course.CourseCode.Length != 10)
            {
                ErrorMessage = "Error: Course code requires to be in 'AAAA 00000' format but '" + course.CourseCode + "' was submitted.";
                return -1;
            }

            if (Courses != null)
            {
                // Check if course exist and if there's and course with similar name
                foreach (var existingCourse in Courses)
                {
                    if (course.CourseCode.Equals(existingCourse.CourseCode))
                    {
                        ErrorMessage = "Error: " + existingCourse.CourseCode + " exists already and appears to be "
                            + existingCourse.CourseName;
                        return -1;
                    }
                    if (course.CourseName.Equals(existingCourse.CourseName))
                    {
                        ErrorMessage = "Error: Course name of '" + course.CourseName + "' was already taken by "
                            + existingCourse.CourseCode;
                        return -1;
                    }
                }
            }
            else Courses = new List<Course>();

            Courses.Add(course);
            return 0;
        }

        public Course GetCourse(string courseCode)
        {
            if (Courses != null)
            {
                foreach (var course in Courses)
                {
                    if (courseCode.Equals(course.CourseCode)) return course;
                }
            }

            return null;
        }

    }
}
