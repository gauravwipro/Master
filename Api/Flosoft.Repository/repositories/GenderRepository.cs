using Flowsoft.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Flowsoft.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Flowsoft.Repository.repositories
{
    public class GenderRepository : IGenderRepository
    {
        IUnitOfWork _unitOfWork;
        public GenderRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Delete(int id)
        {
            var gender = _unitOfWork.GetRepository<Genders>().GetFirstOrDefault(predicate: x => x.Id.Equals(id), orderBy: source => source.OrderByDescending(b => b.Id));
            _unitOfWork.GetRepository<Genders>().Delete(gender);
            return _unitOfWork.SaveChanges();
        }

        public List<Genders> Get()
        {
            return _unitOfWork.GetRepository<Genders>().GetPagedList().Items.ToList();
        }

        public Genders GetById(int id)
        {
            return _unitOfWork.GetRepository<Genders>().GetFirstOrDefault(predicate: x => x.Id.Equals(id), orderBy: source => source.OrderByDescending(b => b.Id));
            ;
        }

        public int Save(Genders entity)
        {
            _unitOfWork.GetRepository<Genders>().Insert(entity);
            return _unitOfWork.SaveChanges();
        }

        public int Update(Genders entity)
        {
            _unitOfWork.GetRepository<Genders>().Update(entity);
            return _unitOfWork.SaveChanges();

        }
    }
}
