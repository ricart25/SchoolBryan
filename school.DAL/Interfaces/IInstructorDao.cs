using school.BR.Entidades;
using school.BR.Models;


namespace school.BR.Interfaces
{
    public interface IInstructorDao
    {
        void SaveInstructor(Instructor instructor);
        void UpdateInstructor(Instructor instructor);
        void RemoveInstructor(Instructor instructor);
        List<InstructorModel> GetInstructors();
        InstructorModel GetInstructorById(int instructorId);
    }
}
