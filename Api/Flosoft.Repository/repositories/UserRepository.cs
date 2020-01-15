using Flowsoft.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Flowsoft.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Flowsoft.Repository.repositories
{
   public class UserRepository : IUserRepository
    {
        IUnitOfWork _unitOfWork;
        public UserRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Delete(int id)
        {
            var patient = _unitOfWork.GetRepository<User>().GetFirstOrDefault(predicate: x => x.Id.Equals(id), orderBy: source => source.OrderByDescending(b => b.Id));
            _unitOfWork.GetRepository<Users>().Delete(patient);
            return _unitOfWork.SaveChanges();
        }

        public List<Users> Get()
        {
            return _unitOfWork.GetRepository<Users>().GetAll().Include(o => o.Role).ToList();
        }

        public Users GetById(int id)
        {
            return _unitOfWork.GetRepository<Users>().GetFirstOrDefault(predicate: x => x.Id.Equals(id), orderBy: source => source.OrderByDescending(b => b.Id));
            ;
        }

        public int Save(Users entity)
        {
            _unitOfWork.GetRepository<Users>().Insert(entity);
            return _unitOfWork.SaveChanges();
        }

      
        public int Update(Users entity)
        {
            _unitOfWork.GetRepository<Users>().Update(entity);
            return _unitOfWork.SaveChanges();

        }


       
    }
}
