using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Flowsoft.DataServices.Interfaces;
using Flowsoft.Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace Flowsoft.Hms.Controllers
{
    [Produces("application/json")]
    [EnableCors("CORS")]
    public class DoctorController : Controller
    {
        private IDoctorService doctorService;
        private IDepartmentService departmentService;
        private IStateService stateService;
        private IGenderService genderService;

        public DoctorController(IDoctorService _doctorService, IDepartmentService _departmentService, IStateService _stateService, IGenderService _genderService)
        {
            doctorService = _doctorService;
            departmentService = _departmentService;
            stateService = _stateService;
            genderService = _genderService;
        }
        [HttpGet]
        [Route("api/Doctor/Index")]
        public IEnumerable<Doctors> Index()
        {
            return doctorService.GetAll();
        }

        [HttpPost]
        [Route("api/Doctor/Create")]
        public int Create([FromBody] Doctors doctor)
        {
            return doctorService.Add(doctor);
        }

        [HttpGet]
        [Route("api/Doctor/Details/{id}")]
        public Doctors Details(int id)
        {
            return doctorService.Get(id);
        }

        [HttpGet]
        [Route("api/Doctor/GetDepartmentList")]
        public IEnumerable<Departments> GetDepartmentList()
        {
            return departmentService.GetAll();
        }

        [HttpGet]
        [Route("api/Doctor/GetDoctorsList/{id}")]
        public IEnumerable<Doctors> GetDoctorsList(int id)
        {
            return doctorService.GetByDepartment(id);
        }

        [HttpGet]
        [Route("api/Doctor/GetStateList")]
        public IEnumerable<States> GetStateList()
        {
            return stateService.GetAll();
        }

        [HttpGet]
        [Route("api/Doctor/GetGenderList")]
        public IEnumerable<Genders> GetGenderList()
        {
            return genderService.GetAll();
        }
        [HttpPut]
        [Route("api/Doctor/Edit")]
        public int Edit([FromBody]Doctors doctor)
        {
            return doctorService.Update(doctor);
        }

        [HttpDelete]
        [Route("api/Doctor/Delete/{id}")]
        public int Delete(int id)
        {
            return doctorService.Delete(id);
        }
    }
}