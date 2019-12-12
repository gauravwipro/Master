using System;
using System.Collections.Generic;
using System.Text;

namespace Flowsoft.Repository.interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        int Save(T entity);
        int Update(T entity);
        int Delete(Int32 id);
        List<T> Get();
        T GetById(Int32 id);
    }
}
