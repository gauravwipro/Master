using System;
using System.Collections.Generic;

namespace Flowsoft.Domain.Models
{
    public partial class Patients
    {
        public Patients()
        {
        }

        public int Id { get; set; }
        public string AdhaarCard { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int? StateId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string VoterCard { get; set; }
        public int Crnumber { get; set; }
        public string PhoneNumber { get; set; }
        public string EmergencyNumber { get; set; }
        public int? GenderId { get; set; }

    }

}
