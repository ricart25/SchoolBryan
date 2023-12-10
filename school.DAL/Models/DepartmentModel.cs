using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.BR.Models
{
    public class DepartmentModel
    {
        public int DepartmentId { get; set; }
        public string? Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreationDate { get; set; }
        public int? Administrator {  get; set; }

        public decimal Budget { get; set; }

        public string CreationDateDisplay
        {
            get { return this.CreationDate.ToString("dd/MM/yyyy"); }
        }
        public string EnrollmentDateDisplay
        {
            get { return this.StartDate.ToString("dd/MM/yyyy"); }
        }
    }
}
