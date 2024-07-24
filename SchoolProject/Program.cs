using Microsoft.EntityFrameworkCore;
using SchoolProject.Context;
using SchoolProject.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));
builder.Services.AddTransient<IStudentRepo, StudentRepo>();
builder.Services.AddTransient<ITeacherRepo, TeacherRepo>();
builder.Services.AddTransient<IRoomRepo, RoomRepo>();
builder.Services.AddTransient<ICourseRepo, CourseRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
