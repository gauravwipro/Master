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
    public class PatientController : Controller
    {
        private IPatientService patientService;
        private IDepartmentService departmentService;
        private IStateService stateService;
        private IGenderService genderService;

        public PatientController(IPatientService _patientService, IDepartmentService _departmentService, IStateService _stateService, IGenderService _genderService)
        {
            patientService = _patientService;
            departmentService = _departmentService;
            stateService = _stateService;
            genderService = _genderService;
        }
        [HttpGet]
        [Route("api/Patient/Index")]
        public IEnumerable<Patients> Index()
        {
            return patientService.GetAll();
        }

        [HttpPost]
        [Route("api/Patient/Create")]
        public int Create([FromBody] Patients patient)
        {
            return patientService.Add(patient);
        }

        [HttpGet]
        [Route("api/Patient/Details/{id}")]
        public Patients Details(int id)
        {
            return patientService.Get(id);
        }

        [HttpPut]
        [Route("api/Patient/Edit")]
        public int Edit([FromBody]Patients patient)
        {
            return patientService.Update(patient);
        }

        [HttpDelete]
        [Route("api/Patient/Delete/{id}")]
        public int Delete(int id)
        {
            return patientService.Delete(id);
        }

        [HttpGet]
        [Route("api/Patient/GetDepartmentList")]
        public IEnumerable<Departments> GetDepartmentList()
        {
            return departmentService.GetAll();
        }

        [HttpGet]
        [Route("api/Patient/GetStateList")]
        public IEnumerable<States> GetStateList()
        {
            return stateService.GetAll();
        }

        [HttpGet]
        [Route("api/Patient/GetGenderList")]
        public IEnumerable<Genders> GetGenderList()
        {
            return genderService.GetAll();
        }
    }
}