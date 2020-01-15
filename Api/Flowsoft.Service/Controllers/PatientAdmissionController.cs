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
    public class PatientAdmissionController : Controller
    {
        private IPatientAdmissionService patientAdmissionService;

        public PatientAdmissionController(IPatientAdmissionService _patientAdmissionService)
        {
            patientAdmissionService = _patientAdmissionService;
        }
        [HttpGet]
        [Route("api/PatientAdmission/Index")]
        public IEnumerable<PatientAdmission> Index()
        {
            return patientAdmissionService.Get();
        }

        [HttpPost]
        [Route("api/PatientAdmission/Create")]
        public int Create([FromBody] PatientAdmission department)
        {
            return patientAdmissionService.Add(department);
        }

        [HttpGet]
        [Route("api/PatientAdmission/Details/{id}")]
        public PatientAdmission Details(int id)
        {
            return patientAdmissionService.GetById(id);
        }

        [HttpPut]
        [Route("api/PatientAdmission/Edit")]
        public int Edit([FromBody]PatientAdmission department)
        {
            return patientAdmissionService.Update(department);
        }

        [HttpDelete]
        [Route("api/PatientAdmission/Delete/{id}")]
        public int Delete(int id)
        {
            return patientAdmissionService.Delete(id);
        }
    }
}