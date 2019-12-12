using Flowsoft.Hms.Database;
using Flowsoft.DataServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Flowsoft.Data;
using Flowsoft.Domain.Models;
using Flowsoft.Repository.interfaces;

namespace Flowsoft.DataServices.Services
{
    public class DepartmentService : IDepartmentService
    {
        private IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public int Add(Departments obj)
        {
            return _departmentRepository.Save(obj);
        }
        public int Delete(int id)
        {
            return _departmentRepository.Delete(id);
        }

        public IEnumerable<Departments> Get()
        {
            return _departmentRepository.Get();
        }

        public Departments GetById(int id)
        {
            return _departmentRepository.GetById(id);
        }

        public int Update(Departments obj)
        {
            return _departmentRepository.Update(obj);
        }
    }
}
