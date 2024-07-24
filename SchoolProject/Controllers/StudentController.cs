using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Models.VMs;
using SchoolProject.Repository;
using Microsoft.AspNetCore.Hosting;

namespace SchoolProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepo _studentRepo;
        private readonly ICourseRepo _courseRepo;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
        public StudentController(IStudentRepo studentRepo,ICourseRepo courseRepo, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _studentRepo = studentRepo;
            _courseRepo = courseRepo;
            _environment = environment;
        }

        //list of students
        [HttpGet]
        public ActionResult Index()
        {
            List<Student> StdLst= _studentRepo.GetAllStudents();
            return View(StdLst);
        }
        //render the creation view
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student,IFormFile StudentPhoto)
        {
            Guid guid = Guid.NewGuid();
            var wwwrootPath = _environment.WebRootPath + "/StudentPhotos/";
            string fullPath = System.IO.Path.Combine(wwwrootPath,guid+ StudentPhoto.FileName);
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                StudentPhoto.CopyTo(fileStream);
            };
            student.PhotonName = guid + StudentPhoto.FileName;
                _studentRepo.Create(student);
            List<Student> StdLst = _studentRepo.GetAllStudents();
            return View("Index",StdLst);
        }

        public ViewResult Delete(int id)
        {
            if (id > 0)
            {
                _studentRepo.Delete(id);
            }
           List<Student> StdLst = _studentRepo.GetAllStudents();
            return View("Index",StdLst);
        }
        [HttpGet]
        public ActionResult Register()
        {
            StudentCourseVM studentCourseVM = new StudentCourseVM();
            studentCourseVM.Courses = _courseRepo.GetAllCourses();
            studentCourseVM.Students = _studentRepo.GetAllStudents();
            return View(studentCourseVM);
        }
        [HttpPost]
        public ActionResult Register(int studentId, int courseId)
        {
            _studentRepo.Register(studentId, courseId);
           return RedirectToAction("Register");
        }
    }
}
