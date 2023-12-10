using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.BR.Models
{
    public class OnsiteCourseModel
    {
        public int CourseID { get; set; }
        public string? Location { get; set; }
        public string? Days { get; set; }
        public DateTime Time { get; set; }
    }
}
