using System;
using System.Collections.Generic;

namespace Flowsoft.Domain.Models
{
    public partial class PatientAdmission
    {
        public PatientAdmission()
        {
            InversePatientAdmision = new HashSet<PatientAdmission>();
        }

        public int Id { get; set; }
        public int? AdmissionId { get; set; }
        public int? PatientId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? PatientAdmisionId { get; set; }

        public AdmissionTypes Admission { get; set; }
        public Patients Patient { get; set; }
        public PatientAdmission PatientAdmision { get; set; }
        public ICollection<PatientAdmission> InversePatientAdmision { get; set; }
    }
}
