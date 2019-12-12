using Flowsoft.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flowsoft.DataServices.Interfaces
{
   public interface IDoctorService:ICrud<Doctors>
    {
        IEnumerable<Doctors> GetByDepartment(int id);
        
    }
}
