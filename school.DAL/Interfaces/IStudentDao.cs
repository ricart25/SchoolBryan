using school.BR.Entidades;
using school.BR.Models;

namespace school.BR.Interfaces
{
    public interface IStudentDao
    {
        void SaveStudent(Student student);
        void UpdateStudent(Student student);
        void RemoveStudent(Student student);
        List<StudentModel> GetStudents();
        StudentModel GetStudentById(int studentId);
    }
}
