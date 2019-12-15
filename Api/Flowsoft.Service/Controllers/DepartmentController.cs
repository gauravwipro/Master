using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Flowsoft.DataServices.Interfaces;
using Flowsoft.Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Flowsoft.Repository.interfaces;

namespace Flowsoft.Hms.Controllers
{
    [Produces("application/json")]
    [EnableCors("CORS")]
    public class DepartmentController : Controller
    {
        private IDepartmentService departmentService;
        IDepartmentRepository departmentRepository;

        public DepartmentController(IDepartmentService _departmentService)
        {
            departmentService = _departmentService;
        }
        [HttpGet]
        [Route("api/Department/Index")]
        public IEnumerable<Departments> Index()
        {
            return departmentService.Get();
        }

        [HttpPost]
        [Route("api/Department/Create")]
        public int Create([FromBody] Departments department)
        {
            return departmentService.Add(department);
        }

        [HttpGet]
        [Route("api/Department/Details/{id}")]
        public Departments Details(int id)
        {
            return departmentService.GetById(id);
        }

        [HttpPut]
        [Route("api/Department/Edit")]
        public int Edit([FromBody]Departments department)
        {
            return departmentService.Update(department);
        }

        [HttpDelete]
        [Route("api/Department/Delete/{id}")]
        public int Delete(int id)
        {
            return departmentService.Delete(id);
        }
    }
}