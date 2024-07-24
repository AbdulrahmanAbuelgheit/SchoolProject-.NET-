using Microsoft.AspNetCore.Mvc;
using SchoolProject.Context;
using SchoolProject.Models;
using SchoolProject.Repository;

namespace SchoolProject.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepo _ITch;
        public TeacherController(ITeacherRepo ITch) { _ITch = ITch; }

        [HttpGet]
        public ActionResult Index()
        {
            List<Teacher> teachers = _ITch.GetAllTeachers();   
            return View(teachers);
        }
        [HttpGet]
        public ViewResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {
            if (teacher != null)
            {
                _ITch.Create(teacher);
            }
            List<Teacher> teachers = _ITch.GetAllTeachers();
            return View("Index",teachers);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                _ITch.Delete(id);
            }
            List<Teacher> teachers = _ITch.GetAllTeachers();
            return View("Index",teachers);
        }

    }
}
