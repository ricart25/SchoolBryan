using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.BR.Exceptions
{
    public class InstructorDaoException : Exception
    {
        public InstructorDaoException(string message) : base(message)
        {
            // aplicar x logica //
        }
    }
}
