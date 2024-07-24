using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;

namespace SchoolProject.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepo _ICs;
        private readonly ITeacherRepo _ITch;
        public CourseController(ICourseRepo ICs ,ITeacherRepo ITch) { _ICs = ICs; _ITch = ITch; }

        [HttpGet]
        public ActionResult Index()
        {
            List<Course> courses = _ICs.GetAllCourses();
            return View(courses);
        }
        [HttpGet]
        public ViewResult Create()
        {
            List<Teacher> teachers= _ITch.GetAllTeachers();
            return View(teachers);
        }
        [HttpPost]
        public ActionResult Create(Course course)
        {
            if (course != null)
            {
                _ICs.Create(course);
            }
            List<Course> courses = _ICs.GetAllCourses();
            return View("Index",courses);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                _ICs.Delete(id);
            }
            List<Course> courses = _ICs.GetAllCourses();
            return View("Index", courses);
        }
    }
}
