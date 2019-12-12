using Flowsoft.Hms.Database;
using Flowsoft.DataServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Flowsoft.Data;
using Flowsoft.Domain.Models;

namespace Flowsoft.DataServices.Services
{
    public class PatientAdmissionService : IPatientAdmissionService
    {
        IDataContext dataContext;
        public PatientAdmissionService(IDataContext _dataContext)
        {
            dataContext = _dataContext;
        }
        public int Add(PatientAdmission obj)
        {
            try
            {
                dataContext.PatientAdmission.Add(obj);
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
                PatientAdmission patient = dataContext.PatientAdmission.Find(id);
                dataContext.PatientAdmission.Remove(patient);
                dataContext.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public PatientAdmission Get(int id)
        {
            try
            {
                PatientAdmission pat = dataContext.PatientAdmission.Find(id);
                return pat;
            }
            catch
            {
                throw;
            }
        }
        public IEnumerable<PatientAdmission> GetAll()
        {
            try
            {
                return dataContext.PatientAdmission.ToList();
            }
            catch
            {
                throw;
            }
        }
        public int Update(PatientAdmission obj)
        {
            try
            {
                var patient = dataContext.PatientAdmission.SingleOrDefault(p => p.Id == obj.Id);
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
