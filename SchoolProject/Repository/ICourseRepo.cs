﻿using SchoolProject.Models;

namespace SchoolProject.Repository
{
    public interface ICourseRepo
    {
        public List<Course> GetAllCourses();
        public void Create(Course course);
        public void Delete(int id);
    }
}
