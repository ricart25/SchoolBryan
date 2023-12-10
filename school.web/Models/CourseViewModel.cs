using school.BR.Entidades;

namespace school.web.Models
{
    public class CourseViewModel
    {
        public int CourseID { get; set; }
        public string? Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreationUser { get; set; }
        
        public IEnumerable<Department> Departments { get; set; }
    }
}
