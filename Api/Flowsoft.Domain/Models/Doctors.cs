using System;
using System.Collections.Generic;

namespace Flowsoft.Domain.Models
{
    public partial class Doctors
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int? StateId { get; set; }
        public int? DepartmentId { get; set; }
        public bool? IsRegular { get; set; }
        public int? GenderId { get; set; }
        public string PhoneNumber { get; set; }
        public string EmergencyNumber { get; set; }

        public Departments Department { get; set; }
        public Genders Gender { get; set; }
        public States State { get; set; }
    }
}
