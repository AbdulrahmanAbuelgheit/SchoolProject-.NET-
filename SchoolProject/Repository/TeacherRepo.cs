using Microsoft.Identity.Client;
using SchoolProject.Context;
using SchoolProject.Models;

namespace SchoolProject.Repository
{
    public class TeacherRepo : ITeacherRepo
    {
        private readonly MyDbContext _db;
        public TeacherRepo(MyDbContext db) { _db = db; }

        public void Create(Teacher teacher)
        {
            _db.Teachers.Add(teacher);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            Teacher teacher = (from TchObjs in _db.Teachers
                              where TchObjs.TeacherId == id
                              select TchObjs).FirstOrDefault();
            _db.Teachers.Remove(teacher);
            _db.SaveChanges();
        }

        public List<Teacher> GetAllTeachers()
        {
            List<Teacher> teachers=(from tchObjs in _db.Teachers
                                    select tchObjs).ToList();
            return teachers;
        }
    }
}
