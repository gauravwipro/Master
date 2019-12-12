using Flowsoft.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Flowsoft.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Flowsoft.Repository.repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        IUnitOfWork _unitOfWork;
        public DepartmentRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Delete(int id)
        {
            var department = _unitOfWork.GetRepository<Departments>().GetFirstOrDefault(predicate: x => x.Id.Equals(id), orderBy: source => source.OrderByDescending(b => b.Id));
            _unitOfWork.GetRepository<Departments>().Delete(department);
            return _unitOfWork.SaveChanges();
        }

        public List<Departments> Get()
        {
            return _unitOfWork.GetRepository<Departments>().GetPagedList().Items.ToList();
        }

        public Departments GetById(int id)
        {
            return _unitOfWork.GetRepository<Departments>().GetFirstOrDefault(predicate: x => x.Id.Equals(id), orderBy: source => source.OrderByDescending(b => b.Id));
            ;
        }

        public int Save(Departments entity)
        {
            _unitOfWork.GetRepository<Departments>().Insert(entity);
            return _unitOfWork.SaveChanges();
        }

        public int Update(Departments entity)
        {
            _unitOfWork.GetRepository<Departments>().Update(entity);
            return _unitOfWork.SaveChanges();

        }
    }
}
