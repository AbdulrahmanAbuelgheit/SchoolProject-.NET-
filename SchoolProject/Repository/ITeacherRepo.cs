using SchoolProject.Models;
using System.Runtime.InteropServices;

namespace SchoolProject.Repository
{
    public interface ITeacherRepo
    {
        public List<Teacher> GetAllTeachers();
        public void Create(Teacher teacher);
        public void Delete(int id);

    }
}
