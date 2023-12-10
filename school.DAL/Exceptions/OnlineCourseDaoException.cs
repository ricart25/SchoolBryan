using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.BR.Exceptions
{
    public class OnlineCourseDaoException : Exception
    {
        public OnlineCourseDaoException(string message) : base(message)
        {
            // aplicar x logica //
        }
    }
}
