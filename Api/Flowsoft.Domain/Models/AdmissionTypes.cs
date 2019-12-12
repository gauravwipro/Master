using System;
using System.Collections.Generic;

namespace Flowsoft.Domain.Models
{
    public partial class AdmissionTypes
    {
        public AdmissionTypes()
        {
            PatientAdmission = new HashSet<PatientAdmission>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<PatientAdmission> PatientAdmission { get; set; }
    }
}
