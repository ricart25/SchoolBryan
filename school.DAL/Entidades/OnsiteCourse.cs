using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.BR.Entidades
{
    public class OnsiteCourse
    {
        [Key]
        public int CourseID { get; set; }
        public string? Location { get; set; }
        public string? Days { get; set; }
        public DateTime Time { get; set; }
    }
}
