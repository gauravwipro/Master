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
    public class GenderService : IGenderService
    {
        IDataContext dataContext;
        public GenderService(IDataContext _dataContext)
        {
            dataContext = _dataContext;
        }

        public int Add(Genders obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Genders> Get()
        {
            throw new NotImplementedException();
        }

        public Genders GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Genders obj)
        {
            throw new NotImplementedException();
        }
    }
}
