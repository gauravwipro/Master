using Flowsoft.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flowsoft.Domain.Viewmodels
{
    public class DailyAppointments
    {
        public int OpdId { get; set; }
        public string DoctorName { get; set; }
        public Int32 Count { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int TokenNumber { get; set; }
        public string PatientName { get; set; }
        public string DepartmentName { get; set; }
        public bool IsChecked { get; set; }
        public string OpdNotes { get; set; }
        public string Prescription { get; set; }
    }

    public class OpdDoctorUpdateData
    {
        public int OpdId { get; set; }
        public string OpdNotes { get; set; }
        public string Prescription { get; set; }
    }
}
