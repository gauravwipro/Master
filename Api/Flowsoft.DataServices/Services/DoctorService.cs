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
    public class DoctorService : IDoctorService
    {
        public DoctorService()
        {
        }

        public int Add(Doctors obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctors> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctors> GetByDepartment(int id)
        {
            throw new NotImplementedException();
        }

        public Doctors GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Doctors obj)
        {
            throw new NotImplementedException();
        }
    }
}
