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
    public class StateService : IStateService
    {
        IDataContext dataContext;
        public StateService(IDataContext _dataContext)
        {
            dataContext = _dataContext;
        }

        public int Add(States obj)
        {
            try
            {
                dataContext.States.Add(obj);
                dataContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int Delete(int id)
        {
            try
            {
                States state = dataContext.States.Find(id);
                dataContext.States.Remove(state);
                dataContext.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public States Get(int id)
        {
            try
            {
                States state = dataContext.States.Find(id);
                return state;
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<States> GetAll()
        {
            try
            {
                return  dataContext.States.ToList();
            }
            catch
            {
                throw;
            }
        }


        public int Update(States obj)
        {
            try
            {
                var _state = dataContext.States.SingleOrDefault(p => p.Id == obj.Id);
                _state.Name = obj.Name;
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
