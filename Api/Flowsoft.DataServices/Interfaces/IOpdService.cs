using Flowsoft.Domain.Models;
using Flowsoft.Domain.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flowsoft.DataServices.Interfaces
{
    public interface IOpdService : ICrud<Opds>
    {
        IEnumerable<Opds> GetByPatient(int patientId);
        int GenerateToken(int doctorId, DateTime appointmentDate);
        IEnumerable<OpdDetails> GetTodayAppointment(int patientId);
        IEnumerable<DailyAppointments> GetDailyAppointments(int doctorId, DateTime appointmentDate);
        IEnumerable<MonthlyAppointments> GetMonthlyAppointments(int doctorId);
        IEnumerable<OpdDetails> GetOpdDetailWithHistory(int id);
        int Save(OpdDoctorUpdateData dailyAppointments);
        OpdDoctorUpdateData GetDetail(int id);
    }
}
