using Microsoft.EntityFrameworkCore;
using SchoolProject.Models;

namespace SchoolProject.Context
{
    public class MyDbContext:DbContext
    {
        
        public MyDbContext(DbContextOptions<MyDbContext> options):base(options) 
        {

        }
        public DbSet<Student>Students { get; set; }
        public DbSet<Teacher>Teachers { get; set; }
        public DbSet<Room>Rooms { get; set; }
        public DbSet<Course>Courses { get; set; }
        public DbSet<StudentCourse>StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfiguration configuration = builder.Build();
            var ConString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(ConString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
