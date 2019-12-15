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
    public class DoctorService : IDoctorService
    {

        private IDoctorRepository _doctorRepository;
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public int Add(Doctors obj)
        {
          return  _doctorRepository.Save(obj);

        }

        public int Delete(int id)
        {
            return _doctorRepository.Delete(id);
        }

        public IEnumerable<Doctors> Get()
        {
            return _doctorRepository.Get();
        }

        public IEnumerable<Doctors> GetByDepartment(int id)
        {
            throw new NotImplementedException();
        }

        public Doctors GetById(int id)
        {
            return _doctorRepository.GetById(id);
        }

        public int Update(Doctors obj)
        {
            return _doctorRepository.Update(obj);
        }
    }
}
