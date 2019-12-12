using Flowsoft.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flowsoft.Domain.Viewmodels
{
    public class OpdDetailWithHistory
    {
        public string PatientName { get; set; }
        public List<OpdDetails> OpdDetails { get; set; }
    }
}
