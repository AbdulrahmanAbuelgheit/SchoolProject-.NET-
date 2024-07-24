using SchoolProject.Context;
using SchoolProject.Models;

namespace SchoolProject.Repository
{
    public class CourseRepo: ICourseRepo
    {
        private readonly MyDbContext _db;
        public CourseRepo(MyDbContext db) { _db = db; }

        public void Create(Course course)
        {
            _db.Courses.Add(course);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            Course course = (from CsObjs in _db.Courses
                               where CsObjs.CourseId == id
                             select CsObjs).FirstOrDefault();
            _db.Courses.Remove(course);
            _db.SaveChanges();
        }

        public List<Course> GetAllCourses()
        {
            List<Course> courses = (from CsObjs in _db.Courses
                                      select CsObjs).ToList();
            return courses;
        }
    }
}
