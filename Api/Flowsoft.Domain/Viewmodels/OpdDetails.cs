using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flowsoft.Domain.Models
{
    public class OpdDetails
    {
        public OpdDetails()
        {
        }
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public string OpdNotes { get; set; }
        public string Prescription { get; set; }
        public DateTime OpdDate { get; set; }
        public int TokenNumber { get; set; }
    }
}
