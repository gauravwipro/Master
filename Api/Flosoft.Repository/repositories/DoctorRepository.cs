using Flowsoft.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Flowsoft.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Flowsoft.Repository.repositories
{
    class DoctorRepository : IDoctorRepository
    {
        IUnitOfWork _unitOfWork;
        public DoctorRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Delete(int id)
        {
            var doctor = _unitOfWork.GetRepository<Doctors>().GetFirstOrDefault(predicate: x => x.Id.Equals(id), orderBy: source => source.OrderByDescending(b => b.Id));
            _unitOfWork.GetRepository<Doctors>().Delete(doctor);
            return _unitOfWork.SaveChanges();
        }

        public List<Doctors> Get()
        {
            return _unitOfWork.GetRepository<Doctors>().GetPagedList().Items.ToList();
        }

        public Doctors GetById(int id)
        {
            return _unitOfWork.GetRepository<Doctors>().GetFirstOrDefault(predicate: x => x.Id.Equals(id), orderBy: source => source.OrderByDescending(b => b.Id));
            ;
        }

        public int Save(Doctors entity)
        {
            _unitOfWork.GetRepository<Doctors>().Insert(entity);
            return _unitOfWork.SaveChanges();
        }

        public int Update(Doctors entity)
        {
            _unitOfWork.GetRepository<Doctors>().Update(entity);
            return _unitOfWork.SaveChanges();

        }
    }
}
