using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Flowsoft.Repository.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;

namespace Flowsoft.Repository.repositories
{
    public class Repository<T> : interfaces.IRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(T entity)
        {
            _unitOfWork.GetRepository<T>().Insert(entity);
        }

        public void Delete(T entity)
        {
            T existing = _unitOfWork.GetRepository<T>().Find(entity);
            if (existing != null) _unitOfWork.GetRepository<T>().Delete(existing);
        }

        public IPagedList<T> Get()
        {
            return _unitOfWork.GetRepository<T>().GetPagedList();
        }

        public IPagedList<T> Get(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, int pageIndex = 0, int pageSize = 20, bool disableTracking = true)
        {
            return _unitOfWork.GetRepository<T>().GetPagedList(predicate, orderBy, include,pageIndex,pageSize,disableTracking);
        }

        public void Update(T entity)
        {
            _unitOfWork.GetRepository<T>().Update(entity);
        }
    }
}
