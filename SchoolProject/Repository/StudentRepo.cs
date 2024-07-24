using Microsoft.EntityFrameworkCore;
using SchoolProject.Context;
using SchoolProject.Models;

namespace SchoolProject.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly MyDbContext _myDbConnection;

        public StudentRepo(MyDbContext myDbConnection)
        {
            _myDbConnection = myDbConnection;
        }

        public List<Student> GetAllStudents()
        {
            try
            {
                List<Student> students = (from StdObjs in _myDbConnection.Students select StdObjs).ToList();
                return students;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }

        public void Create(Student student)
        {
            _myDbConnection.Students.Add(student);
            _myDbConnection.SaveChanges();
        }

        public void Delete(int id)
        {
            Student student = (from StdObjs in _myDbConnection.Students
                               where StdObjs.StudentId == id
                              select StdObjs).FirstOrDefault();
            _myDbConnection.Students.Remove(student);
            _myDbConnection.SaveChanges();
        }


        public void Register(int stdId, int courseId)
        {
            _myDbConnection.StudentCourses.Add(new StudentCourse
            {
                CourseId = courseId,
                StudentId = stdId
            });
            _myDbConnection.SaveChanges();
        }
    }
}
