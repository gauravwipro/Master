using System;
using System.Collections.Generic;

namespace Flowsoft.Domain.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string Hint { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public bool Enable { get; set; }
        public Nullable<int> DoctorId { get; set; }


        public Roles Role { get; set; }
    }
}
