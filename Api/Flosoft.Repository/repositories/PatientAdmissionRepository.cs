using Flowsoft.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Flowsoft.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Flowsoft.Repository.repositories
{
    public class PatientAdmissionRepository : IPatientAdmissionRepository
    {
        IUnitOfWork _unitOfWork;
        public PatientAdmissionRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Delete(int id)
        {
            var gender = _unitOfWork.GetRepository<PatientAdmission>().GetFirstOrDefault(predicate: x => x.Id.Equals(id), orderBy: source => source.OrderByDescending(b => b.Id));
            _unitOfWork.GetRepository<PatientAdmission>().Delete(gender);
            return _unitOfWork.SaveChanges();
        }

        public List<PatientAdmission> Get()
        {
            return _unitOfWork.GetRepository<PatientAdmission>().GetPagedList().Items.ToList();
        }

        public PatientAdmission GetById(int id)
        {
            return _unitOfWork.GetRepository<PatientAdmission>().GetFirstOrDefault(predicate: x => x.Id.Equals(id), orderBy: source => source.OrderByDescending(b => b.Id));
            ;
        }

        public int Save(PatientAdmission entity)
        {
            _unitOfWork.GetRepository<PatientAdmission>().Insert(entity);
            return _unitOfWork.SaveChanges();
        }

        public int Update(PatientAdmission entity)
        {
            _unitOfWork.GetRepository<PatientAdmission>().Update(entity);
            return _unitOfWork.SaveChanges();

        }
    }
}
