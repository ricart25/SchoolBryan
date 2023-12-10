using school.BR.Entidades;
using school.BR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.BR.Interfaces
{
    public interface IStudentGradeDao
    {
        
        void SaveStudentGrade(StudentGrade studentGrade);
        void UpdateStudentGrade(StudentGrade studentGrade);
        /*void RemoveStudentGrade(StudentGrade studentGrade);*/
        List<StudentGradeModel> GetStudentGrades();
        StudentGradeModel GetStudentGradeById(int studentGradeId);
    }
}
