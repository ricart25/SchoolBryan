using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.BR.CORE
{
    public abstract class BaseEntity
    {
        public DateTime CreationDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int CreationUser { get; set; }
        public int? UserMod { get; set; }
        public int? UserDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
