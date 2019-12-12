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
    public class PatientService: IPatientService
    {
        IDataContext dataContext;
        public PatientService(IDataContext _dataContext)
        {
            dataContext = _dataContext;
        }
        public int Add(Patients obj)
        {
            try
            {
                dataContext.Patients.Add(obj);
                dataContext.SaveChanges();
                return 1;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
        public int Delete(int id)
        {
            try
            {
                Patients patient = dataContext.Patients.Find(id);
                dataContext.Patients.Remove(patient);
                dataContext.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public Patients Get(int id)
        {
            try
            {
                Patients pat = dataContext.Patients.Find(id);
                return pat;
            }
            catch
            {
                throw;
            }
        }
        public IEnumerable<Patients> GetAll()
        {
            try
            {
                return dataContext.Patients.ToList();
            }
            catch
            {
                throw;
            }
        }
        public int Update(Patients obj)
        {
            try
            {
                var patient = dataContext.Patients.SingleOrDefault(p => p.Id == obj.Id);
                patient.FirstName = obj.FirstName;
                patient.Address = obj.Address;
                patient.AdhaarCard = obj.AdhaarCard;
                patient.City = obj.City;
                patient.EmergencyNumber = obj.EmergencyNumber;
                patient.LastName = obj.LastName;
                patient.PhoneNumber = obj.PhoneNumber;
                patient.StateId = obj.StateId;
                patient.GenderId = obj.GenderId;
                patient.VoterCard = obj.VoterCard;
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
