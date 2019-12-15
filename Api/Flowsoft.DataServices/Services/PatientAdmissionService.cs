using Flowsoft.Hms.Database;
using Flowsoft.DataServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Flowsoft.Data;
using Flowsoft.Domain.Models;
using Flowsoft.Repository.interfaces;

namespace Flowsoft.DataServices.Services
{
    public class PatientAdmissionService : IPatientAdmissionService
    {
        IPatientAdmissionRepository _patientAdmissionRepository;
        public PatientAdmissionService(IPatientAdmissionRepository patientAdmissionRepository)
        {
            _patientAdmissionRepository = patientAdmissionRepository;
        }

        public int Add(PatientAdmission obj)
        {
            return _patientAdmissionRepository.Save(obj);
        }

        public int Delete(int id)
        {
            return _patientAdmissionRepository.Delete(id);
        }

        public IEnumerable<PatientAdmission> Get()
        {
            return _patientAdmissionRepository.Get();
        }

        public PatientAdmission GetById(int id)
        {
            return _patientAdmissionRepository.GetById(id);
        }

        public int Update(PatientAdmission obj)
        {
            return _patientAdmissionRepository.Update(obj);
        }
    }
}
