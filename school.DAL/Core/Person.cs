using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.BR.CORE
{
    public abstract class Person : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
