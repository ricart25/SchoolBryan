using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.BR.Models
{
    public class CourseModel
    {
        public int CourseID { get; set; }
       /* public string? Name { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public DateTime CreationDate { get; set; }*/
        public string? Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }

        /*public string CreationDateDisplay
        {
            get { return this.CreationDate.ToString("dd/MM/yyyy"); }
        }
        public string EnrollmentDateDisplay
        {
            get { return this.EnrollmentDate.ToString("dd/MM/yyyy"); }
        }*/
    }
}
