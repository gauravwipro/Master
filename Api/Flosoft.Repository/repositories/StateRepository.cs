using Flowsoft.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Flowsoft.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Flowsoft.Repository.repositories
{
  public  class StateRepository : IStateRepository
    {
        IUnitOfWork _unitOfWork;
        public StateRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Delete(int id)
        {
            var patient = _unitOfWork.GetRepository<States>().GetFirstOrDefault(predicate: x => x.Id.Equals(id), orderBy: source => source.OrderByDescending(b => b.Id));
            _unitOfWork.GetRepository<States>().Delete(patient);
            return _unitOfWork.SaveChanges();
        }

        public List<States> Get()
        {
            return _unitOfWork.GetRepository<States>().GetPagedList().Items.ToList();
        }

        public States GetById(int id)
        {
            return _unitOfWork.GetRepository<States>().GetFirstOrDefault(predicate: x => x.Id.Equals(id), orderBy: source => source.OrderByDescending(b => b.Id));
            ;
        }

        public int Save(States entity)
        {
            _unitOfWork.GetRepository<States>().Insert(entity);
            return _unitOfWork.SaveChanges();
        }

        public int Update(States entity)
        {
            _unitOfWork.GetRepository<States>().Update(entity);
            return _unitOfWork.SaveChanges();

        }
    }
}
