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
    public class PatientService : IPatientService
    {
        private IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public int Add(Patients obj)
        {
            return _patientRepository.Save(obj);
        }
        public int Delete(int id)
        {
            return _patientRepository.Delete(id);
        }
        public IEnumerable<Patients> Get()
        {
            return _patientRepository.Get();
        }

        public Patients GetById(int id)
        {
            return _patientRepository.GetById(id);
        }

        public int Update(Patients obj)
        {
            return _patientRepository.Update(obj);
        }
    }
}
