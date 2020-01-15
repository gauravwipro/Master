using Flowsoft.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Flowsoft.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Flowsoft.Repository.repositories
{
    public class PatientRepository : IPatientRepository
    {
        IUnitOfWork _unitOfWork;
        public PatientRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Delete(int id)
        {
            var patient = _unitOfWork.GetRepository<Patients>().GetFirstOrDefault(predicate: x => x.Id.Equals(id), orderBy: source => source.OrderByDescending(b => b.Id));
            _unitOfWork.GetRepository<Patients>().Delete(patient);
            return _unitOfWork.SaveChanges();
        }

        public List<Patients> Get()
        {
            return _unitOfWork.GetRepository<Patients>().GetPagedList().Items.ToList();
        }

        public Patients GetById(int id)
        {
            return _unitOfWork.GetRepository<Patients>().GetFirstOrDefault(predicate: x => x.Id.Equals(id), orderBy: source => source.OrderByDescending(b => b.Id));
            ;
        }

        public int Save(Patients entity)
        {
            _unitOfWork.GetRepository<Patients>().Insert(entity);
            return _unitOfWork.SaveChanges();
        }

        public int Update(Patients entity)
        {
            _unitOfWork.GetRepository<Patients>().Update(entity);
            return _unitOfWork.SaveChanges();

        }
    }
}
