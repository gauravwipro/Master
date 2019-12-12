using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flowsoft.DataServices.Interfaces
{
    public interface ICrud<T> where T : class
    {
        IEnumerable<T> Get();
        int Add(T obj);
        int Update(T obj);
        T GetById(int id);
        int Delete(int id);
    }
}
