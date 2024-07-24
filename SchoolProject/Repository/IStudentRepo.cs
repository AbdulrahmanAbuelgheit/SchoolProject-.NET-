using SchoolProject.Models;

namespace SchoolProject.Repository
{
    public interface IStudentRepo
    {
        public List<Student> GetAllStudents();
        public void Create(Student student);
        public void Delete(int id);
        public void Register(int stdId, int courseId);


    }
}
