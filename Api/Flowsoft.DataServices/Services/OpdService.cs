using Flowsoft.Data;
using Flowsoft.DataServices.Interfaces;
using Flowsoft.Domain.Models;
using Flowsoft.Domain.Viewmodels;
using Flowsoft.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flowsoft.DataServices.Services
{
    public class OpdService : IOpdService
    {
        IOpdRepository _opdRepository;
        IDepartmentRepository _departmentRepository;
        IPatientRepository _patientRepository;
        IPatientAdmissionRepository _patientAdmissionRepository;
        IDoctorRepository _doctorRepository;
        public OpdService(IOpdRepository opdRepository, IDepartmentRepository departmentRepository,
            IPatientRepository patientRepository, IPatientAdmissionRepository patientAdmissionRepository,
            IDoctorRepository doctorRepository)
        {
            _opdRepository = opdRepository;
            _departmentRepository = departmentRepository;
            _patientAdmissionRepository = patientAdmissionRepository;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
        }

        public int Add(Opds obj)
        {
            return _opdRepository.Save(obj);
        }

        public int Delete(int id)
        {
            return _opdRepository.Delete(id);
        }

        public int GenerateToken(int doctorId, DateTime appointmentDate)
        {
            try
            {
                List<Opds> opds = _opdRepository.Get().Where(p => p.DoctorId == doctorId && DateTime.Compare(p.OpdDate.Date, appointmentDate.Date) == 0).ToList();
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

        public IEnumerable<Opds> Get()
        {
            return _opdRepository.Get();
        }

        public Opds GetById(int id)
        {
            return _opdRepository.GetById(id);
        }

        public IEnumerable<Opds> GetByPatient(int patientId)
        {
            return _opdRepository.Get().Where(p => p.PatientId == patientId).ToList();
        }


        public IEnumerable<DailyAppointments> GetDailyAppointments(int doctorId, DateTime appointmentDate)
        {
            try
            {
                return (from opd in _opdRepository.Get()
                        join patient in _patientRepository.Get() on opd.PatientId equals patient.Id
                        join doct in _doctorRepository.Get() on opd.DoctorId equals doct.Id
                        join depart in _departmentRepository.Get() on doct.DepartmentId equals depart.Id
                        where DateTime.Compare(opd.OpdDate.Date, appointmentDate.Date) == 0 && opd.DoctorId == doctorId
                        select new DailyAppointments
                        {
                            OpdId = opd.Id,
                            IsChecked = opd.IsChecked,
                            OpdNotes = opd.OpdNotes,
                            Prescription = opd.Prescription,
                            AppointmentDate = opd.OpdDate,
                            Count = (from opd in _opdRepository.Get()
                                     join doct in _doctorRepository.Get() on opd.DoctorId equals doct.Id
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
                return (from opds in _opdRepository.Get()
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
                return from opd in _opdRepository.Get()
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
                var opdDetail = (from opds in _opdRepository.Get()
                                 where opds.Id == id
                                 select new
                                 {
                                     patientId = opds.PatientId
                                 }).SingleOrDefault();

                return (from opds in _opdRepository.Get()
                        join doctors in _doctorRepository.Get() on opds.DoctorId equals doctors.Id
                        join department in _departmentRepository.Get() on opds.DepartmentId equals department.Id
                        join patient in _patientRepository.Get() on opds.PatientId equals patient.Id
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
                return (from opds in _opdRepository.Get()
                        join doctors in _doctorRepository.Get() on opds.DoctorId equals doctors.Id
                        join department in _departmentRepository.Get() on opds.DepartmentId equals department.Id
                        join patient in _patientRepository.Get() on opds.PatientId equals patient.Id
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
            var opd = _opdRepository.Get().SingleOrDefault(p => p.Id == dailyAppointments.OpdId);
            opd.OpdNotes = dailyAppointments.OpdNotes;
            opd.Prescription = dailyAppointments.Prescription;
            opd.IsChecked = true;
            return _opdRepository.Update(opd);
        }

        public int Update(Opds obj)
        {

            var opd = _opdRepository.Get().SingleOrDefault(p => p.Id == obj.Id);
            opd.OpdNotes = obj.OpdNotes;
            opd.Prescription = obj.Prescription;
          return  _opdRepository.Update(opd);
        }
    }
}
