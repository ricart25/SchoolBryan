using Microsoft.EntityFrameworkCore;
using school.BR.Context;
using school.BR.Daos;
using school.BR.DAOS;
using school.BR.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//agregar conexion de la base de datos.
builder.Services.AddDbContext<SchoolDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolDbContext")));
// Agregar al contenador el DAO (Student) //
builder.Services.AddTransient<IStudentDao, StudentDao>();
// Agregar al contenador el DAO (Instructor) //
builder.Services.AddTransient<IInstructorDao, InstructorDao>();
// Agregar al contenador el DAO (OfficeAssignment) //
builder.Services.AddTransient<IOfficeAssignmentDao, OfficeAssignmentDao>();
// Agregar al contenador el DAO (OfficeAssignment) //
builder.Services.AddTransient<IDepartmentDao, DepartmentDao>();
// Agregar al contenador el DAO (StudentGrade) //
builder.Services.AddTransient<IStudentGradeDao, StudentGradeDao>();
// Agregar al contenador el DAO (Course) //
builder.Services.AddTransient<ICourseDao, CourseDao>();
// Agregar al contenador el DAO (Course) //
builder.Services.AddTransient<IOnlineCourseDao, OnlineCourseDao>();
// Agregar al contenador el DAO (Course) //
builder.Services.AddTransient<IOnsiteCourseDao, OnsiteCourseDao>();
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
