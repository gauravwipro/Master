using Flowsoft.Data;
using Flowsoft.DataServices.Interfaces;
using Flowsoft.Domain.Models;
using Flowsoft.Domain.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flowsoft.DataServices.Services
{
    public class OpdService : IOpdService
    {
        IDataContext dataContext;
        public OpdService(IDataContext _dataContext)
        {
            dataContext = _dataContext;
        }
        public int Add(Opds obj)
        {
            try
            {
                dataContext.Opds.Add(obj);
                dataContext.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int Delete(int id)
        {
            try
            {
                Opds opd = dataContext.Opds.Find(id);
                dataContext.Opds.Remove(opd);
                dataContext.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int GenerateToken(int doctorId, DateTime appointmentDate)
        {
            try
            {
                List<Opds> opds = dataContext.Opds.Where(p => p.DoctorId == doctorId && DateTime.Compare(p.OpdDate.Date, appointmentDate.Date) == 0).ToList();
                if (opds.Count > 0)
                    return opds.Max(p => p.TokenNumber) + 1;
                else
                    return 1;
            }
            catch
            {
                throw;
            }
        }

        public Opds Get(int id)
        {
            try
            {
                Opds opd = dataContext.Opds.Find(id);
                return opd;
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Opds> GetAll()
        {
            try
            {
                return dataContext.Opds.ToList();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Opds> GetByPatient(int patientId)
        {
            try
            {
                return dataContext.Opds.Where(p => p.PatientId == patientId).ToList();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<DailyAppointments> GetDailyAppointments(int doctorId, DateTime appointmentDate)
        {
            try
            {
                return (from opd in dataContext.Opds
                        join patient in dataContext.Patients on opd.PatientId equals patient.Id
                        join doct in dataContext.Doctors on opd.DoctorId equals doct.Id
                        join depart in dataContext.Departments on doct.DepartmentId equals depart.Id
                        where DateTime.Compare(opd.OpdDate.Date, appointmentDate.Date) == 0 && opd.DoctorId == doctorId
                        select new DailyAppointments
                        {
                            OpdId = opd.Id,
                            IsChecked = opd.IsChecked,
                            OpdNotes = opd.OpdNotes,
                            Prescription = opd.Prescription,
                            AppointmentDate = opd.OpdDate,
                            Count = (from opd in dataContext.Opds
                                     join doct in dataContext.Doctors on opd.DoctorId equals doct.Id
                                     where DateTime.Compare(opd.OpdDate.Date, appointmentDate.Date) == 0
                                     select opd).Count(),
                            DepartmentName = depart.Name,
                            DoctorName = doct.FirstName + " " + doct.LastName,
                            PatientName = patient.FirstName + " " + patient.LastName,
                            TokenNumber = opd.TokenNumber
                        }).ToList();
            }
            catch
            {
                throw;
            }
        }

        public OpdDoctorUpdateData GetDetail(int id)
        {
            try
            {
                return (from opds in dataContext.Opds
                        where opds.Id == id
                        select new OpdDoctorUpdateData
                        {
                            OpdId = opds.Id,
                            OpdNotes = opds.OpdNotes,
                            Prescription = opds.Prescription
                        }).SingleOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<MonthlyAppointments> GetMonthlyAppointments(int doctorId)
        {
            try
            {
                return from opd in dataContext.Opds
                       where opd.DoctorId == doctorId
                       group opd by opd.OpdDate.Date into newGroup
                       orderby newGroup.Key
                       select new MonthlyAppointments
                       {
                           AppointmentDate = newGroup.Key,
                           Count = newGroup.Count()
                       };

            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<OpdDetails> GetOpdDetailWithHistory(int id)
        {
            try
            {
                var opdDetail = (from opds in dataContext.Opds
                                 where opds.Id == id
                                 select new
                                 {
                                     patientId = opds.PatientId
                                 }).SingleOrDefault();

                return (from opds in dataContext.Opds
                        join doctors in dataContext.Doctors on opds.DoctorId equals doctors.Id
                        join department in dataContext.Departments on opds.DepartmentId equals department.Id
                        join patient in dataContext.Patients on opds.PatientId equals patient.Id
                        where opds.PatientId == opdDetail.patientId && opds.OpdDate.Date < DateTime.Now.Date
                        select new OpdDetails
                        {
                            DepartmentName = department.Name,
                            PatientName = patient.FirstName + ' ' + doctors.LastName,
                            DoctorName = doctors.FirstName + ' ' + doctors.LastName,
                            Id = opds.Id,
                            OpdDate = opds.OpdDate,
                            OpdNotes = opds.OpdNotes,
                            Prescription = opds.Prescription,
                            TokenNumber = opds.TokenNumber

                        }).ToList();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<OpdDetails> GetTodayAppointment(int patientId)
        {
            try
            {
                return (from opds in dataContext.Opds
                        join doctors in dataContext.Doctors on opds.DoctorId equals doctors.Id
                        join department in dataContext.Departments on opds.DepartmentId equals department.Id
                        join patient in dataContext.Patients on opds.PatientId equals patient.Id
                        where opds.PatientId == patientId && DateTime.Compare(opds.OpdDate.Date, DateTime.Now.Date) == 0
                        select new OpdDetails
                        {
                            DepartmentName = department.Name,
                            PatientName = patient.FirstName + ' ' + doctors.LastName,
                            DoctorName = doctors.FirstName + ' ' + doctors.LastName,
                            Id = opds.Id,
                            OpdDate = opds.OpdDate,
                            OpdNotes = opds.OpdNotes,
                            Prescription = opds.Prescription,
                            TokenNumber = opds.TokenNumber

                        }).ToList();
            }
            catch
            {
                throw;
            }
        }

        public int Save(OpdDoctorUpdateData dailyAppointments)
        {
            try
            {
                var opd = dataContext.Opds.SingleOrDefault(p => p.Id == dailyAppointments.OpdId);
                opd.OpdNotes = dailyAppointments.OpdNotes;
                opd.Prescription = dailyAppointments.Prescription;
                opd.IsChecked = true;
                dataContext.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public int Update(Opds obj)
        {
            try
            {
                var opd = dataContext.Opds.SingleOrDefault(p => p.Id == obj.Id);
                opd.OpdNotes = obj.OpdNotes;
                opd.Prescription = obj.Prescription;
                dataContext.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
