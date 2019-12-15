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
    public class StateService : IStateService
    {
        private IStateRepository _stateRepository;
        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public int Add(States obj)
        {
            return _stateRepository.Save(obj);
        }

        public int Delete(int id)
        {
            return _stateRepository.Delete(id);
        }

        public States Get(int id)
        {
            return _stateRepository.GetById(id);
        }

        public IEnumerable<States> Get()
        {
            return _stateRepository.Get();
        }


        public States GetById(int id)
        {
            return _stateRepository.GetById(id);
        }

        public int Update(States obj)
        {
            return _stateRepository.Update(obj);
        }
    }
}
