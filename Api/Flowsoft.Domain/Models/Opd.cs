using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flowsoft.Domain.Models
{
    public class Opds
    {
        public Opds()
        {
        }
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string OpdNotes { get; set; }
        public string Prescription { get; set; }
        public DateTime OpdDate { get; set; }
        public int TokenNumber { get; set; }
        public bool IsChecked { get; set; }
    }
}
