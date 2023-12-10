using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.BR.Models
{
    public class OfficeAssignmentModel
    {
        public int InstructorId { get; set; }
        public string? Location { get; set; }
        public byte[]? Timestamp { get; set; }

    }
}
