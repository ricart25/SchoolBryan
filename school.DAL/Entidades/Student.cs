using school.BR.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.BR.Entidades
{
    public class Student : Person
    {
        public int Id { get; set; }
        public DateTime? EnrollmentDate { get; set; }

    }
}
