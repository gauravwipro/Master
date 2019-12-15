using Flowsoft.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Flowsoft.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Flowsoft.Repository.repositories
{
    public class OpdRepository : IOpdRepository
    {
        IUnitOfWork _unitOfWork;
        public OpdRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Delete(int id)
        {
            var gender = _unitOfWork.GetRepository<Opds>().GetFirstOrDefault(predicate: x => x.Id.Equals(id), orderBy: source => source.OrderByDescending(b => b.Id));
            _unitOfWork.GetRepository<Genders>().Delete(gender);
            return _unitOfWork.SaveChanges();
        }

        public List<Opds> Get()
        {
            return _unitOfWork.GetRepository<Opds>().GetPagedList().Items.ToList();
        }

        public Opds GetById(int id)
        {
            return _unitOfWork.GetRepository<Opds>().GetFirstOrDefault(predicate: x => x.Id.Equals(id), orderBy: source => source.OrderByDescending(b => b.Id));
            ;
        }

        public int Save(Opds entity)
        {
            _unitOfWork.GetRepository<Opds>().Insert(entity);
            return _unitOfWork.SaveChanges();
        }

        public int Update(Opds entity)
        {
            _unitOfWork.GetRepository<Opds>().Update(entity);
            return _unitOfWork.SaveChanges();

        }
    }
}
