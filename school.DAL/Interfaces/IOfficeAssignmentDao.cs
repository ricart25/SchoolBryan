using school.BR.Entidades;
using school.BR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.BR.Interfaces
{
    public interface IOfficeAssignmentDao
    {
        void SaveOfficeAssignment(OfficeAssignment officeAssignment);
        void UpdateOfficeAssignment(OfficeAssignment officeAssignment);
       /* void RemoveOfficeAssignment(OfficeAssignment officeAssignment);*/
        List<OfficeAssignmentModel> GetOfficeAssignments();
        OfficeAssignmentModel GetOfficeAssignmentById(int officeAssignmentId);
    }
}
