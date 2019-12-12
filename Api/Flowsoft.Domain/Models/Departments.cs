using System;
using System.Collections.Generic;

namespace Flowsoft.Domain.Models
{
    public partial class Departments
    {
        public Departments()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
